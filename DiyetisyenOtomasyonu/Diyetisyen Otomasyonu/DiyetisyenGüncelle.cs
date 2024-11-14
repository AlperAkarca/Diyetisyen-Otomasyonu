using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DiyetisyenGüncelle : Form
    {
        public DiyetisyenGüncelle()
        {
            InitializeComponent();
        }
        void Listele()
        {
            conn.ConnectionString = connecting;
            conn.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM diyetisyen";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string kimlik = selectedRow.Cells["kimlik"].Value.ToString();

                DialogResult result = MessageBox.Show("Kayıtlı diyetisyen'i güncellemek istediğinizden emin misiniz?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes && textBox6.Text == textBox7.Text)
                {
                    string updateQuery = "UPDATE diyetisyen SET telefon = @telefon, kullanici_adi = @kullanici_adi, sifre = @sifre, brans=@brans WHERE kimlik = @kimlik";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, conn);

                    updateCommand.Parameters.AddWithValue("@kimlik", kimlik);
                    updateCommand.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
                    updateCommand.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                    updateCommand.Parameters.AddWithValue("@sifre", textBox6.Text);
                    updateCommand.Parameters.AddWithValue("@brans", comboBox1.Text);
                    updateCommand.ExecuteNonQuery();

                    dataGridView1.Rows.Remove(selectedRow);
                }
                else
                {
                    MessageBox.Show("Şifre Tekrar Şifre(Yeni) ile uyuşmuyor");
                }
            }
            conn.Close();
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.UseSystemPasswordChar == true)
            {
                textBox6.UseSystemPasswordChar = false;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.hidden;
            }
            else
            {
                textBox6.UseSystemPasswordChar = true;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.eye;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "kadın" || dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Kadın")
            {
                radioButton1.Checked = true;
            }
            else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "erkek" || dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Erkek")
            {
                radioButton2.Checked = true;
            }

            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void DiyetisyenGüncelle_Load(object sender, EventArgs e)
        {
            Listele();
            textBox6.UseSystemPasswordChar = true;
            textBox7.UseSystemPasswordChar = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            git.Show();
            this.Hide();
        }

        private void sekreterEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanışmaEkle git = new DanışmaEkle();
            git.Show();
            this.Hide();
        }

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


    }
}
