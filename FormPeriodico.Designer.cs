using System.Drawing;
using System.Windows.Forms;

namespace MeuRH
{
    partial class FormPeriodico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPeriodico));
            this.panelPeriodico = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeriodico = new System.Windows.Forms.DataGridView();
            this.panelPeriodico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodico)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPeriodico
            // 
            this.panelPeriodico.BackColor = System.Drawing.Color.Transparent;
            this.panelPeriodico.Controls.Add(this.btnVoltar);
            this.panelPeriodico.Controls.Add(this.label1);
            this.panelPeriodico.Controls.Add(this.dgvPeriodico);
            this.panelPeriodico.Location = new System.Drawing.Point(33, 92);
            this.panelPeriodico.Name = "panelPeriodico";
            this.panelPeriodico.Size = new System.Drawing.Size(1293, 421);
            this.panelPeriodico.TabIndex = 3;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVoltar.Location = new System.Drawing.Point(794, 28);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(178, 80);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(271, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "EXAMES PERIÓDICOS";
            // 
            // dgvPeriodico
            // 
            this.dgvPeriodico.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPeriodico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodico.Location = new System.Drawing.Point(49, 131);
            this.dgvPeriodico.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPeriodico.Name = "dgvPeriodico";
            this.dgvPeriodico.RowHeadersWidth = 62;
            this.dgvPeriodico.Size = new System.Drawing.Size(1188, 256);
            this.dgvPeriodico.TabIndex = 4;
            // 
            // FormPeriodico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelPeriodico);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPeriodico";
            this.Text = "FormPeriodico";
            this.panelPeriodico.ResumeLayout(false);
            this.panelPeriodico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodico)).EndInit();
            this.ResumeLayout(false);

        }



        private Panel panelPeriodico;
        private Button btnVoltar;
        private Label label1;
        private DataGridView dgvPeriodico;

        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       

        #endregion
    }
}