using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuRH
{
    public partial class FormPeriodico : BaseForm
    {
        private string cpfFuncionario;
        private string nomeFuncionario;

        public FormPeriodico(string cpf, string nome)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; 
            }
            InitializeComponent();
            DefinirPainelCentral(panelPeriodico);

            cpfFuncionario = cpf;
            nomeFuncionario = nome ?? "";

            btnVoltar.Click -= BtnVoltar_Click;
            btnVoltar.Click += BtnVoltar_Click;

            dgvPeriodico.CellClick -= dgvPeriodico_CellClick;
            dgvPeriodico.CellClick += dgvPeriodico_CellClick;

            CarregarFuncionariosPeriodico();
        }

        private void CentralizarPainel()
        {
            panelPeriodico.Location = new Point(
                (this.ClientSize.Width - panelPeriodico.Width) / 2,
                (this.ClientSize.Height - panelPeriodico.Height) / 2
            );
        }

        private void BtnVoltar_Click(object? sender, EventArgs e)
        {
            var menu = new MenuMedico(cpfFuncionario, nomeFuncionario);
            menu.Show();
            this.Hide();
        }

        private void CarregarFuncionariosPeriodico()
        {
            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string query = @"
                        SELECT 
                            Id,
                            CPF,
                            RE,
                            Nome,
                            data_nascimento,
                            Periodico,
                            convocacao,
                            Inicio,
                            Confirmado
                        FROM Funcionarios
                        WHERE strftime('%m', Inicio) = strftime('%m', 'now');
                    ";

                    var adaptador = new SQLiteDataAdapter(query, conexao);
                    var tabela = new DataTable();
                    adaptador.Fill(tabela);
                    dgvPeriodico.DataSource = tabela;

                    dgvPeriodico.ReadOnly = true;
                    dgvPeriodico.AllowUserToAddRows = false;
                    dgvPeriodico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    AdicionarBotaoConvocar();
                    ColorirLinhas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void AdicionarBotaoConvocar()
        {
            if (!dgvPeriodico.Columns.Contains("btnConvocar"))
            {
                var btnConvocar = new DataGridViewButtonColumn();
                btnConvocar.Name = "btnConvocar";
                btnConvocar.HeaderText = "Ação";
                btnConvocar.Text = "Convocar";
                btnConvocar.UseColumnTextForButtonValue = true;
                dgvPeriodico.Columns.Add(btnConvocar);

                dgvPeriodico.Columns["Confirmado"].HeaderText = "Confirmado pelo Funcionário";
            }
        }

        private void dgvPeriodico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var coluna = dgvPeriodico.Columns[e.ColumnIndex].Name;
            var row = dgvPeriodico.Rows[e.RowIndex];

            if (coluna == "btnConvocar")
            {
                string cpf = row.Cells["CPF"].Value?.ToString() ?? "";
                string nome = row.Cells["Nome"].Value?.ToString() ?? "";

                if (!string.IsNullOrEmpty(cpf))
                {
                    SalvarConvocacao(cpf);

                    MessageBox.Show(
                        $"Funcionário {nome} foi convocado para o exame periódico.",
                        "Confirmação de Convocação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    CarregarFuncionariosPeriodico();
                }
            }
        }

        private void SalvarConvocacao(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                   

                    string sql = @"
                        UPDATE Funcionarios
                        SET Periodico = 'Convocado',
                            convocacao = 'ok',
                            Inicio = CURRENT_DATE
                        WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf;
                    ";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar convocação: " + ex.Message);
            }
        }

        private void ColorirLinhas()
        {
            foreach (DataGridViewRow row in dgvPeriodico.Rows)
            {
                var status = row.Cells["Periodico"].Value?.ToString()?.Trim();

                if (status == "Convocado")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }
    }
}

