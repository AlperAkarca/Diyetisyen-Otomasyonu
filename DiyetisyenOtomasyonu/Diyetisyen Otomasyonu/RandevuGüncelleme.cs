using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class RandevuGüncelleme : Form
    {
        public RandevuGüncelleme()
        {
            InitializeComponent();
        }
        void Listele()
        {
            conn.ConnectionString = connecting;
            conn.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM randevu where danisan_kimlik = @kimlik or soyad=@soyad";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@kimlik", textBox7.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox4.Text);
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
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                DialogResult result = MessageBox.Show("Kayıtlı randevuyu güncellemek istediğinizden emin misiniz?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteQuery = "UPDATE randevu SET tarih = @tarih, saat = @saat WHERE id = @RecordId";
                    MySqlCommand updateCommand = new MySqlCommand(deleteQuery, conn);
                    updateCommand.Parameters.AddWithValue("@RecordId", id);
                    updateCommand.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                    updateCommand.Parameters.AddWithValue("@saat", comboBox1.Text);
                    updateCommand.ExecuteNonQuery();

                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            conn.Close();
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "kadın")
            {
                radioButton1.Checked = true;
            }
            else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "erkek")
            {
                radioButton2.Checked = true;
            }
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            string stringValue = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            DateTime dateTimeValue;

            if (DateTime.TryParse(stringValue, out dateTimeValue))
            {
                dateTimePicker1.Value = dateTimeValue;
            }
            else
            {
                MessageBox.Show("Geçersiz tarih formatı");
            }

            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void RandevuGüncelleme_Load(object sender, EventArgs e)
        {

        }
    }
}
