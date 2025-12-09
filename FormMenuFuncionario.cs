using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MeuRH
{
    public partial class FormMenuFuncionario : BaseForm
    {
        private string cpfFuncionario;
        private string nomeFuncionario;
        private bool convocacaoVerificada = false;

        

        public FormMenuFuncionario(string cpfSomenteDigitos)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; 
            }
        
            InitializeComponent();
            DefinirPainelCentral(panelFuncionario);
            this.Load += FormMenuFuncionario_Load;
            this.Load += CarregarDadosFuncionario; 

            cpfFuncionario = cpfSomenteDigitos ?? "";
        }


        private void CarregarDadosFuncionario(object sender, EventArgs e)
        {
            string cpfLimpo = new string(cpfFuncionario.Where(char.IsDigit).ToArray());

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = @"
                SELECT Nome 
                FROM Funcionarios
                WHERE REPLACE(REPLACE(REPLACE(TRIM(CPF), '.', ''), '-', ''), ' ', '') = @cpf
                LIMIT 1;
            ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfLimpo);
                        var obj = cmd.ExecuteScalar();

                        if (obj != null)
                        {
                            nomeFuncionario = obj.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do funcionário: {ex.Message}");
            }

            if (string.IsNullOrWhiteSpace(nomeFuncionario))
            {
                nomeFuncionario = cpfFuncionario;
            }

            lblSaudacaoFuncionario.Text = $"Olá, {nomeFuncionario}!";
        }

        private void FormMenuFuncionario_Load(object sender, EventArgs e)
        {

            try
            {
                VerificarAtestadosAtualizados();
                VerificarConvocacaoPeriodica();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao verificar notificações: {ex.Message}");
            }
        }

        private void VerificarAtestadosAtualizados()
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    long funcionarioId;
                    string cpfLimpo = new string(cpfFuncionario.Where(char.IsDigit).ToArray());

                    string sql = @"
                        SELECT Id, Cargo FROM Funcionarios
                        WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf
                        LIMIT 1;
                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfLimpo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                return;
                            }

                            string cargo = reader["Cargo"]?.ToString() ?? "";
                            funcionarioId = Convert.ToInt64(reader["Id"]);

                            if (cargo.Equals("Médico", StringComparison.OrdinalIgnoreCase))
                            {
                                return;
                            }
                        }
                    }

                    sql = @"
                        SELECT a.Id, a.Status
                        FROM Atestados a
                        INNER JOIN Funcionarios f ON a.FuncionarioId = f.Id
                        WHERE a.FuncionarioId = @funcionarioId
                          AND f.Cargo != 'Médico'
                          AND a.Status IN ('Aceito', 'Recusado')
                          AND (a.Notificado = 0 OR a.Notificado IS NULL);
                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@funcionarioId", funcionarioId);

                        var mensagens = new List<string>();
                        var idsParaNotificar = new List<int>();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string status = reader["Status"]?.ToString() ?? "";

                                idsParaNotificar.Add(id);

                                string msg = $"Seu atestado #{id} foi {status.ToLower()}.";
                                if (status.Equals("Recusado", StringComparison.OrdinalIgnoreCase))
                                    msg += " Compareça à medicina do trabalho.";

                                mensagens.Add(msg);
                            }
                        }

                        foreach (var id in idsParaNotificar)
                        {
                            MarcarComoNotificado(id);
                        }

                        if (mensagens.Count > 0)
                        {
                            MessageBox.Show(string.Join("\n", mensagens), "Status dos Atestados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao verificar atestados: {ex.Message}");
            }
        }

        private void MarcarComoNotificado(int idAtestado)
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = "UPDATE Atestados SET Notificado = 1 WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id", idAtestado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao marcar atestado {idAtestado} como notificado: {ex.Message}");
            }
        }

        private void VerificarConvocacaoPeriodica()
        {
            string cpfLimpo = new string(cpfFuncionario.Where(char.IsDigit).ToArray());

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = @"
                        SELECT Periodico, Confirmado
                        FROM Funcionarios
                        WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf;
                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfLimpo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["Periodico"]?.ToString()?.Trim().ToLower() ?? "";
                                string confirmado = reader["Confirmado"]?.ToString()?.Trim().ToLower() ?? "";

                                bool estaConvocado = status == "convocado";
                                bool jaConfirmado = confirmado == "sim";

                                if (estaConvocado && !jaConfirmado)
                                {
                                    RegistrarConfirmacao(cpfLimpo);
                                    MessageBox.Show("Você foi convocado para o exame periódico. Procure o setor responsável.", "Convocação para Exame Periódico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao verificar convocação periódica: {ex.Message}");
            }
        }

        private void RegistrarConfirmacao(string cpfLimpo)
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = @"
                        UPDATE Funcionarios
                        SET Confirmado = 'Sim'
                        WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf;

                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfLimpo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao registrar confirmação: {ex.Message}");
            }
        }

        private void btnApontar_Click(object sender, EventArgs e)
        {
            var registro = new FormRegistro(cpfFuncionario, "Funcionário", nomeFuncionario);
            registro.Show();
            this.Hide();
        }

        private void btnAtestado_Click(object sender, EventArgs e)
        {
            var atestado = new FormAtestado(cpfFuncionario, "Funcionário", nomeFuncionario);
            atestado.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var login = new FormLogin();
            login.Show();
            this.Hide();
        }
    }
}
