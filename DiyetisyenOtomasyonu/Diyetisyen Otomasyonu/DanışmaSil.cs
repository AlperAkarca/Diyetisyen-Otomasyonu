using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DanışmaSil : Form
    {
        public DanışmaSil()
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
            string sql = "SELECT * FROM danisma";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void sekreterEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanışmaEkle git = new DanışmaEkle();
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

        private void diyetisyenBilgileriGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiyetisyenGüncelle git = new DiyetisyenGüncelle();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int kimlik = Convert.ToInt32(selectedRow.Cells["kimlik"].Value);

                DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    string deletesql = "DELETE FROM danisma WHERE kimlik = @kimlik";
                    MySqlCommand deletecmd = new MySqlCommand(deletesql, conn);
                    deletecmd.Parameters.AddWithValue("@kimlik", kimlik);
                    deletecmd.ExecuteNonQuery();

                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            conn.Close();
            Listele();
        }

        private void DanışmaSil_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            git.Show();
            this.Hide();
        }
    }
}
