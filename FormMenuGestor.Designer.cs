using System.Drawing;
using System.Windows.Forms;

namespace MeuRH
{
    partial class FormMenuGestor
    {
        /// <summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuGestor));
            this.panelGestor = new System.Windows.Forms.Panel();
            this.btnListar = new System.Windows.Forms.Button();
            this.lblBoasVindas = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.btnCadastroFuncionario = new System.Windows.Forms.Button();
            this.btnAtestado = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnApontar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panelGestor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGestor
            // 
            this.panelGestor.BackColor = System.Drawing.Color.Transparent;
            this.panelGestor.Controls.Add(this.btnListar);
            this.panelGestor.Controls.Add(this.lblBoasVindas);
            this.panelGestor.Controls.Add(this.labelTitulo);
            this.panelGestor.Controls.Add(this.btnCadastroFuncionario);
            this.panelGestor.Controls.Add(this.btnAtestado);
            this.panelGestor.Controls.Add(this.btnRelatorio);
            this.panelGestor.Controls.Add(this.btnConsultar);
            this.panelGestor.Controls.Add(this.btnApontar);
            this.panelGestor.Controls.Add(this.btnSair);
            this.panelGestor.Location = new System.Drawing.Point(213, 83);
            this.panelGestor.Name = "panelGestor";
            this.panelGestor.Size = new System.Drawing.Size(622, 556);
            this.panelGestor.TabIndex = 7;
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnListar.Location = new System.Drawing.Point(58, 327);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(209, 64);
            this.btnListar.TabIndex = 15;
            this.btnListar.Text = "LISTA DE FUNCIONÁRIOS";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // lblBoasVindas
            // 
            this.lblBoasVindas.BackColor = System.Drawing.Color.Transparent;
            this.lblBoasVindas.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoasVindas.ForeColor = System.Drawing.Color.White;
            this.lblBoasVindas.Location = new System.Drawing.Point(224, 77);
            this.lblBoasVindas.Name = "lblBoasVindas";
            this.lblBoasVindas.Size = new System.Drawing.Size(174, 26);
            this.lblBoasVindas.TabIndex = 7;
            this.lblBoasVindas.Text = "BEM VINDO GESTOR";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(151, 25);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(335, 41);
            this.labelTitulo.TabIndex = 11;
            this.labelTitulo.Text = "MENU DO GESTOR";
            // 
            // btnCadastroFuncionario
            // 
            this.btnCadastroFuncionario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroFuncionario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCadastroFuncionario.Location = new System.Drawing.Point(58, 139);
            this.btnCadastroFuncionario.Name = "btnCadastroFuncionario";
            this.btnCadastroFuncionario.Size = new System.Drawing.Size(209, 64);
            this.btnCadastroFuncionario.TabIndex = 8;
            this.btnCadastroFuncionario.Text = "CADASTRO DE FUNCIONÁRIOS";
            this.btnCadastroFuncionario.UseVisualStyleBackColor = true;
            this.btnCadastroFuncionario.Click += new System.EventHandler(this.btnCadastroFuncionario_Click);
            // 
            // btnAtestado
            // 
            this.btnAtestado.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtestado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAtestado.Location = new System.Drawing.Point(361, 139);
            this.btnAtestado.Name = "btnAtestado";
            this.btnAtestado.Size = new System.Drawing.Size(209, 64);
            this.btnAtestado.TabIndex = 13;
            this.btnAtestado.Text = "ENVIO DE ATESTADO";
            this.btnAtestado.UseVisualStyleBackColor = true;
            this.btnAtestado.Click += new System.EventHandler(this.btnAtestado_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRelatorio.Location = new System.Drawing.Point(58, 230);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(209, 64);
            this.btnRelatorio.TabIndex = 9;
            this.btnRelatorio.Text = "ATUALIZAR CADASTRO";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnConsultar.Location = new System.Drawing.Point(361, 327);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(209, 64);
            this.btnConsultar.TabIndex = 14;
            this.btnConsultar.Text = "CONSULTAR PONTO ";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnApontar
            // 
            this.btnApontar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApontar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnApontar.Location = new System.Drawing.Point(361, 230);
            this.btnApontar.Name = "btnApontar";
            this.btnApontar.Size = new System.Drawing.Size(209, 64);
            this.btnApontar.TabIndex = 12;
            this.btnApontar.Text = "REGISTRAR PONTO ";
            this.btnApontar.UseVisualStyleBackColor = true;
            this.btnApontar.Click += new System.EventHandler(this.btnApontar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSair.Location = new System.Drawing.Point(206, 433);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(209, 64);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormMenuGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelGestor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenuGestor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAIR";
            this.panelGestor.ResumeLayout(false);
            this.panelGestor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelGestor;
        private Label lblBoasVindas;
        private Label labelTitulo;
        private Button btnCadastroFuncionario;
        private Button btnAtestado;
        private Button btnRelatorio;
        private Button btnConsultar;
        private Button btnApontar;
        private Button btnSair;
        private Button btnListar;
    }
}