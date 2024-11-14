using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Randevuİptal : Form
    {
        public Randevuİptal()
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

            cmd.Parameters.AddWithValue("@kimlik", textBox4.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox1.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                DialogResult result = MessageBox.Show("Kayıtlı randevuyu silmek istediğinizden emin misiniz?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                   
                    string deleteQuery = "DELETE FROM randevu WHERE id = @RecordId";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);
                    deleteCommand.Parameters.AddWithValue("@RecordId", id);
                    deleteCommand.ExecuteNonQuery();

                   
                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            conn.Close();
            Listele();

        }


    }
}
