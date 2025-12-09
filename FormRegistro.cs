using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuRH
{
    public partial class FormRegistro : BaseForm
    {
        private string cargoUsuario;
        private string cpfFuncionario;
        private string cpfSomenteDigitos;
        private string nomeUsuario;

        public FormRegistro(string cpf, string cargo, string nome)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            InitializeComponent();
            DefinirPainelCentral(panelRegistro);

            cpfFuncionario = cpf ?? "";
            cpfSomenteDigitos = new string(cpfFuncionario.Where(char.IsDigit).ToArray());
            cargoUsuario = cargo ?? "";
            nomeUsuario = nome ?? "";

            txtCPF.Text = cpfFuncionario;
            txtCPF.ReadOnly = true;

            dtInicio.Value = DateTime.Today;
            dtFim.Value = DateTime.Today;

            btnEntrada.Click += (s, e) => RegistrarPonto("Entrada");
            btnSaidaAlmoco.Click += (s, e) => RegistrarPonto("Almoço");
            btnRetornoAlmoco.Click += (s, e) => RegistrarPonto("Retorno");
            btnSaida.Click += (s, e) => RegistrarPonto("Saida");
            btnFiltrar.Click += btnFiltrar_Click;
            btnVoltar.Click += BtnVoltar_Click;
        }

        private void Form2_Load(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtInicio.Value = DateTime.Today;
            dtFim.Value = DateTime.Today;
        }

        private void BtnVoltar_Click(object? sender, EventArgs e)
        {
            string cpfParaPassar = !string.IsNullOrWhiteSpace(cpfFuncionario) ? cpfFuncionario : cpfSomenteDigitos;

            if (cargoUsuario == "Gestor")
            {
                new FormMenuGestor(cpfParaPassar, nomeUsuario).Show();
            }
            else if (cargoUsuario == "Médico")
            {
                new MenuMedico(cpfParaPassar, nomeUsuario).Show();
            }
            else
            {
                new FormMenuFuncionario(cpfParaPassar).Show();
            }

            this.Hide();
        }
        private void CentralizarPainel()
        {
            panelRegistro.Location = new Point(
                (this.ClientSize.Width - panelRegistro.Width) / 2,
                (this.ClientSize.Height - panelRegistro.Height) / 2
            );
        }

        private void RegistrarPonto(string tipo)
        {
            DateTime dataHora = DateTime.Now;
            string dataHoje = dataHora.Date.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(cpfSomenteDigitos))
            {
                MessageBox.Show("CPF inválido para registro.");
                return;
            }

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                using (var transaction = conexao.BeginTransaction())
                {
                    long funcionarioId;
                    using (var cmdBusca = new SQLiteCommand(
                        "SELECT Id FROM Funcionarios WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf LIMIT 1;",
                        conexao, transaction))
                    {
                        cmdBusca.Parameters.AddWithValue("@cpf", cpfSomenteDigitos);
                        var obj = cmdBusca.ExecuteScalar();
                        if (obj == null)
                        {
                            MessageBox.Show("Funcionário não encontrado.");
                            transaction.Rollback();
                            return;
                        }
                        funcionarioId = Convert.ToInt64(obj);
                    }

                    using (var cmdVerifica = new SQLiteCommand(@"
                        SELECT COUNT(*) FROM RegistrosPonto
                        WHERE FuncionarioId = @id 
                          AND Tipo = @tipo
                          AND DATE(DataHora) = @dataHoje;", conexao, transaction))
                    {
                        cmdVerifica.Parameters.AddWithValue("@id", funcionarioId);
                        cmdVerifica.Parameters.AddWithValue("@tipo", tipo);
                        cmdVerifica.Parameters.AddWithValue("@dataHoje", dataHoje);

                        long jaRegistrado = Convert.ToInt64(cmdVerifica.ExecuteScalar());

                        if (jaRegistrado > 0)
                        {
                            MessageBox.Show($"Já existe um registro de {tipo} para hoje ({dataHoje}).\nApenas um registro de cada tipo é permitido por dia.",
                                "Registro Duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            transaction.Rollback();
                            return;
                        }
                    }

                    string insert = @"INSERT INTO RegistrosPonto (FuncionarioId, DataHora, Tipo)
                                      VALUES (@id, @dataHora, @tipo);";

                    using (var cmdIns = new SQLiteCommand(insert, conexao, transaction))
                    {
                        cmdIns.Parameters.AddWithValue("@id", funcionarioId);
                        cmdIns.Parameters.AddWithValue("@dataHora", dataHora.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmdIns.Parameters.AddWithValue("@tipo", tipo);
                        cmdIns.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show($"Registro de {tipo} salvo com sucesso às {dataHora:HH:mm:ss}!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar registro: " + ex.Message);
                TryLog("RegistrarPonto", ex);
            }
        }

        private void btnFiltrar_Click(object? sender, EventArgs e)
        {
            DateTime inicio = dtInicio.Value.Date;
            DateTime fim = dtFim.Value.Date.AddDays(1).AddSeconds(-1);

            if (string.IsNullOrEmpty(cpfSomenteDigitos))
            {
                MessageBox.Show("CPF inválido para filtro.");
                return;
            }

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string query = @"
                        SELECT rp.Id, f.CPF, f.Nome AS NomeFuncionario, rp.Tipo, rp.DataHora
                        FROM RegistrosPonto rp
                        JOIN Funcionarios f ON f.Id = rp.FuncionarioId
                        WHERE REPLACE(REPLACE(REPLACE(f.CPF, '.', ''), '-', ''), ' ', '') = @cpf
                          AND rp.DataHora BETWEEN @inicio AND @fim
                        ORDER BY rp.DataHora;";

                    using (var comando = new SQLiteCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@cpf", cpfSomenteDigitos);
                        comando.Parameters.AddWithValue("@inicio", inicio.ToString("yyyy-MM-dd HH:mm:ss"));
                        comando.Parameters.AddWithValue("@fim", fim.ToString("yyyy-MM-dd HH:mm:ss"));

                        var adaptador = new SQLiteDataAdapter(comando);
                        var tabela = new DataTable();
                        adaptador.Fill(tabela);

                        dgvHistorico.DataSource = tabela;
                        if (dgvHistorico.Columns.Contains("DataHora"))
                            dgvHistorico.Columns["DataHora"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar registros: " + ex.Message);
                TryLog("FiltrarPonto", ex);
            }
        }

        private void TryLog(string tag, Exception ex)
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_ponto.txt");
                File.AppendAllText(logPath, DateTime.Now.ToString("s") + " -> " + tag + ": " + ex.ToString() + Environment.NewLine);
            }
            catch { }
        }
    }
}

