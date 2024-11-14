using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DanışmaEkle : Form
    {
        public DanışmaEkle()
        {
            InitializeComponent();
        }
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();


        private void sekreterSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanışmaSil git = new DanışmaSil();
            git.Show();
            this.Hide();
        }

        private void sekreterBilgileriGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanışmaGüncelle git = new DanışmaGüncelle();
            git.Show();
            this.Hide();
        }

        private void diyetisyenEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiyetisyenEkle git = new DiyetisyenEkle();
            git.Show();
            this.Hide();
        }

        private void diyetisyenSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiyetisyenSil git = new DiyetisyenSil();
            git.Show();
            this.Hide();
        }

        private void diyetisyenBilgileriGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiyetisyenGüncelle git = new DiyetisyenGüncelle();
            git.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();

            string sqlCheck = "SELECT COUNT(*) FROM danisma WHERE kimlik = @kimlik";
            MySqlCommand checkCommand = new MySqlCommand(sqlCheck, conn);
            checkCommand.Parameters.AddWithValue("@kimlik", textBox3.Text);
            int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

            if (existingCount > 0)
            {
                MessageBox.Show("Eklemek istediğiniz danışma veritabanında mevcut.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Danışma ekleme işlemi
                string cinsiyet = "";
                if (radioButton1.Checked)
                {
                    cinsiyet = "Kadın";
                }
                else if (radioButton2.Checked)
                {
                    cinsiyet = "Erkek";
                }

                string sqlInsert = "INSERT INTO danisma (kimlik, ad, soyad, kullanici_adi, sifre, telefon, cinsiyet, dogum_tarihi) VALUES (@kimlik, @ad, @soyad, @kullanici_adi, @sifre, @telefon, @cinsiyet, @dogum_tarihi)";
                MySqlCommand insertCommand = new MySqlCommand(sqlInsert, conn);
                insertCommand.Parameters.AddWithValue("@kimlik", textBox3.Text);
                insertCommand.Parameters.AddWithValue("@ad", textBox1.Text);
                insertCommand.Parameters.AddWithValue("@soyad", textBox2.Text);
                insertCommand.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
                insertCommand.Parameters.AddWithValue("@sifre", textBox5.Text);
                insertCommand.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                insertCommand.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                insertCommand.Parameters.AddWithValue("@dogum_tarihi", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                insertCommand.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Veri başarıyla eklendi.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            maskedTextBox1.Clear();
            dateTimePicker1.Text = "";
        }

    }
}
