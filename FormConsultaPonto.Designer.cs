using System.Drawing;
using System.Windows.Forms;

namespace MeuRH
{
    partial class FormConsultaPonto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsultaPonto));
            this.panelConsulta = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvPontos = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panelConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPontos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelConsulta
            // 
            this.panelConsulta.BackColor = System.Drawing.Color.Transparent;
            this.panelConsulta.Controls.Add(this.label4);
            this.panelConsulta.Controls.Add(this.label3);
            this.panelConsulta.Controls.Add(this.label2);
            this.panelConsulta.Controls.Add(this.label1);
            this.panelConsulta.Controls.Add(this.txtNome);
            this.panelConsulta.Controls.Add(this.dtInicio);
            this.panelConsulta.Controls.Add(this.dtFim);
            this.panelConsulta.Controls.Add(this.btnBuscar);
            this.panelConsulta.Controls.Add(this.dgvPontos);
            this.panelConsulta.Controls.Add(this.btnVoltar);
            this.panelConsulta.Location = new System.Drawing.Point(203, 64);
            this.panelConsulta.Name = "panelConsulta";
            this.panelConsulta.Size = new System.Drawing.Size(646, 507);
            this.panelConsulta.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(78, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(478, 30);
            this.label4.TabIndex = 17;
            this.label4.Text = "CONSULTA DE REGISTROS DE PONTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(80, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "DATA FINAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "DATA INICIAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "DIGITE O NOME DO FUNCIONÁRIO";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(375, 107);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(183, 20);
            this.txtNome.TabIndex = 8;
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(198, 147);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(126, 20);
            this.dtInicio.TabIndex = 9;
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(198, 190);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(126, 20);
            this.dtFim.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnBuscar.Location = new System.Drawing.Point(375, 145);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(183, 25);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvPontos
            // 
            this.dgvPontos.AllowUserToAddRows = false;
            this.dgvPontos.AllowUserToDeleteRows = false;
            this.dgvPontos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPontos.ColumnHeadersHeight = 34;
            this.dgvPontos.Location = new System.Drawing.Point(84, 230);
            this.dgvPontos.Name = "dgvPontos";
            this.dgvPontos.ReadOnly = true;
            this.dgvPontos.RowHeadersWidth = 62;
            this.dgvPontos.Size = new System.Drawing.Size(478, 246);
            this.dgvPontos.TabIndex = 12;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVoltar.Location = new System.Drawing.Point(375, 185);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(183, 25);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FormConsultaPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelConsulta);
            this.MinimizeBox = false;
            this.Name = "FormConsultaPonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Ponto";
            this.panelConsulta.ResumeLayout(false);
            this.panelConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPontos)).EndInit();
            this.ResumeLayout(false);

        }
        private Panel panelConsulta;
        private Label label1;
        private TextBox txtNome;
        private DateTimePicker dtInicio;
        private DateTimePicker dtFim;
        private Button btnBuscar;
        private DataGridView dgvPontos;
        private Button btnVoltar;
        private Label label3;
        private Label label2;
        private Label label4;
    }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       
        
        #endregion
    }
