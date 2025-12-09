using System.Drawing;
using System.Windows.Forms;

namespace MeuRH
{
    partial class FormRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro));
            this.panelRegistro = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.btnSaida = new System.Windows.Forms.Button();
            this.btnRetornoAlmoco = new System.Windows.Forms.Button();
            this.btnSaidaAlmoco = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRegistro
            // 
            this.panelRegistro.BackColor = System.Drawing.Color.Transparent;
            this.panelRegistro.Controls.Add(this.label2);
            this.panelRegistro.Controls.Add(this.btnVoltar);
            this.panelRegistro.Controls.Add(this.btnFiltrar);
            this.panelRegistro.Controls.Add(this.dtFim);
            this.panelRegistro.Controls.Add(this.dtInicio);
            this.panelRegistro.Controls.Add(this.dgvHistorico);
            this.panelRegistro.Controls.Add(this.btnSaida);
            this.panelRegistro.Controls.Add(this.btnRetornoAlmoco);
            this.panelRegistro.Controls.Add(this.btnSaidaAlmoco);
            this.panelRegistro.Controls.Add(this.btnEntrada);
            this.panelRegistro.Controls.Add(this.txtCPF);
            this.panelRegistro.Controls.Add(this.label1);
            this.panelRegistro.Location = new System.Drawing.Point(179, 10);
            this.panelRegistro.Name = "panelRegistro";
            this.panelRegistro.Size = new System.Drawing.Size(628, 554);
            this.panelRegistro.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(164, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 37);
            this.label2.TabIndex = 23;
            this.label2.Text = "REGISTRO DE PONTO";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.FlatAppearance.BorderSize = 2;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVoltar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Navy;
            this.btnVoltar.Location = new System.Drawing.Point(472, 196);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Padding = new System.Windows.Forms.Padding(5);
            this.btnVoltar.Size = new System.Drawing.Size(107, 53);
            this.btnVoltar.TabIndex = 22;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFiltrar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.Navy;
            this.btnFiltrar.Location = new System.Drawing.Point(246, 196);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(182, 22);
            this.btnFiltrar.TabIndex = 12;
            this.btnFiltrar.Text = "FILTRAR POR DATA";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(246, 229);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(182, 20);
            this.dtFim.TabIndex = 13;
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(50, 229);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(175, 20);
            this.dtInicio.TabIndex = 14;
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorico.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Location = new System.Drawing.Point(48, 264);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.Size = new System.Drawing.Size(531, 252);
            this.dgvHistorico.TabIndex = 15;
            // 
            // btnSaida
            // 
            this.btnSaida.BackColor = System.Drawing.Color.White;
            this.btnSaida.FlatAppearance.BorderSize = 2;
            this.btnSaida.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaida.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaida.ForeColor = System.Drawing.Color.Navy;
            this.btnSaida.Location = new System.Drawing.Point(472, 107);
            this.btnSaida.Name = "btnSaida";
            this.btnSaida.Padding = new System.Windows.Forms.Padding(5);
            this.btnSaida.Size = new System.Drawing.Size(107, 42);
            this.btnSaida.TabIndex = 16;
            this.btnSaida.Text = "SAIDA";
            this.btnSaida.UseVisualStyleBackColor = false;
            // 
            // btnRetornoAlmoco
            // 
            this.btnRetornoAlmoco.BackColor = System.Drawing.Color.White;
            this.btnRetornoAlmoco.FlatAppearance.BorderSize = 2;
            this.btnRetornoAlmoco.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetornoAlmoco.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetornoAlmoco.ForeColor = System.Drawing.Color.Navy;
            this.btnRetornoAlmoco.Location = new System.Drawing.Point(321, 107);
            this.btnRetornoAlmoco.Name = "btnRetornoAlmoco";
            this.btnRetornoAlmoco.Padding = new System.Windows.Forms.Padding(5);
            this.btnRetornoAlmoco.Size = new System.Drawing.Size(107, 42);
            this.btnRetornoAlmoco.TabIndex = 17;
            this.btnRetornoAlmoco.Text = "FIM DO ALMOÇO";
            this.btnRetornoAlmoco.UseVisualStyleBackColor = false;
            // 
            // btnSaidaAlmoco
            // 
            this.btnSaidaAlmoco.BackColor = System.Drawing.Color.White;
            this.btnSaidaAlmoco.FlatAppearance.BorderSize = 2;
            this.btnSaidaAlmoco.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaidaAlmoco.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaidaAlmoco.ForeColor = System.Drawing.Color.Navy;
            this.btnSaidaAlmoco.Location = new System.Drawing.Point(184, 107);
            this.btnSaidaAlmoco.Name = "btnSaidaAlmoco";
            this.btnSaidaAlmoco.Padding = new System.Windows.Forms.Padding(5);
            this.btnSaidaAlmoco.Size = new System.Drawing.Size(107, 42);
            this.btnSaidaAlmoco.TabIndex = 18;
            this.btnSaidaAlmoco.Text = "INÍCIO DO ALMOÇO";
            this.btnSaidaAlmoco.UseVisualStyleBackColor = false;
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.White;
            this.btnEntrada.FlatAppearance.BorderSize = 2;
            this.btnEntrada.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEntrada.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.ForeColor = System.Drawing.Color.Navy;
            this.btnEntrada.Location = new System.Drawing.Point(48, 107);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Padding = new System.Windows.Forms.Padding(5);
            this.btnEntrada.Size = new System.Drawing.Size(107, 42);
            this.btnEntrada.TabIndex = 19;
            this.btnEntrada.Text = "ENTRADA";
            this.btnEntrada.UseVisualStyleBackColor = false;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(50, 196);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(175, 20);
            this.txtCPF.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(48, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "CPF";
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelRegistro);
            this.MinimizeBox = false;
            this.Name = "FormRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Ponto";
            this.panelRegistro.ResumeLayout(false);
            this.panelRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.ResumeLayout(false);

        }



        private Panel panelRegistro;
        private Label label2;
        private Button btnVoltar;
        private Button btnFiltrar;
        private DateTimePicker dtFim;
        private DateTimePicker dtInicio;
        private DataGridView dgvHistorico;
        private Button btnSaida;
        private Button btnRetornoAlmoco;
        private Button btnSaidaAlmoco;
        private Button btnEntrada;
        private TextBox txtCPF;
        private Label label1;
    }

}
