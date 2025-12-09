using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuRH
{
    public partial class MenuMedico : BaseForm
    {
        public static string NomeMed = "";
        private string cpfMedico;
        private string cpfSomenteDigitos;
        private string nomeMedico;

        public MenuMedico(string cpf, string nome)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; 
            }

            InitializeComponent();
            DefinirPainelCentral(panelMedico);

            cpfMedico = cpf ?? "";
            cpfSomenteDigitos = new string(cpfMedico.Where(char.IsDigit).ToArray());
            nomeMedico = nome ?? "";

            NomeMed = nomeMedico;


            btnApontar.Click += btnApontar_Click;
            btnSair.Click += btnSair_Click;
            btnPeriodico.Click += btnPeriodico_Click;
            dgvAtestados.CellContentClick -= dgvAtestados_CellContentClick;
            dgvAtestados.CellContentClick += dgvAtestados_CellContentClick;

            this.Load += MenuMedico_Load;
        }

        private void CentralizarPainel()
        {
            panelMedico.Location = new Point(
                (this.ClientSize.Width - panelMedico.Width) / 2,
                (this.ClientSize.Height - panelMedico.Height) / 2
            );
        }

        private void MenuMedico_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(nomeMedico))
            {
                lblSaudacaoMedico.Text = $"Olá, {nomeMedico}!";
            }
            else
            {
                lblSaudacaoMedico.Text = "Olá, Médico!";
            }
        }

        

        private void CarregarAtestados()
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string query = @"
                SELECT 
                    CPF,
                    Id,
                    FuncionarioId,
                    NomeFuncionario,                                 
                    DataAtestado,
                    DiasAfastado,
                    CaminhoArquivo,
                    Status,
                    Notificado
                FROM Atestados
                WHERE (Status IS NULL OR Status = '' OR Status = 'Pendente');
            ";

                    var adaptador = new SQLiteDataAdapter(query, conexao);
                    var tabela = new DataTable();
                    adaptador.Fill(tabela);
                    dgvAtestados.DataSource = tabela;

                    dgvAtestados.ReadOnly = true;
                    dgvAtestados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    AdicionarColunasDeAcao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar atestados: " + ex.Message);
            }
        }

        private void AdicionarColunasDeAcao()
        {
            if (dgvAtestados.Columns.Contains("btnAbrirArquivo"))
                dgvAtestados.Columns.Remove("btnAbrirArquivo");
            if (dgvAtestados.Columns.Contains("btnAceitar"))
                dgvAtestados.Columns.Remove("btnAceitar");
            if (dgvAtestados.Columns.Contains("btnRecusar"))
                dgvAtestados.Columns.Remove("btnRecusar");

            var btnAbrir = new DataGridViewButtonColumn
            {
                Name = "btnAbrirArquivo",
                HeaderText = "Arquivo",
                Text = "Abrir",
                UseColumnTextForButtonValue = true
            };
            dgvAtestados.Columns.Add(btnAbrir);

            var btnAceitar = new DataGridViewButtonColumn
            {
                Name = "btnAceitar",
                HeaderText = "Aceitar",
                Text = "✔ Aceitar",
                UseColumnTextForButtonValue = true
            };
            dgvAtestados.Columns.Add(btnAceitar);

            var btnRecusar = new DataGridViewButtonColumn
            {
                Name = "btnRecusar",
                HeaderText = "Recusar",
                Text = "✖ Recusar",
                UseColumnTextForButtonValue = true
            };
            dgvAtestados.Columns.Add(btnRecusar);
        }

        private void dgvAtestados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var coluna = dgvAtestados.Columns[e.ColumnIndex].Name;
                var row = dgvAtestados.Rows[e.RowIndex];

                if (!int.TryParse(row.Cells["Id"].Value?.ToString(), out int idAtestado))
                {
                    MessageBox.Show("Id do atestado inválido.");
                    return;
                }

                if (coluna == "btnAceitar")
                {
                    var confirmar = MessageBox.Show("Deseja aceitar este atestado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmar == DialogResult.Yes)
                    {
                        AtualizarStatusAtestado(idAtestado, "Aceito");
                        MessageBox.Show("Atestado aceito com sucesso.");
                    }
                    CarregarAtestados();
                    return;
                }
                else if (coluna == "btnRecusar")
                {
                    var confirmar = MessageBox.Show("Deseja recusar este atestado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmar == DialogResult.Yes)
                    {
                        AtualizarStatusAtestado(idAtestado, "Recusado");
                        MessageBox.Show("Atestado recusado.");
                    }
                    CarregarAtestados();
                    return;
                }
                else if (coluna == "btnAbrirArquivo")
                {
                    AbrirBlob(idAtestado);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no processamento do atestado: " + ex.Message);
            }
        }

        private void AtualizarStatusAtestado(int id, string status)
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = @"
                UPDATE Atestados 
                SET Status = @status,
                    Notificado = 0
                WHERE Id = @id";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar status: " + ex.Message);
            }
        }

        private void AbrirBlob(int idAtestado)
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = "SELECT CaminhoArquivo FROM Atestados WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@id", idAtestado);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] blob = (byte[])reader["CaminhoArquivo"];
                                string extensao = DetectarExtensao(blob);
                                string tempPath = Path.Combine(Path.GetTempPath(), $"arquivo_{idAtestado}{extensao}");

                                File.WriteAllBytes(tempPath, blob);

                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = tempPath,
                                    UseShellExecute = true
                                });
                            }
                            else
                            {
                                MessageBox.Show("Arquivo não encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir arquivo BLOB: " + ex.Message);
            }
        }

        private string DetectarExtensao(byte[] blob)
        {
            if (blob.Length >= 4)
            {
                if (blob[0] == 0xFF && blob[1] == 0xD8) return ".jpg";
                if (blob[0] == 0x89 && blob[1] == 0x50 && blob[2] == 0x4E && blob[3] == 0x47) return ".png";
                if (blob[0] == 0x25 && blob[1] == 0x50 && blob[2] == 0x44 && blob[3] == 0x46) return ".pdf";
            }
            return ".bin";
        }

        private void btnApontar_Click(object? sender, EventArgs e)
        {
            var registro = new FormRegistro(cpfMedico, "Médico", nomeMedico);
            registro.Show();
            this.Hide();
        }

        private void btnPeriodico_Click(object sender, EventArgs e)
        {
            var periodico = new FormPeriodico(cpfMedico, nomeMedico);
            periodico.Show();
            this.Hide();
        }

        private void btnSair_Click(object? sender, EventArgs e)
        {
            try
            {
                FormLogin? login = null;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is FormLogin)
                    {
                        login = (FormLogin)f;
                        break;
                    }
                }

                if (login == null)
                {
                    login = new FormLogin();
                }

                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir tela de login: " + ex.Message);
                try
                {
                    string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_menu_medico.txt");
                    File.AppendAllText(logPath, DateTime.Now.ToString("s") + " -> btnSair_Click error: " + ex.ToString() + Environment.NewLine);
                }
                catch { }
            }
        }
    }
}
