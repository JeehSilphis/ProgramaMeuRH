using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MeuRH
{
    partial class FormAtestado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAtestado));
            this.panelAtestado = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxAtestado = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numDias = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAtestado = new System.Windows.Forms.DateTimePicker();
            this.btnAnexar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panelAtestado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAtestado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAtestado
            // 
            this.panelAtestado.BackColor = System.Drawing.Color.Transparent;
            this.panelAtestado.Controls.Add(this.label3);
            this.panelAtestado.Controls.Add(this.pictureBoxAtestado);
            this.panelAtestado.Controls.Add(this.btnVoltar);
            this.panelAtestado.Controls.Add(this.lblStatus);
            this.panelAtestado.Controls.Add(this.numDias);
            this.panelAtestado.Controls.Add(this.label2);
            this.panelAtestado.Controls.Add(this.label1);
            this.panelAtestado.Controls.Add(this.dtAtestado);
            this.panelAtestado.Controls.Add(this.btnAnexar);
            this.panelAtestado.Controls.Add(this.btnSalvar);
            this.panelAtestado.Location = new System.Drawing.Point(408, 12);
            this.panelAtestado.Name = "panelAtestado";
            this.panelAtestado.Size = new System.Drawing.Size(561, 661);
            this.panelAtestado.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(106, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 37);
            this.label3.TabIndex = 27;
            this.label3.Text = "ENVIO DE ATESTADO";
            // 
            // pictureBoxAtestado
            // 
            this.pictureBoxAtestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAtestado.Location = new System.Drawing.Point(53, 106);
            this.pictureBoxAtestado.Name = "pictureBoxAtestado";
            this.pictureBoxAtestado.Size = new System.Drawing.Size(465, 342);
            this.pictureBoxAtestado.TabIndex = 26;
            this.pictureBoxAtestado.TabStop = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.Location = new System.Drawing.Point(383, 529);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(135, 66);
            this.btnVoltar.TabIndex = 25;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Ivory;
            this.lblStatus.Location = new System.Drawing.Point(53, 464);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(465, 43);
            this.lblStatus.TabIndex = 22;
            // 
            // numDias
            // 
            this.numDias.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.numDias.Location = new System.Drawing.Point(474, 66);
            this.numDias.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numDias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDias.Name = "numDias";
            this.numDias.Size = new System.Drawing.Size(39, 22);
            this.numDias.TabIndex = 19;
            this.numDias.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(327, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "DIAS AFASTADOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "DATA DO ATESTADO";
            // 
            // dtAtestado
            // 
            this.dtAtestado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtAtestado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAtestado.Location = new System.Drawing.Point(224, 66);
            this.dtAtestado.Name = "dtAtestado";
            this.dtAtestado.Size = new System.Drawing.Size(90, 22);
            this.dtAtestado.TabIndex = 18;
            // 
            // btnAnexar
            // 
            this.btnAnexar.BackColor = System.Drawing.Color.White;
            this.btnAnexar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAnexar.Location = new System.Drawing.Point(53, 529);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Size = new System.Drawing.Size(135, 66);
            this.btnAnexar.TabIndex = 20;
            this.btnAnexar.Text = "SELECIONAR ATESTADO";
            this.btnAnexar.UseVisualStyleBackColor = false;
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.Location = new System.Drawing.Point(217, 529);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(135, 66);
            this.btnSalvar.TabIndex = 21;
            this.btnSalvar.Text = "SALVAR ATESTADO";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormAtestado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelAtestado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAtestado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Atestado";
            this.panelAtestado.ResumeLayout(false);
            this.panelAtestado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAtestado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).EndInit();
            this.ResumeLayout(false);

        }
        private Panel panelAtestado;
        private PictureBox pictureBoxAtestado;
        private Button btnVoltar;
        private Label lblStatus;
        private NumericUpDown numDias;
        private Label label2;
        private Label label1;
        private DateTimePicker dtAtestado;
        private Button btnAnexar;
        private Button btnSalvar;
        private Label label3;
    }
}