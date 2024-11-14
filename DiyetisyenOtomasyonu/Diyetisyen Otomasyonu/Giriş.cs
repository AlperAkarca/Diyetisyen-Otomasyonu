using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminGiriş frm2 = new AdminGiriş();
            this.Hide();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DiyetisyenGiriş frm3 = new DiyetisyenGiriş();
            this.Hide();
            frm3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DanışmaGiriş git = new DanışmaGiriş();
            git.Show();
            this.Hide();
        }
    }
}
