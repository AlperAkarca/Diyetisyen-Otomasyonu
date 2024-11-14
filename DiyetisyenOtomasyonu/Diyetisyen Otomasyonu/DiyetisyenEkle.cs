using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace WindowsFormsApp11
{
    public partial class DiyetisyenEkle : Form
    {

        public DiyetisyenEkle()
        {
            InitializeComponent();
        }
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
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
                MessageBox.Show("Eklemek istediğiniz diyetisyen veritabanında mevcut.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string cinsiyet = "";
                if (radioButton1.Checked)
                {
                    cinsiyet = "kadın";
                }
                else if (radioButton2.Checked)
                {
                    cinsiyet = "erkek";
                }

                string sql1 = "INSERT INTO diyetisyen (kimlik, ad, soyad, kullanici_adi, sifre, telefon, cinsiyet, yas,brans) VALUES (@kimlik, @ad, @soyad, @kullanici_adi, @sifre, @telefon, @cinsiyet, @dogum_tarihi, @brans)";

                MySqlCommand command = new MySqlCommand(sql1, conn);


                command.Parameters.AddWithValue("@kimlik", textBox3.Text);
                command.Parameters.AddWithValue("@ad", textBox1.Text);
                command.Parameters.AddWithValue("@soyad", textBox2.Text);
                command.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
                command.Parameters.AddWithValue("@sifre", textBox5.Text);
                command.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                command.Parameters.AddWithValue("@dogum_tarihi", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@brans", comboBox1.Text);

                command.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show(" Diyetisyen başarıyla eklendi.");
            }
        }

        private void sekreterEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanışmaEkle git = new DanışmaEkle();
            git.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.UseSystemPasswordChar == true)
            {
                textBox5.UseSystemPasswordChar = false;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.hidden;
            }
            else
            {
                textBox5.UseSystemPasswordChar = true;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.eye;
            }
        }

        private void sekreterSilmeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DanışmaSil git = new DanışmaSil();
            git.Show();
            this.Hide();
        }

        private void sekreterBilgileriGüncellemeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DanışmaGüncelle git = new DanışmaGüncelle();
            git.Show();
            this.Hide();
        }



        private void diyetisyenSilmeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DiyetisyenSil git = new DiyetisyenSil();
            git.Show();
            this.Hide();
        }

        private void diyetisyenBilgileriGüncellemeToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
