using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }
        string type = "admin";
        string tckimlikno = "";
        string adminFoto = "";
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        private void button4_Click(object sender, EventArgs e)
        {
            AdminGiriş git = new AdminGiriş();
            this.Hide();
            git.Show();

        }
        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "select ad,soyad,kimlik from admin where kimlik = " + AdminGiriş.kimlik;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["ad"].ToString() + " " + reader["soyad"].ToString();
                textBox2.Text = reader["kimlik"].ToString();
                tckimlikno = reader["kimlik"].ToString();
            }
            conn.Close();
            pictureBox1.ImageLocation = Helper.ProfilPath(tckimlikno, type);
            conn.Open();
            string sql1 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-01-01' AND '2023-01-31'";
            string sql2 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-02-01' AND '2023-02-28'";
            string sql3 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-03-01' AND '2023-03-31'";
            string sql4 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-04-01' AND '2023-04-30'";
            string sql5 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-05-01' AND '2023-05-31'";
            string sql6 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-06-01' AND '2023-06-30'";
            string sql7 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-07-01' AND '2023-07-31'";
            string sql8 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-08-01' AND '2023-08-31'";
            string sql9 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-09-01' AND '2023-09-30'";
            string sql10 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-10-01' AND '2023-10-31'";
            string sql11 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-11-01' AND '2023-11-30'";
            string sql12 = "SELECT COUNT(id) FROM randevu WHERE tarih BETWEEN '2023-12-01' AND '2023-12-31'";

            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
            MySqlCommand cmd5 = new MySqlCommand(sql5, conn);
            MySqlCommand cmd6 = new MySqlCommand(sql6, conn);
            MySqlCommand cmd7 = new MySqlCommand(sql7, conn);
            MySqlCommand cmd8 = new MySqlCommand(sql8, conn);
            MySqlCommand cmd9 = new MySqlCommand(sql9, conn);
            MySqlCommand cmd10 = new MySqlCommand(sql10, conn);
            MySqlCommand cmd11 = new MySqlCommand(sql11, conn);
            MySqlCommand cmd12 = new MySqlCommand(sql12, conn);


            chart1.Series["İlk 6 Aylık Randevu Sayısı"].Points.AddXY("Ocak", cmd1.ExecuteScalar().ToString());
            chart1.Series["İlk 6 Aylık Randevu Sayısı"].Points.AddXY("Şubat", cmd2.ExecuteScalar().ToString());
            chart1.Series["İlk 6 Aylık Randevu Sayısı"].Points.AddXY("Mart", cmd3.ExecuteScalar().ToString());
            chart1.Series["İlk 6 Aylık Randevu Sayısı"].Points.AddXY("Nisan", cmd4.ExecuteScalar().ToString());
            chart1.Series["İlk 6 Aylık Randevu Sayısı"].Points.AddXY("Mayıs", cmd5.ExecuteScalar().ToString());
            chart1.Series["İlk 6 Aylık Randevu Sayısı"].Points.AddXY("Haziran", cmd6.ExecuteScalar().ToString());
            chart2.Series["Son 6 Aylık Randevu Sayısı"].Points.AddXY("Temmuz", cmd7.ExecuteScalar().ToString());
            chart2.Series["Son 6 Aylık Randevu Sayısı"].Points.AddXY("Ağustos", cmd8.ExecuteScalar().ToString());
            chart2.Series["Son 6 Aylık Randevu Sayısı"].Points.AddXY("Eylül", cmd9.ExecuteScalar().ToString());
            chart2.Series["Son 6 Aylık Randevu Sayısı"].Points.AddXY("Ekim", cmd10.ExecuteScalar().ToString());
            chart2.Series["Son 6 Aylık Randevu Sayısı"].Points.AddXY("Kasım", cmd11.ExecuteScalar().ToString());
            chart2.Series["Son 6 Aylık Randevu Sayısı"].Points.AddXY("Aralık", cmd12.ExecuteScalar().ToString());

            using (MySqlConnection conn = new MySqlConnection(connecting))
            {

                string query = "SELECT * FROM branslar";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

            conn.Close();

            pictureBox1.ImageLocation = Helper.ProfilPath(tckimlikno, type);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DuyuruAdmin git = new DuyuruAdmin();
            this.Hide();
            git.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminGüncelleme git = new AdminGüncelleme();
            this.Hide();
            git.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DanışmaEkle git = new DanışmaEkle();
            this.Hide();
            git.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tckimlikno))
            {
                File.Copy(adminFoto, $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/Admin/{tckimlikno}.jpg", true);
                MessageBox.Show("Resim Kayıt Edildi.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DuyuruEkle git = new DuyuruEkle();
            this.Hide();
            git.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Fotoğraf Seçiniz(*.jpg; * *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                adminFoto = opf.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RandevuOluşturma git = new RandevuOluşturma();
            git.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Randevuİptal git = new Randevuİptal();
            git.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RandevuGüncelleme git = new RandevuGüncelleme();
            git.ShowDialog();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string selectedBranch = row.Cells[1].Value.ToString(); // İndeks 1 olarak güncellendi

                using (MySqlConnection connection = new MySqlConnection(connecting))
                {
                    connection.Open();

                    string query = "SELECT kimlik, ad, soyad FROM diyetisyen WHERE brans = @Branch";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Branch", selectedBranch);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;

                    connection.Close();
                }
            }


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
