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
    public partial class FormLogin : BaseForm
    {
        private bool _formatandoCpf = false;

        public FormLogin()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            InitializeComponent();

            DefinirPainelCentral(panelLogin);

            txtCPF.KeyPress += TxtCPF_KeyPress;
            txtCPF.TextChanged += TxtCPF_TextChanged;
            txtCPF.Leave += TxtCPF_Leave;

            btnEntrar.Click -= btnEntrar_Click;
            btnEntrar.Click += btnEntrar_Click;
        }

        private void CentralizarPainel()
        {
            panelLogin.Location = new Point(
                (this.ClientSize.Width - panelLogin.Width) / 2,
                (this.ClientSize.Height - panelLogin.Height) / 2
            );
        }

        private void TxtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtCPF_TextChanged(object sender, EventArgs e)
        {
            if (_formatandoCpf) return;
            _formatandoCpf = true;

            string digits = new string(txtCPF.Text.Where(char.IsDigit).ToArray());
            if (digits.Length > 11) digits = digits.Substring(0, 11);

            if (digits.Length <= 3)
                txtCPF.Text = digits;
            else if (digits.Length <= 6)
                txtCPF.Text = $"{digits.Substring(0, 3)}.{digits.Substring(3)}";
            else if (digits.Length <= 9)
                txtCPF.Text = $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6)}";
            else
                txtCPF.Text = $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6, 3)}-{digits.Substring(9)}";

            txtCPF.SelectionStart = txtCPF.Text.Length;
            _formatandoCpf = false;
        }

        private void TxtCPF_Leave(object sender, EventArgs e)
        {
            string digits = GetCpfDigits();
            if (string.IsNullOrEmpty(digits)) return;
            if (digits.Length < 11) return;

            txtCPF.Text = $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6, 3)}-{digits.Substring(9)}";
        }

        private string GetCpfDigits()
        {
            if (txtCPF == null) return "";
            return new string(txtCPF.Text.Where(char.IsDigit).ToArray());
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string cpfDigits = GetCpfDigits();
            string re = txtRE.Text.Trim().PadLeft(3, '0');

            if (cpfDigits.Length != 11 || string.IsNullOrEmpty(re))
            {
                MessageBox.Show("Preencha CPF (11 dígitos) e RE.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (cpfDigits.Length != 11) txtCPF.Focus();
                return;
            }

            SQLiteConnection conexao = null;
            try
            {
                BancoDados bd = new BancoDados();

                // Mostra onde o banco está sendo acessado (útil para debug)
                // MessageBox.Show($"Conectando ao banco em:\n{bd.CaminhoBanco}", "Debug");

                conexao = bd.Conectar();

                string query = @"
                SELECT *
                FROM Funcionarios
                WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf
                  AND RE = @re
                LIMIT 1;
            ";

                using (var comando = new SQLiteCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpfDigits);
                    comando.Parameters.AddWithValue("@re", re);

                    using (var leitor = comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            string nome = leitor["Nome"] as string ?? "";
                            string cargo = leitor["Cargo"] as string ?? "";
                            string cpfBanco = leitor["CPF"]?.ToString()?.Replace(".", "").Replace("-", "").Replace(" ", "") ?? cpfDigits;

                            MessageBox.Show($"Bem-vindo(a), {nome}!", "Login Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (cargo == "Gestor")
                            {
                                var gestorMenu = new FormMenuGestor(leitor["CPF"]?.ToString() ?? txtCPF.Text, nome);
                                gestorMenu.Show();
                            }
                            else if (cargo == "Médico")
                            {
                                var menuMedico = new MenuMedico(leitor["CPF"]?.ToString() ?? txtCPF.Text, nome);
                                menuMedico.Show();
                            }
                            else
                            {
                                var funcionarioMenu = new FormMenuFuncionario(leitor["CPF"]?.ToString() ?? txtCPF.Text);
                                funcionarioMenu.Show();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("CPF ou RE inválidos.\n\nVerifique os dados e tente novamente.", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Banco de dados não encontrado:\n\n{ex.Message}", "Erro de Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Erro no banco de dados SQLite:\n\n{ex.Message}\n\nCódigo: {ex.ErrorCode}", "Erro SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Sem permissão para acessar o banco de dados:\n\n{ex.Message}\n\nExecute como administrador ou verifique as permissões.", "Erro de Permissão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar:\n\n{ex.Message}\n\n{ex.GetType().Name}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao?.Close();
                conexao?.Dispose();
            }
        }
    }
}
