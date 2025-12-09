using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace MeuRH
{
    public partial class FormAtualizarFuncionario : BaseForm
    {
        private bool _isEditing = false;
        private bool _formatandoCpf = false;
        private string _currentCpfDigits = null;
        private string _cpfCts;
        private BancoDados bd;

        public FormAtualizarFuncionario()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            InitializeComponent();

            bd = new BancoDados();
            DefinirPainelCentral(panelAtualizar);

            WireEvents();
            this.txtCPF.Leave += new EventHandler(this.txtCPF_Leave);
            this.txtCep.Leave += new System.EventHandler(this.txtCep_Leave);
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

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            string cpfDigits = new string(txtCPF.Text.Where(char.IsDigit).ToArray());

            if (cpfDigits.Length != 11)
                return;

            try
            {
                // usa uma nova instância local do BancoDados para esta operação de UI
                using (var conexao = new BancoDados().Conectar())
                {
                    string sql = @"
                SELECT nome, cpf, RE, data_nascimento, genero, telefone, email, cep, Numero, endereco,
                       periodico, inicio, entrada, saida, foto, cargo
                FROM funcionarios 
                WHERE REPLACE(REPLACE(REPLACE(cpf, '.', ''), '-', ''), ' ', '') = @cpf";

                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfDigits);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Marca que está editando e guarda o CPF limpo
                                _isEditing = true;
                                _currentCpfDigits = cpfDigits;

                                txtCargo.Text = reader["cargo"].ToString();
                                txtEndereco.Text = reader["endereco"].ToString();
                                dtAdmissao.Text = reader["inicio"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                dtNascimento.Text = reader["data_nascimento"].ToString();
                                cmbGenero.Text = reader["genero"].ToString();
                                txtEntrada.Text = reader["entrada"].ToString();
                                txtSaida.Text = reader["saida"].ToString();
                                txtNome.Text = reader["nome"].ToString();
                                txtNumero.Text = reader["Numero"].ToString();
                                cmbPeriodico.Text = reader["periodico"].ToString();
                                txtCep.Text = reader["cep"].ToString();
                                txtTelefone.Text = reader["telefone"].ToString();

                                // Se tiver foto, carregar bytes → imagem
                                if (reader["foto"] != DBNull.Value)
                                {
                                    byte[] imgBytes = (byte[])reader["foto"];
                                    using (var ms = new MemoryStream(imgBytes))
                                        pbFoto.Image = Image.FromStream(ms);
                                }
                                else
                                {
                                    pbFoto.Image = null;
                                }
                            }
                            else
                            {
                                _isEditing = false;
                                _currentCpfDigits = null;

                                MessageBox.Show("CPF não encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar o CPF: " + ex.Message);
            }
        }

        private string GetCpfDigits()
        {
            return txtCPF == null ? string.Empty : new string(txtCPF.Text.Where(char.IsDigit).ToArray());
        }

        private bool IsValidCpf(string digits)
        {
            if (string.IsNullOrEmpty(digits) || digits.Length != 11) return false;
            string[] invalids = {
                "00000000000","11111111111","22222222222","33333333333","44444444444",
                "55555555555","66666666666","77777777777","88888888888","99999999999"
            };
            if (invalids.Contains(digits)) return false;

            int[] nums = digits.Select(c => c - '0').ToArray();

            int sum = 0;
            for (int i = 0; i < 9; i++) sum += nums[i] * (10 - i);
            int rem = sum % 11;
            int dv1 = rem < 2 ? 0 : 11 - rem;
            if (nums[9] != dv1) return false;

            sum = 0;
            for (int i = 0; i < 10; i++) sum += nums[i] * (11 - i);
            rem = sum % 11;
            int dv2 = rem < 2 ? 0 : 11 - rem;
            if (nums[10] != dv2) return false;

            return true;
        }

        private async Task LoadEmployeeByCpfAsync(string cpfDigits)
        {
            MessageBox.Show("CPF enviado para consulta: " + cpfDigits);

            try
            {
                var found = await Task.Run(() =>
                {
                    // cria e usa conexão dentro da thread de trabalho
                    using (var conn = new BancoDados().Conectar())
                    using (var cmd = new SQLiteCommand(
                        "SELECT * FROM funcionarios WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @cpf", conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfDigits);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var dto = new
                                {
                                    Nome = reader["nome"]?.ToString(),
                                    RE = reader["RE"]?.ToString(),
                                    Cargo = reader["cargo"]?.ToString(),
                                    Email = reader["email"]?.ToString(),
                                    Endereco = reader["endereco"]?.ToString(),
                                    Numero = reader["Numero"]?.ToString(),
                                    Entrada = reader["entrada"]?.ToString(),
                                    Saida = reader["saida"]?.ToString(),
                                    Genero = reader["genero"]?.ToString(),
                                    Periodico = reader["periodico"]?.ToString(),
                                    Telefone = reader["telefone"]?.ToString(),
                                    Cep = reader["cep"]?.ToString(),
                                    DataNascimento = reader["data_nascimento"]?.ToString(),
                                    Inicio = reader["inicio"]?.ToString(),
                                    Foto = reader["foto"] == DBNull.Value ? null : (byte[])reader["foto"]
                                };
                                return dto;
                            }
                        }
                    }
                    return null;
                });

                if (found != null)
                {
                    this.Invoke(new Action(() =>
                    {
                        txtNome.Text = found.Nome ?? "";
                        txtRE.Text = found.RE ?? "";
                        txtCargo.Text = found.Cargo ?? "";
                        txtEmail.Text = found.Email ?? "";
                        txtEndereco.Text = found.Endereco ?? "";
                        txtNumero.Text = found.Numero ?? "";
                        txtEntrada.Text = found.Entrada ?? "";
                        txtSaida.Text = found.Saida ?? "";
                        cmbGenero.SelectedItem = found.Genero != null && cmbGenero.Items.Contains(found.Genero) ? found.Genero : (object)null;
                        cmbPeriodico.SelectedItem = found.Periodico != null && cmbPeriodico.Items.Contains(found.Periodico) ? found.Periodico : (object)null;
                        txtTelefone.Text = found.Telefone ?? "";
                        txtCep.Text = found.Cep ?? "";

                        if (DateTime.TryParse(found.DataNascimento, out DateTime nasc))
                            dtNascimento.Value = nasc;
                        if (DateTime.TryParse(found.Inicio, out DateTime inicio))
                            dtAdmissao.Value = inicio;

                        if (found.Foto != null)
                        {
                            using (var ms = new MemoryStream(found.Foto))
                                pbFoto.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pbFoto.Image = null;
                        }

                        txtCPF.ReadOnly = true;
                        txtRE.ReadOnly = true;

                        _isEditing = true;
                        _currentCpfDigits = cpfDigits;
                        btnSalvar.Text = "ATUALIZAR";
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("CPF não cadastrado.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFieldsExceptCpfAndRe();
                        _isEditing = false;
                        _currentCpfDigits = null;
                        btnSalvar.Text = "SALVAR";
                        txtCPF.ReadOnly = false;
                        txtRE.ReadOnly = false;
                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Erro ao consultar o banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void ClearFormFieldsExceptCpfAndRe()
        {
            txtNome.Clear();
            txtCargo.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtEntrada.Clear();
            txtSaida.Clear();
            cmbGenero.SelectedIndex = -1;
            cmbPeriodico.SelectedIndex = -1;
            txtTelefone.Clear();
            txtCep.Clear();
            pbFoto.Image = null;
            dtNascimento.Value = DateTime.Today;
            dtAdmissao.Value = DateTime.Today;
        }

        private void WireEvents()
        {
            txtCPF.Leave -= txtCPF_Leave;
            txtCPF.Leave += txtCPF_Leave;

            txtCPF.TextChanged -= TxtCPF_TextChanged;
            txtCPF.TextChanged += TxtCPF_TextChanged;

            txtCPF.KeyPress -= TxtCPF_KeyPress;
            txtCPF.KeyPress += TxtCPF_KeyPress;

            btnSalvar.Click -= btnSalvar_Click;
            btnSalvar.Click += btnSalvar_Click;

            btnSelecionarFoto.Click -= btnSelecionarFoto_Click;
            btnSelecionarFoto.Click += btnSelecionarFoto_Click;

            btnVoltar1.Click -= btnVoltar1_Click;
            btnVoltar1.Click += btnVoltar1_Click;

            btnExcluir.Click -= btnExcluir_Click;
            btnExcluir.Click += btnExcluir_Click;
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Trim();

            if (string.IsNullOrEmpty(cep))
                return;

            try
            {
                using (var conexao = new BancoDados().Conectar())
                {
                    string sql = @"SELECT endereco, bairro, cidade, uf FROM tb_cep WHERE cep = @cep";
                    using (var cmd = new SQLiteCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cep", cep);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEndereco.Text = reader["endereco"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("CEP não encontrado.");
                                txtEndereco.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar o CEP: " + ex.Message);
            }
        }

        private void CentralizarPainel()
        {
            panelAtualizar.Location = new Point(
                (this.ClientSize.Width - panelAtualizar.Width) / 2,
                (this.ClientSize.Height - panelAtualizar.Height) / 2
            );
        }

        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            var img = Image.FromStream(fs);
                            pbFoto.Image = new Bitmap(img);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!_isEditing || string.IsNullOrEmpty(_currentCpfDigits))
            {
                MessageBox.Show("Nenhum funcionário carregado para atualização.");
                return;
            }

            var confirm = MessageBox.Show("Deseja salvar as alterações?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string nome = txtNome.Text.Trim();
            string cargo = txtCargo.Text.Trim();
            string email = txtEmail.Text.Trim();
            string endereco = txtEndereco.Text.Trim();
            string numero = txtNumero.Text.Trim();
            string entrada = txtEntrada.Text.Trim();
            string saida = txtSaida.Text.Trim();
            string genero = cmbGenero.Text;
            string periodico = cmbPeriodico.Text;
            string nascimento = dtNascimento.Value.ToString("yyyy-MM-dd");
            string admissao = dtAdmissao.Value.ToString("yyyy-MM-dd");
            string telefone = txtTelefone.Text.Trim();
            string cep = txtCep.Text.Trim();
            string cpf = _currentCpfDigits;

            byte[] foto = ImageToBytes(pbFoto.Image);

            try
            {
                await Task.Run(() =>
                {
                    using (var conn = bd.Conectar())
                    using (var cmd = new SQLiteCommand(@"
                            UPDATE funcionarios SET
                                nome = @Nome,
                                cargo = @Cargo,
                                email = @Email,
                                endereco = @Endereco,
                                Numero = @Numero,
                                entrada = @Entrada,
                                saida = @Saida,
                                genero = @Genero,
                                periodico = @Periodico,
                                data_nascimento = @Nascimento,
                                inicio = @Admissao,
                                telefone = @Telefone,
                                cep = @CEP,
                                foto = @Foto
                            WHERE REPLACE(REPLACE(REPLACE(CPF, '.', ''), '-', ''), ' ', '') = @CPF", conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Cargo", cargo);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Endereco", endereco);
                        cmd.Parameters.AddWithValue("@Numero", numero);
                        cmd.Parameters.AddWithValue("@Entrada", entrada);
                        cmd.Parameters.AddWithValue("@Saida", saida);
                        cmd.Parameters.AddWithValue("@Genero", genero);
                        cmd.Parameters.AddWithValue("@Periodico", periodico);
                        cmd.Parameters.AddWithValue("@Nascimento", nascimento);
                        cmd.Parameters.AddWithValue("@Admissao", admissao);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@CEP", cep);

                        if (foto != null)
                            cmd.Parameters.AddWithValue("@Foto", foto);
                        else
                            cmd.Parameters.AddWithValue("@Foto", DBNull.Value);

                        cmd.Parameters.AddWithValue("@CPF", cpf);

                        int rows = cmd.ExecuteNonQuery();

                        this.Invoke(new Action(() =>
                        {
                            if (rows > 0)
                                MessageBox.Show("Funcionário atualizado com sucesso.");
                            else
                                MessageBox.Show("Nenhuma alteração realizada.");
                        }));
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        private byte[]? ImageToBytes(Image? img)
        {
            if (img == null) return null;

            try
            {
                using (var clone = new Bitmap(img))
                using (var ms = new MemoryStream())
                {

                    clone.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!_isEditing || string.IsNullOrEmpty(_currentCpfDigits))
            {
                MessageBox.Show("Nenhum funcionário carregado para exclusão.");
                return;
            }

            var confirm = MessageBox.Show(
                "Tem certeza que deseja excluir este funcionário? Esta ação não pode ser desfeita.",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                await Task.Run(() =>
                {
                    using (var conn = bd.Conectar())
                    using (var cmd = new SQLiteCommand(@"
                DELETE FROM funcionarios 
                WHERE REPLACE(REPLACE(REPLACE(cpf, '.', ''), '-', ''), ' ', '') = @CPF
            ", conn))
                    {
                        cmd.Parameters.AddWithValue("@CPF", _currentCpfDigits);

                        int rows = cmd.ExecuteNonQuery();

                        this.Invoke(new Action(() =>
                        {
                            if (rows > 0)
                            {
                                MessageBox.Show("Funcionário excluído com sucesso.");

                                txtCPF.ReadOnly = false;
                                txtRE.ReadOnly = false;
                                txtCPF.Clear();
                                ClearFormFieldsExceptCpfAndRe();
                                pbFoto.Image = null;

                                _isEditing = false;
                                _currentCpfDigits = null;
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído.");
                            }
                        }));
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar1_Click(object sender, EventArgs e)
        {
            var menu = new FormMenuGestor(FormMenuGestor.CpfGestorGlobal, FormMenuGestor.NomeGestorGlobal);
            menu.Show();
            this.Hide();
        }
    }
}

