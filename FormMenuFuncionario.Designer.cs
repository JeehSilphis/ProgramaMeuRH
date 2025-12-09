using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MeuRH
{
    partial class FormMenuFuncionario
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuFuncionario));
            this.panelFuncionario = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSaudacaoFuncionario = new System.Windows.Forms.Label();
            this.btnApontar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAtestado = new System.Windows.Forms.Button();
            this.panelFuncionario.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFuncionario
            // 
            this.panelFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.panelFuncionario.Controls.Add(this.lblSaudacaoFuncionario);
            this.panelFuncionario.Controls.Add(this.label1);
            this.panelFuncionario.Controls.Add(this.btnApontar);
            this.panelFuncionario.Controls.Add(this.btnSair);
            this.panelFuncionario.Controls.Add(this.btnAtestado);
            this.panelFuncionario.Location = new System.Drawing.Point(172, 126);
            this.panelFuncionario.Name = "panelFuncionario";
            this.panelFuncionario.Size = new System.Drawing.Size(633, 353);
            this.panelFuncionario.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(137, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "MENU DO FUNCIONÁRIO";
            // 
            // lblSaudacaoFuncionario
            // 
            this.lblSaudacaoFuncionario.AutoSize = true;
            this.lblSaudacaoFuncionario.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaudacaoFuncionario.ForeColor = System.Drawing.Color.White;
            this.lblSaudacaoFuncionario.Location = new System.Drawing.Point(217, 71);
            this.lblSaudacaoFuncionario.Name = "lblSaudacaoFuncionario";
            this.lblSaudacaoFuncionario.Size = new System.Drawing.Size(124, 22);
            this.lblSaudacaoFuncionario.TabIndex = 8;
            this.lblSaudacaoFuncionario.Text = "BEM VINDO ";
            // 
            // btnApontar
            // 
            this.btnApontar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApontar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnApontar.Location = new System.Drawing.Point(137, 152);
            this.btnApontar.Name = "btnApontar";
            this.btnApontar.Size = new System.Drawing.Size(141, 83);
            this.btnApontar.TabIndex = 4;
            this.btnApontar.Text = "REGISTRAR PONTO ";
            this.btnApontar.UseVisualStyleBackColor = true;
            this.btnApontar.Click += new System.EventHandler(this.btnApontar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkRed;
            this.btnSair.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(282, 285);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(86, 26);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAtestado
            // 
            this.btnAtestado.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtestado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAtestado.Location = new System.Drawing.Point(366, 152);
            this.btnAtestado.Name = "btnAtestado";
            this.btnAtestado.Size = new System.Drawing.Size(141, 83);
            this.btnAtestado.TabIndex = 6;
            this.btnAtestado.Text = "ENVIO DE ATESTADO";
            this.btnAtestado.UseVisualStyleBackColor = true;
            this.btnAtestado.Click += new System.EventHandler(this.btnAtestado_Click);
            // 
            // FormMenuFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelFuncionario);
            this.Name = "FormMenuFuncionario";
            this.Text = "FormMenuFuncionario";
            this.panelFuncionario.ResumeLayout(false);
            this.panelFuncionario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelFuncionario;
        private Label label1;
        private Label lblSaudacaoFuncionario;
        private Button btnApontar;
        private Button btnSair;
        private Button btnAtestado;
    }
}