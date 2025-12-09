using System.Drawing;
using System.Windows.Forms;

namespace MeuRH
{
    partial class MenuMedico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuMedico));
            this.panelMedico = new System.Windows.Forms.Panel();
            this.btnPeriodico = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnApontar = new System.Windows.Forms.Button();
            this.dgvAtestados = new System.Windows.Forms.DataGridView();
            this.lblSaudacaoMedico = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelMedico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtestados)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMedico
            // 
            this.panelMedico.BackColor = System.Drawing.Color.Transparent;
            this.panelMedico.Controls.Add(this.btnPeriodico);
            this.panelMedico.Controls.Add(this.btnSair);
            this.panelMedico.Controls.Add(this.btnApontar);
            this.panelMedico.Controls.Add(this.dgvAtestados);
            this.panelMedico.Controls.Add(this.lblSaudacaoMedico);
            this.panelMedico.Controls.Add(this.labelTitulo);
            this.panelMedico.Location = new System.Drawing.Point(19, 10);
            this.panelMedico.Name = "panelMedico";
            this.panelMedico.Size = new System.Drawing.Size(1304, 619);
            this.panelMedico.TabIndex = 10;
            // 
            // btnPeriodico
            // 
            this.btnPeriodico.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriodico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPeriodico.Location = new System.Drawing.Point(1034, 120);
            this.btnPeriodico.Name = "btnPeriodico";
            this.btnPeriodico.Size = new System.Drawing.Size(229, 32);
            this.btnPeriodico.TabIndex = 15;
            this.btnPeriodico.Text = "EXAME PERIÓDICO";
            this.btnPeriodico.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSair.Location = new System.Drawing.Point(1034, 184);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(229, 32);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // btnApontar
            // 
            this.btnApontar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApontar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnApontar.Location = new System.Drawing.Point(1034, 59);
            this.btnApontar.Name = "btnApontar";
            this.btnApontar.Size = new System.Drawing.Size(229, 32);
            this.btnApontar.TabIndex = 13;
            this.btnApontar.Text = "REGISTRAR PONTO";
            this.btnApontar.UseVisualStyleBackColor = true;
            // 
            // dgvAtestados
            // 
            this.dgvAtestados.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAtestados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtestados.Location = new System.Drawing.Point(40, 251);
            this.dgvAtestados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAtestados.Name = "dgvAtestados";
            this.dgvAtestados.RowHeadersWidth = 62;
            this.dgvAtestados.Size = new System.Drawing.Size(1223, 249);
            this.dgvAtestados.TabIndex = 12;
            // 
            // lblSaudacaoMedico
            // 
            this.lblSaudacaoMedico.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaudacaoMedico.ForeColor = System.Drawing.Color.White;
            this.lblSaudacaoMedico.Location = new System.Drawing.Point(179, 128);
            this.lblSaudacaoMedico.Name = "lblSaudacaoMedico";
            this.lblSaudacaoMedico.Size = new System.Drawing.Size(187, 26);
            this.lblSaudacaoMedico.TabIndex = 10;
            this.lblSaudacaoMedico.Text = "BEM VINDO DR(A)";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(106, 87);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(328, 41);
            this.labelTitulo.TabIndex = 11;
            this.labelTitulo.Text = "MENU DO MÉDICO";
            // 
            // MenuMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelMedico);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuMedico";
            this.Text = "MenuMedico";
            this.panelMedico.ResumeLayout(false);
            this.panelMedico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtestados)).EndInit();
            this.ResumeLayout(false);

        }


        private Panel panelMedico;
        private Button btnPeriodico;
        private Button btnSair;
        private Button btnApontar;
        private DataGridView dgvAtestados;
        private Label lblSaudacaoMedico;
        private Label labelTitulo;
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
    }
}