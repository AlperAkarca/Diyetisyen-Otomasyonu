using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DiyetisyenPanel : Form
    {
        public DiyetisyenPanel()
        {
            InitializeComponent();
        }

        string type = "diyetisyen";
        string tckimlikno = "";
        string diyetisyenFoto = "";
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        void Listele()
        {

            string connectionString = connecting;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string bugün = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM randevu WHERE diyetisyen_kimlik=@kimlik AND tarih = @tarih";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kimlik", DiyetisyenGiriş.kimlik);
                cmd.Parameters.AddWithValue("@tarih", bugün);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }


        private void randevularımToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DanışmaPanel frm7 = new DanışmaPanel();
            this.Hide();
            frm7.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Fotoğraf Seçiniz(.jpg; .png;.gif)|.jpg;.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                diyetisyenFoto = opf.FileName;
            }
        }

        private void DiyetisyenPanel_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "select ad,soyad,kimlik,resim from  diyetisyen where kimlik = " + DiyetisyenGiriş.kimlik;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["ad"].ToString() + " " + reader["soyad"].ToString();
                textBox2.Text = reader["kimlik"].ToString();
                tckimlikno = reader["kimlik"].ToString();
            }
            Listele();
            pictureBox1.ImageLocation = Helper.ProfilPath(tckimlikno, type);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DuyuruDiyetisyencs git = new DuyuruDiyetisyencs();
            git.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiyetisyenGiriş git = new DiyetisyenGiriş();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 git = new Form9();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tckimlikno))
            {
                File.Copy(diyetisyenFoto, $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Images/Diyetisyen/{tckimlikno}.jpg", true);
                MessageBox.Show("Resim Kayıt Edildi.");
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Fotoğraf Seçiniz(*.jpg; * *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                diyetisyenFoto = opf.FileName;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        static public string ad;
        static public string soyad;
        static public string dogum_tarihi;
        static public string sikayet;
        static public string id;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ad = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            soyad = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dogum_tarihi = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            sikayet = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DiyetisyenHastaPanel git = new DiyetisyenHastaPanel();
                git.Show();
                this.Hide();

            }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            RandevuArama git = new RandevuArama();
            git.Show();
            this.Hide();
        }
    }
    }
