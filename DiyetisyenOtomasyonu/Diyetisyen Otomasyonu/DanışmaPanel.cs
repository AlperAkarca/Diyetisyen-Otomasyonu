using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp11
{
    public partial class DanışmaPanel : Form
    {
        public DanışmaPanel()
        {
            InitializeComponent();
        }

        string type = "danışma";
        string tckimlikno = "";
        string danismafoto = "";
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        private void button2_Click(object sender, EventArgs e)
        {
            DanışmaBilgileriGüncelleme git = new DanışmaBilgileriGüncelleme();
            this.Hide();
            git.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            DuyuruDanışma git = new DuyuruDanışma();
            this.Hide();
            git.Show();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            DanışmaGiriş git = new DanışmaGiriş();
            this.Hide();
            git.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DanışmaBilgileriGüncelleme git = new DanışmaBilgileriGüncelleme();
            this.Hide();
            git.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tckimlikno))
            {
                File.Copy(danismafoto, $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/Danışma/{tckimlikno}.jpg", true);
                MessageBox.Show("Resim Kayıt Edildi.");
            }
        }

        void Listele()
        {
            string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
            conn.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM randevu where danisan_kimlik = @kimlik or soyad=@soyad";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@kimlik", textBox3.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox4.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Fotoğraf Seçiniz(*.jpg; * *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                danismafoto = opf.FileName;
            }
        }

        private void DanışmaPanel_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "select ad,soyad,kimlik,resim from  danisma where kimlik = " + DanışmaGiriş.kimlik;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["ad"].ToString() + " " + reader["soyad"].ToString();
                textBox2.Text = reader["kimlik"].ToString();
                tckimlikno = reader["kimlik"].ToString();
            }
            pictureBox1.ImageLocation = Helper.ProfilPath(tckimlikno, type);
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
