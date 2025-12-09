using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuRH
{
    public partial class FormMenuGestor : BaseForm
    {
        public static string NomeGestorGlobal = "";
        public static string CpfGestorGlobal = "";

        private string cpfGestor;
        private string nomeGestor;

        public FormMenuGestor(string cpf, string nome)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            InitializeComponent();
            DefinirPainelCentral(panelGestor);

            btnAtestado.Click += btnAtestado_Click;
            btnApontar.Click += btnApontar_Click;
            btnCadastroFuncionario.Click += btnCadastroFuncionario_Click;
            btnRelatorio.Click += btnRelatorio_Click;
            btnConsultar.Click += btnConsultar_Click;
            btnSair.Click += btnSair_Click;

            this.Load += FormMenuGestor_Load;

            cpfGestor = new string((cpf ?? "").Where(char.IsDigit).ToArray());
            nomeGestor = nome ?? "";

            NomeGestorGlobal = nomeGestor;
            CpfGestorGlobal = cpfGestor;

            lblBoasVindas.Text = $"Olá, {nomeGestor}!";
        }

        private void FormMenuGestor_Load(object sender, EventArgs e)
        {
            try
            {
                VerificarAtestadosDoGestor();
                VerificarConvocacaoPeriodica();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao verificar notificações: {ex.Message}");
            }
        }

        private void btnCadastroFuncionario_Click(object sender, EventArgs e)
        {
            var cadastro = new FormCadastroFuncionario(this);
            cadastro.Show();
            this.Hide();
        }

        private void btnAtestado_Click(object sender, EventArgs e)
        {
            var atestado = new FormAtestado(cpfGestor, "Gestor", nomeGestor);
            atestado.Show();
            this.Hide();
        }

        private void btnApontar_Click(object sender, EventArgs e)
        {
            var registro = new FormRegistro(cpfGestor, "Gestor", nomeGestor);
            registro.Show();
            this.Hide();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var relatorio = new FormAtualizarFuncionario();
            relatorio.Show();
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var relatorio = new FormConsultaPonto();
            relatorio.Show();
            this.Hide();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            btnListar.Enabled = false;

            try
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = $"relatorio_funcionarios_{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                string caminhoPdf = sfd.FileName;

                await Task.Run(() =>
                {
                    var service = new RelatorioService();   // ✔ CORRIGIDO!
                    service.GerarRelatorioFuncionariosPdf(caminhoPdf);
                });

                MessageBox.Show("Relatório gerado com sucesso:\n" + caminhoPdf);

                try
                {
                    Process.Start(new ProcessStartInfo(caminhoPdf)
                    {
                        UseShellExecute = true
                    });
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
            finally
            {
                btnListar.Enabled = true;
            }
        }

        private void VerificarConvocacaoPeriodica()
        {
            string cpfLimpo = new string(cpfGestor.Where(char.IsDigit).ToArray());

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
                                string periodico = reader["Periodico"]?.ToString()?.Trim().ToLower() ?? "";
                                string confirmado = reader["Confirmado"]?.ToString()?.Trim().ToLower() ?? "";

                                if (periodico == "convocado" && confirmado != "sim")
                                {
                                    RegistrarConfirmacao(cpfLimpo);
                                    MessageBox.Show(
                                        "Você foi convocado para o exame periódico. Procure o setor responsável.",
                                        "Convocação",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro ao verificar convocação: " + ex.Message);
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
                Debug.WriteLine("Erro ao registrar confirmação: " + ex.Message);
            }
        }

        private void VerificarAtestadosDoGestor()
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    long gestorId;
                    string cpfLimpo = new string(cpfGestor.Where(char.IsDigit).ToArray());

                    string sql = @"
                        SELECT Id, Cargo 
                        FROM Funcionarios
                        WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf
                        LIMIT 1;
                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfLimpo);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read()) return;

                            gestorId = Convert.ToInt64(reader["Id"]);
                            string cargo = reader["Cargo"]?.ToString() ?? "";

                            if (cargo.Equals("Médico", StringComparison.OrdinalIgnoreCase))
                                return;
                        }
                    }

                    sql = @"
                        SELECT a.Id, a.Status
                        FROM Atestados a
                        INNER JOIN Funcionarios f ON a.FuncionarioId = f.Id
                        WHERE a.FuncionarioId = @gestorId
                          AND f.Cargo != 'Médico'
                          AND a.Status IN ('Aceito', 'Recusado')
                          AND (a.Notificado = 0 OR a.Notificado IS NULL);
                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@gestorId", gestorId);

                        var mensagens = new List<string>();
                        var ids = new List<int>();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string status = reader["Status"]?.ToString() ?? "";

                                ids.Add(id);

                                string msg = $"Seu atestado #{id} foi {status.ToLower()}.";
                                if (status == "Recusado")
                                    msg += " Compareça à medicina do trabalho.";

                                mensagens.Add(msg);
                            }
                        }

                        foreach (var id in ids)
                            MarcarComoNotificado(id);

                        if (mensagens.Count > 0)
                        {
                            MessageBox.Show(string.Join("\n", mensagens),
                                "Status dos Atestados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro ao verificar atestados: " + ex.Message);
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
                Debug.WriteLine("Erro ao marcar notificado: " + ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                FormLogin? login = Application.OpenForms.OfType<FormLogin>().FirstOrDefault()
                                  ?? new FormLogin();

                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir login: " + ex.Message);
            }
        }
    }
}
