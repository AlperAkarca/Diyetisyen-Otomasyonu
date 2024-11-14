using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                conn.Open();
                string sql = "UPDATE diyetisyen SET kullanici_adi=@kullaniciAdi, sifre=@sifre, telefon=@telefon WHERE kimlik=@kimlik";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                cmd.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@kimlik", AdminGiriş.kimlik);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bilgileriniz Güncellendi");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Şifre Tekrar Şifre(Yeni) ile uyuşmuyor");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.hidden;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.eye;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiyetisyenPanel git = new DiyetisyenPanel();
            git.Show();
            this.Hide();
        }
    }
}
