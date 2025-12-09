using MeuRH;
using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MeuRH
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRE = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.Controls.Add(this.txtCPF);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.txtRE);
            this.panelLogin.Controls.Add(this.btnEntrar);
            this.panelLogin.Location = new System.Drawing.Point(189, 140);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(674, 283);
            this.panelLogin.TabIndex = 6;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(147, 39);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(156, 20);
            this.txtCPF.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(367, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "RE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(144, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "CPF";
            // 
            // txtRE
            // 
            this.txtRE.Location = new System.Drawing.Point(369, 39);
            this.txtRE.Name = "txtRE";
            this.txtRE.Size = new System.Drawing.Size(161, 20);
            this.txtRE.TabIndex = 8;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEntrar.Location = new System.Drawing.Point(270, 152);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(127, 67);
            this.btnEntrar.TabIndex = 9;
            this.btnEntrar.Text = "ENTRAR";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panelLogin);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLogin;
        private TextBox txtCPF;
        private Label label2;
        private Label label1;
        private TextBox txtRE;
        private Button btnEntrar;
    }

        
}

