using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DuyuruAdmin : Form
    {

        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();

        private DuyuruManager duyuruManager;

        public DuyuruAdmin()
        {
            InitializeComponent();
            duyuruManager = new DuyuruManager();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }


        private void Duyurular()
        {

            string query = "SELECT * FROM duyuru";

            using (MySqlConnection conn = new MySqlConnection(connecting))
            {
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
        public class DuyuruManager
        {
            string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
            MySqlConnection conn = new MySqlConnection();
            public void DuyurulariKontrolEtVeSil()
            {
                using (MySqlConnection connection = new MySqlConnection(connecting))
                {
                    string sql = "DELETE FROM duyuru WHERE olusturulma_zamani < DATE_SUB(NOW(), INTERVAL 1 MINUTE)";

                    try
                    {
                        connection.Open();

                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        // Hata yönetimi kodunu burada gerçekleştirin
                        MessageBox.Show("MySQL Hatası: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            git.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Duyurular();
            duyuruManager.DuyurulariKontrolEtVeSil();
            dataGridView1.Columns[0].Visible = false;
        }

        private void DuyuruAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}

