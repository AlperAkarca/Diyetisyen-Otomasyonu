using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class AdminGiriş : Form
    {
        public AdminGiriş()
        {
            InitializeComponent();
        }

        static public string kimlik;
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
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

        private void AdminGiriş_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool kullanicivarmi = false;
            string kullanici_adi = "admin";
            string sifre = "1234";
            string adminkimlik = "00000000000";

            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "select * from  admin where kullanici_adi = '" + textBox1.Text.ToString() + "' and sifre ='" + textBox2.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                kullanicivarmi = true;
                kimlik = reader["kimlik"].ToString();
            }
            if (kullanicivarmi)
            {
                AdminPaneli user = new AdminPaneli();
                user.Show();
                this.Hide();

            }
            else if (textBox1.Text == kullanici_adi && textBox2.Text == sifre)
            {
                AdminPaneli user = new AdminPaneli();
                user.Show();
                this.Hide();
            }
            else if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(textBox2, "Bu alan boş bırakılamaz");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
            conn.Close();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("  Kullanıcı Adı Boş Geçilemez");
                return;
            }

            bool varMi = kullaniciVarMi();

            if (!varMi)
            {
                MessageBox.Show("  Kullanıcı bulunamadı");
                return;
            }

            conn.ConnectionString = connecting;
            conn.Open();

            string sql = "UPDATE admin SET  sifre='1234' WHERE kullanici_adi=@kullaniciAdi";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("  Şifreniz 1234 olarak Resetlenmiştir.");

            conn.Close();
        }

        private bool kullaniciVarMi()
        {
            bool kullaniciVar = false;
            string query = "SELECT count(*) FROM diyetisyen_db.admin where kullanici_adi = @kullaniciAdi";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);

                try
                {
                    conn.ConnectionString = connecting;
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        kullaniciVar = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return kullaniciVar;
        }
    }
}

