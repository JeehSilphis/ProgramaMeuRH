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
    public partial class FormAtestado : BaseForm
    {
        private string cpfFuncionario;
        private string caminhoAnexo = "";
        private string nomeUsuario;
        private string cargoUsuario;


        public FormAtestado(string cpf, string cargo, string nome)
        {

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            InitializeComponent();
            DefinirPainelCentral(panelAtestado);

            cpfFuncionario = cpf ?? "";
            nomeUsuario = nome ?? "";
            cargoUsuario = cargo ?? "";


            btnAnexar.Click -= btnAnexar_Click;
            btnAnexar.Click += btnAnexar_Click;

            btnVoltar.Click -= btnVoltar_Click;
            btnVoltar.Click += btnVoltar_Click;

            btnSalvar.Click -= btnSalvar_Click;
            btnSalvar.Click += btnSalvar_Click;

            numDias.Enabled = true;
            dtAtestado.Enabled = true;
        }

  
        public FormAtestado() : this("", "", "") { }


        private void CentralizarPainel()
        {
            panelAtestado.Location = new Point(
                (this.ClientSize.Width - panelAtestado.Width) / 2,
                (this.ClientSize.Height - panelAtestado.Height) / 2
            );
        }
        private void btnAnexar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog
            {
                Title = "Selecionar Atestado",
                Filter = "PDF ou Imagens|*.pdf;*.jpg;*.jpeg;*.png"
            };

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                caminhoAnexo = dialogo.FileName;
                MessageBox.Show("Arquivo anexado:\n" + caminhoAnexo);

                if (Path.GetExtension(caminhoAnexo).ToLower() != ".pdf")
                {
                    try
                    {
                        Image imagem = Image.FromFile(caminhoAnexo);
                        pictureBoxAtestado.Image = imagem;
                        pictureBoxAtestado.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar imagem: " + ex.Message);
                    }
                }
                else
                {
                    pictureBoxAtestado.Image = null;
                    MessageBox.Show("PDF anexado (não exibido).");
                }
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(caminhoAnexo))
            {
                MessageBox.Show("Selecione o arquivo do atestado.");
                return;
            }

            DateTime data = dtAtestado.Value.Date;
            int dias = (int)numDias.Value;

            byte[] arquivoBytes;

            try
            {
                arquivoBytes = File.ReadAllBytes(caminhoAnexo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler arquivo: " + ex.Message);
                return;
            }

            try
            {
                BancoDados bd = new BancoDados();
                using (var conexao = bd.Conectar())
                using (var transaction = conexao.BeginTransaction())
                {
                    long funcionarioId;
                    string cpfLimpo = new string(cpfFuncionario.Where(char.IsDigit).ToArray());

                  
                    using (var cmdBusca = new SQLiteCommand(
                        "SELECT Id FROM Funcionarios WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf LIMIT 1;",
                        conexao, transaction))
                    {
                        cmdBusca.Parameters.AddWithValue("@cpf", cpfLimpo);
                        var obj = cmdBusca.ExecuteScalar();
                        if (obj == null)
                        {
                            MessageBox.Show("Funcionário não encontrado.");
                            return;
                        }
                        funcionarioId = Convert.ToInt64(obj);
                    }

                    
                    string nomeFuncionario = "";
                    using (var cmdNome = new SQLiteCommand(
                        "SELECT Nome FROM Funcionarios WHERE Id = @id LIMIT 1;",
                        conexao, transaction))
                    {
                        cmdNome.Parameters.AddWithValue("@id", funcionarioId);
                        nomeFuncionario = cmdNome.ExecuteScalar()?.ToString() ?? "";
                    }

                
                    string query = @"
                                INSERT INTO Atestados
                                (CPF, FuncionarioId, NomeFuncionario, DataAtestado, DiasAfastado, CaminhoArquivo)
                                VALUES (@cpf, @id, @nomeFuncionario, @data, @dias, @arquivo);
                            ";

                    using (var comando = new SQLiteCommand(query, conexao, transaction))
                    {
                        comando.Parameters.AddWithValue("@cpf", cpfFuncionario);
                        comando.Parameters.AddWithValue("@id", funcionarioId);
                        comando.Parameters.AddWithValue("@nomeFuncionario", nomeFuncionario);
                        comando.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                        comando.Parameters.AddWithValue("@dias", dias);
                        comando.Parameters.Add("@arquivo", DbType.Binary).Value = arquivoBytes;

                        comando.ExecuteNonQuery();
                    }


                    transaction.Commit();
                }

                lblStatus.Text = "✅ Atestado enviado com sucesso. Está em análise.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar atestado: " + ex.Message);

                try
                {
                    string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_atestados.txt");
                    File.AppendAllText(logPath, $"{DateTime.Now:s} → Erro SALVAR ATESTADO: {ex}\n");
                }
                catch { }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (cargoUsuario == "Gestor")
            {
                new FormMenuGestor(cpfFuncionario, nomeUsuario).Show();
            }
            else if (cargoUsuario == "Médico")
            {
                new MenuMedico(cpfFuncionario, nomeUsuario).Show();
            }
            else
            {
                new FormMenuFuncionario(cpfFuncionario).Show();
            }

            this.Hide();
        }
    }
}