using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DuyuruEkle : Form
    {
        public DuyuruEkle()
        {
            InitializeComponent();
        }

        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        private void duyuruSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuyuruSil git = new DuyuruSil();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bugün = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "INSERT INTO duyuru (konu,kime,aciklama,olusturulma_zamani) VALUES (@konu,@kime,@aciklama,@olusturulma_zamani)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@konu", textBox1.Text);
            cmd.Parameters.AddWithValue("@kime", comboBox1.Text);
            cmd.Parameters.AddWithValue("@aciklama", textBox2.Text);
            cmd.Parameters.AddWithValue("@olusturulma_zamani", bugün);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            this.Hide();
            git.Show();
        }
        private void DuyuruEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
