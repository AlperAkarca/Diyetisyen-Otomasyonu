using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class PDF : Form
    {
        public PDF()
        {
            InitializeComponent();
        }

        private void PDF_Load(object sender, EventArgs e)
        {
              // Otomatik boyutlandırmayı etkinleştirin
                axAcroPDF1.setShowToolbar(false); // İstenirse araç çubuğunu gizleyin
                axAcroPDF1.setView("FitH"); // Yatay yönde otomatik boyutlandırmayı ayarlayın
                axAcroPDF1.setLayoutMode("SinglePage"); // Tek sayfa görünümünü ayarlayın
                axAcroPDF1.setShowScrollbars(true); // Kaydırma çubuklarını gizleyin (isteğe bağlı)
            }

        }
    }
