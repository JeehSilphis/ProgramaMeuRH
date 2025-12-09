using System.Drawing;
using System.Windows.Forms;

namespace MeuRH
{
    partial class FormCadastroFuncionario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroFuncionario));
            this.panelCadastrar = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.cmbPeriodico = new System.Windows.Forms.ComboBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnVoltar1 = new System.Windows.Forms.Button();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtAdmissao = new System.Windows.Forms.DateTimePicker();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNascimento = new System.Windows.Forms.DateTimePicker();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaida = new System.Windows.Forms.TextBox();
            this.btnSelecionarFoto = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panelCadastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCadastrar
            // 
            this.panelCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.panelCadastrar.Controls.Add(this.label16);
            this.panelCadastrar.Controls.Add(this.txtTelefone);
            this.panelCadastrar.Controls.Add(this.cmbPeriodico);
            this.panelCadastrar.Controls.Add(this.txtCep);
            this.panelCadastrar.Controls.Add(this.label15);
            this.panelCadastrar.Controls.Add(this.txtNumero);
            this.panelCadastrar.Controls.Add(this.btnVoltar1);
            this.panelCadastrar.Controls.Add(this.txtCargo);
            this.panelCadastrar.Controls.Add(this.label4);
            this.panelCadastrar.Controls.Add(this.txtCPF);
            this.panelCadastrar.Controls.Add(this.label1);
            this.panelCadastrar.Controls.Add(this.label7);
            this.panelCadastrar.Controls.Add(this.dtAdmissao);
            this.panelCadastrar.Controls.Add(this.pbFoto);
            this.panelCadastrar.Controls.Add(this.label9);
            this.panelCadastrar.Controls.Add(this.label8);
            this.panelCadastrar.Controls.Add(this.txtEmail);
            this.panelCadastrar.Controls.Add(this.label11);
            this.panelCadastrar.Controls.Add(this.label5);
            this.panelCadastrar.Controls.Add(this.dtNascimento);
            this.panelCadastrar.Controls.Add(this.cmbGenero);
            this.panelCadastrar.Controls.Add(this.label12);
            this.panelCadastrar.Controls.Add(this.label13);
            this.panelCadastrar.Controls.Add(this.txtEntrada);
            this.panelCadastrar.Controls.Add(this.label14);
            this.panelCadastrar.Controls.Add(this.txtEndereco);
            this.panelCadastrar.Controls.Add(this.label10);
            this.panelCadastrar.Controls.Add(this.label6);
            this.panelCadastrar.Controls.Add(this.txtRE);
            this.panelCadastrar.Controls.Add(this.label2);
            this.panelCadastrar.Controls.Add(this.txtSaida);
            this.panelCadastrar.Controls.Add(this.btnSelecionarFoto);
            this.panelCadastrar.Controls.Add(this.txtNome);
            this.panelCadastrar.Controls.Add(this.label3);
            this.panelCadastrar.Controls.Add(this.btnSalvar);
            this.panelCadastrar.Location = new System.Drawing.Point(129, 41);
            this.panelCadastrar.Name = "panelCadastrar";
            this.panelCadastrar.Size = new System.Drawing.Size(782, 598);
            this.panelCadastrar.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(142, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(497, 37);
            this.label16.TabIndex = 76;
            this.label16.Text = "CADASTRO DE FUNCIONÁRIOS";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(565, 468);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(164, 20);
            this.txtTelefone.TabIndex = 74;
            // 
            // cmbPeriodico
            // 
            this.cmbPeriodico.FormattingEnabled = true;
            this.cmbPeriodico.Items.AddRange(new object[] {
            "Semestral",
            "Anual"});
            this.cmbPeriodico.Location = new System.Drawing.Point(565, 330);
            this.cmbPeriodico.Name = "cmbPeriodico";
            this.cmbPeriodico.Size = new System.Drawing.Size(164, 21);
            this.cmbPeriodico.TabIndex = 73;
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(46, 397);
            this.txtCep.Mask = "00000-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(76, 20);
            this.txtCep.TabIndex = 72;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(145, 379);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 18);
            this.label15.TabIndex = 70;
            this.label15.Text = "NÚMERO";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(145, 397);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(68, 20);
            this.txtNumero.TabIndex = 71;
            // 
            // btnVoltar1
            // 
            this.btnVoltar1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoltar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVoltar1.Location = new System.Drawing.Point(565, 532);
            this.btnVoltar1.Name = "btnVoltar1";
            this.btnVoltar1.Size = new System.Drawing.Size(164, 28);
            this.btnVoltar1.TabIndex = 51;
            this.btnVoltar1.Text = "VOLTAR";
            this.btnVoltar1.UseVisualStyleBackColor = true;
            this.btnVoltar1.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(46, 266);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(164, 20);
            this.txtCargo.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(46, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "CARGO";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(46, 195);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(164, 20);
            this.txtCPF.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(46, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "CPF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(305, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 18);
            this.label7.TabIndex = 54;
            this.label7.Text = "DATA DE ADMISSÃO";
            // 
            // dtAdmissao
            // 
            this.dtAdmissao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAdmissao.Location = new System.Drawing.Point(305, 266);
            this.dtAdmissao.Name = "dtAdmissao";
            this.dtAdmissao.Size = new System.Drawing.Size(164, 22);
            this.dtAdmissao.TabIndex = 53;
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.Color.White;
            this.pbFoto.Location = new System.Drawing.Point(580, 127);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(126, 158);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 49;
            this.pbFoto.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(46, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 18);
            this.label9.TabIndex = 57;
            this.label9.Text = "CEP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(565, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 18);
            this.label8.TabIndex = 55;
            this.label8.Text = "TELEFONE";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(565, 397);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(565, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 61;
            this.label11.Text = "EMAIL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(303, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "DATA DE NASCIMENTO";
            // 
            // dtNascimento
            // 
            this.dtNascimento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNascimento.Location = new System.Drawing.Point(305, 330);
            this.dtNascimento.Name = "dtNascimento";
            this.dtNascimento.Size = new System.Drawing.Size(164, 22);
            this.dtNascimento.TabIndex = 47;
            // 
            // cmbGenero
            // 
            this.cmbGenero.AllowDrop = true;
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Feminino",
            "Masculino"});
            this.cmbGenero.Location = new System.Drawing.Point(46, 330);
            this.cmbGenero.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(164, 21);
            this.cmbGenero.TabIndex = 69;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(565, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 18);
            this.label12.TabIndex = 67;
            this.label12.Text = "PERIÓDICO";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(303, 451);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 18);
            this.label13.TabIndex = 65;
            this.label13.Text = "HORÁRIO DE SAIDA";
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(46, 468);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(164, 20);
            this.txtEntrada.TabIndex = 64;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(46, 451);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(178, 18);
            this.label14.TabIndex = 63;
            this.label14.Text = "HORÁRIO DE ENTRADA";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(303, 397);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(164, 20);
            this.txtEndereco.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(303, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 18);
            this.label10.TabIndex = 59;
            this.label10.Text = "ENDEREÇO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(46, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 18);
            this.label6.TabIndex = 52;
            this.label6.Text = "GÊNERO";
            // 
            // txtRE
            // 
            this.txtRE.Location = new System.Drawing.Point(305, 195);
            this.txtRE.Name = "txtRE";
            this.txtRE.Size = new System.Drawing.Size(164, 20);
            this.txtRE.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(305, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 40;
            this.label2.Text = "RE";
            // 
            // txtSaida
            // 
            this.txtSaida.Location = new System.Drawing.Point(303, 468);
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.Size = new System.Drawing.Size(164, 20);
            this.txtSaida.TabIndex = 66;
            // 
            // btnSelecionarFoto
            // 
            this.btnSelecionarFoto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSelecionarFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSelecionarFoto.Location = new System.Drawing.Point(46, 532);
            this.btnSelecionarFoto.Name = "btnSelecionarFoto";
            this.btnSelecionarFoto.Size = new System.Drawing.Size(164, 28);
            this.btnSelecionarFoto.TabIndex = 50;
            this.btnSelecionarFoto.Text = "ANEXAR FOTO";
            this.btnSelecionarFoto.UseVisualStyleBackColor = true;
            this.btnSelecionarFoto.Click += new System.EventHandler(this.btnSelecionarFoto_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(46, 127);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(425, 20);
            this.txtNome.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(46, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 43;
            this.label3.Text = "NOME";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSalvar.Location = new System.Drawing.Point(303, 532);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(164, 28);
            this.btnSalvar.TabIndex = 42;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelCadastrar);
            this.MinimizeBox = false;
            this.Name = "FormCadastroFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Funcionário";
            this.panelCadastrar.ResumeLayout(false);
            this.panelCadastrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);

        }



        private Panel panelCadastrar;
        private Button btnVoltar1;
        private TextBox txtCargo;
        private Label label4;
        private TextBox txtCPF;
        private Label label1;
        private Label label7;
        private DateTimePicker dtAdmissao;
        private PictureBox pbFoto;
        private Label label9;
        private Label label8;
        private TextBox txtEmail;
        private Label label11;
        private Label label5;
        private DateTimePicker dtNascimento;
        private ComboBox cmbGenero;
        private Label label12;
        private Label label13;
        private TextBox txtEntrada;
        private Label label14;
        private TextBox txtEndereco;
        private Label label10;
        private Label label6;
        private TextBox txtRE;
        private Label label2;
        private TextBox txtSaida;
        private Button btnSelecionarFoto;
        private TextBox txtNome;
        private Label label3;
        private Button btnSalvar;
        private Label label15;
        private TextBox txtNumero;
        private ComboBox cmbPeriodico;
        private MaskedTextBox txtCep;
        private MaskedTextBox txtTelefone;
        private Label label16;
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
    }
}