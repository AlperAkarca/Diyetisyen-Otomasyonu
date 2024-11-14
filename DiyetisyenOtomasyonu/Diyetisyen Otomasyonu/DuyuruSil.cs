using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DuyuruSil : Form
    {
        public DuyuruSil()
        {
            InitializeComponent();
        }

        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();

        void Listele()
        {
            conn.ConnectionString = connecting;
            conn.Open();
            DataTable dt = new DataTable();
            string sql = "SELECT id,aciklama,kime,konu FROM duyuru";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            this.Hide();
            git.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                DialogResult result = MessageBox.Show("Kayıtlı duyuruyu silmek istediğinizden emin misiniz?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    string deleteQuery = "DELETE FROM duyuru WHERE id = @RecordId";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);
                    deleteCommand.Parameters.AddWithValue("@RecordId", id);
                    deleteCommand.ExecuteNonQuery();

                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            conn.Close();
            Listele();
        }

        private void DuyuruSil_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}

