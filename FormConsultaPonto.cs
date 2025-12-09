using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuRH
{
    public partial class FormConsultaPonto : BaseForm
    {
        private System.Windows.Forms.Timer buscaTimer;


        private bool _formatandoCpf = false;

        public FormConsultaPonto()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; 
            }

            InitializeComponent();

            DefinirPainelCentral(panelConsulta);

            buscaTimer = new System.Windows.Forms.Timer();
            buscaTimer.Interval = 400; 
            buscaTimer.Tick += BuscaTimer_Tick;

            
            txtNome.TextChanged += TxtNome_TextChanged;

            btnBuscar.Click += btnBuscar_Click;
        }
        private void TxtNome_TextChanged(object? sender, EventArgs e)
        {
            
            buscaTimer.Stop();
            buscaTimer.Start();
        }
        private void BuscaTimer_Tick(object? sender, EventArgs e)
        {
            buscaTimer.Stop();

            string texto = txtNome.Text.Trim();
            if (texto.Length < 3)
            {
                dgvPontos.DataSource = null; 
                return;
            }
            btnBuscar_Click(this, EventArgs.Empty);

        }


       

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            string re = txtNome.Text.Trim();

            DateTime inicio = dtInicio.Value.Date;
            DateTime fim = dtFim.Value.Date.AddDays(1);

            if (string.IsNullOrEmpty(re))
            {
                MessageBox.Show("Digite o nome do funcionário.");
                return;
            }

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                {
                    string sql = @"
                SELECT F.RE, F.Nome, F.CPF, RP.DataHora, RP.Tipo
                FROM RegistrosPonto RP
                JOIN Funcionarios F ON F.Id = RP.FuncionarioId
                WHERE F.Nome LIKE @nome COLLATE NOCASE
                  AND RP.DataHora BETWEEN @inicio AND @fim
                ORDER BY F.Nome, RP.DataHora DESC;";

                    using (var cmd = new System.Data.SQLite.SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", "%" + re + "%");
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fim", fim);

                        using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(cmd))
                        {
                            DataTable tabela = new DataTable();
                            adapter.Fill(tabela);
                            dgvPontos.DataSource = tabela;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar registros: " + ex.Message);
            }
        }
        private void btnVoltar_Click(object? sender, EventArgs e)
        {
            
            string cpfGestor = FormMenuGestor.CpfGestorGlobal;
            string nomeGestor = FormMenuGestor.NomeGestorGlobal;

            var menu = new FormMenuGestor(FormMenuGestor.CpfGestorGlobal, FormMenuGestor.NomeGestorGlobal);
            menu.Show();
            this.Hide(); 
        }

        private void CentralizarPainel()
        {
            panelConsulta.Location = new Point(
                (this.ClientSize.Width - panelConsulta.Width) / 2,
                (this.ClientSize.Height - panelConsulta.Height) / 2
            );
        }
    }
}

