using System;
using System.Collections.Generic;
using System.ComponentModel; // ESSENCIAL para LicenseManager
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MeuRH
{
    public partial class BaseForm : Form
    {
        protected Panel PainelCentral { get; set; }

        public BaseForm()
        {
            // ------------------------------------------------------------------
            // 🛑 CORREÇÃO CRÍTICA DO DESIGNER:
            // Impede que qualquer código que inicialize o banco de dados (SQLite)
            // seja executado enquanto o Visual Studio estiver tentando desenhar
            // o formulário.
            // ------------------------------------------------------------------
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return; // Sai imediatamente se estiver no modo de design.
            }

            // ------------------------------------------------------------------
            // O InitializeComponent() deve ser chamado SOMENTE em Runtime (ou seja,
            // DEPOIS da verificação de LicenseManager.UsageMode). Se o erro de
            // carregamento persistir, o problema está no InitializeComponent().
            // ------------------------------------------------------------------
            InitializeComponent();

            // Evita trepidação durante resize
            this.DoubleBuffered = true;

            // Centraliza somente nos momentos corretos
            this.Load += (s, e) => CentralizarPainel();
            this.ResizeEnd += (s, e) => CentralizarPainel();
        }

        protected void DefinirPainelCentral(Panel painel)
        {
            PainelCentral = painel;
            CentralizarPainel();
        }

        protected void CentralizarPainel()
        {
            if (PainelCentral == null) return;

            PainelCentral.Location = new Point(
                (this.ClientSize.Width - PainelCentral.Width) / 2,
                (this.ClientSize.Height - PainelCentral.Height) / 2
            );
        }
    }
}