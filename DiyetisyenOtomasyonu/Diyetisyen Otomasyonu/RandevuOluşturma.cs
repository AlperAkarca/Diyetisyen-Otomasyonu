using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class RandevuOluşturma : Form
    {
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();

        public RandevuOluşturma()
        {
            InitializeComponent();
            conn.ConnectionString = connecting;
        }
        public class Item
        {
            public string FullName { get; set; }
            public string Kimlik { get; set; }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            string randevuTarihi = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string randevuSaati = comboBox2.Text;
            string dadsoyad = comboBox3.Text;
            if (string.IsNullOrEmpty(randevuTarihi) || string.IsNullOrEmpty(randevuSaati) || string.IsNullOrEmpty(dadsoyad))
            {
                MessageBox.Show("Lütfen tarih ve saat bilgilerini girin.");
                return;
            }

            if (RandevuVarMi(randevuTarihi, randevuSaati, dadsoyad))
            {
                MessageBox.Show("Seçilen tarih ve saat için randevu mevcut.");
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

                conn.Open();

                string sql1 = "INSERT INTO randevu (ad, soyad,danisan_kimlik,dogum_tarihi,saat,telefon,cinsiyet,tarih,brans,diyetisyen_kimlik ,sikayet) VALUES (@ad,@soyad,@danisan_kimlik,@yas,@saat,@telefon,@cinsiyet,@tarih,@brans,@diyetisyen_kimlik,@sikayet)";

                MySqlCommand command = new MySqlCommand(sql1, conn);

                command.Parameters.AddWithValue("@ad", textBox1.Text);
                command.Parameters.AddWithValue("@soyad", textBox2.Text);
                command.Parameters.AddWithValue("@danisan_kimlik", textBox3.Text);
                command.Parameters.AddWithValue("@yas", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@saat", comboBox2.Text);
                command.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                command.Parameters.AddWithValue("@tarih", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@brans", comboBox1.Text);
                command.Parameters.AddWithValue("@diyetisyen_kimlik", ((Item)comboBox3.SelectedItem).Kimlik);
                command.Parameters.AddWithValue("@dadsoyad", comboBox3.Text);
                command.Parameters.AddWithValue("@sikayet", textBox6.Text);

                command.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show(" Randevu başarıyla oluşturuldu.");
            }

        }
        bool RandevuVarMi(string tarih, string saat, string dadsoyad)
        {
            bool randevuVar = false;
            string query = "SELECT COUNT(*) FROM randevu WHERE tarih = @tarih AND saat = @saat AND dadsoyad = @dadsoyad";

            using (MySqlCommand command31 = new MySqlCommand(query, conn))
            {
                command31.Parameters.AddWithValue("@tarih", tarih);
                command31.Parameters.AddWithValue("@saat", saat);
                command31.Parameters.AddWithValue("@dadsoyad", dadsoyad);

                try
                {
                    conn.Open();
                    int count = Convert.ToInt32(command31.ExecuteScalar());

                    if (count > 0)
                    {
                        randevuVar = true;
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

            return randevuVar;
        }
        private void RandevuOluşturma_Load(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today;
            LoadBranslar();
        }

        private void LoadBranslar()
        {
            conn.Open();
            string query = "SELECT DISTINCT brans FROM branslar";
            MySqlCommand command = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string branslar = reader.GetString("brans");
                    comboBox1.Items.Add(branslar);
                }
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBox2.Text = "";
            textBox6.Clear();
            maskedTextBox1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBrans = comboBox1.SelectedItem.ToString();

            conn.Open();
            string query = "SELECT CONCAT(ad, ' ', soyad) AS FullName, kimlik AS Kimlik FROM diyetisyen WHERE brans = @brans";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@brans", selectedBrans);

            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            conn.Close();

            comboBox3.Items.Clear();
            comboBox3.DisplayMember = "FullName";
            comboBox3.ValueMember = "Kimlik";

            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(new Item
                {
                    FullName = dr["FullName"].ToString(),
                    Kimlik = dr["Kimlik"].ToString()
                });
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var item = (Item)comboBox3.SelectedItem;
                string selectedDoktor = item.Kimlik;
                string tarih = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                conn.Open();
                string query = "SELECT saat FROM randevu WHERE diyetisyen_kimlik = @diyetisyen_kimlik and tarih = @tarih";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@diyetisyen_kimlik", selectedDoktor);
                command.Parameters.AddWithValue("@tarih", tarih);

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());

                conn.Close();

                if (dt.Rows.Count == 0)
                {
                    randevuSaatDoldur();
                }

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Remove(dr["saat"].ToString());
                }
            }
        }

        private void randevuSaatDoldur()
        {
            string[] saatler = { "08.00", "09.00", "10.00", "11.00", "13.00", "14.00", "15.00", "16.00" };
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(saatler);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            randevuSaatDoldur();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
