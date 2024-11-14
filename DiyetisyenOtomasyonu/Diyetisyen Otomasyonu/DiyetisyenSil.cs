using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DiyetisyenSil : Form
    {
        public DiyetisyenSil()
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
            string sql = "SELECT * FROM diyetisyen";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = connecting;
            conn.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string kimlik = selectedRow.Cells["kimlik"].Value.ToString();

                DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deletesql = "DELETE FROM diyetisyen WHERE kimlik = @kimlik";
                    MySqlCommand deletecmd = new MySqlCommand(deletesql, conn);
                    deletecmd.Parameters.AddWithValue("@kimlik", kimlik);
                    deletecmd.ExecuteNonQuery();

                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            conn.Close();
            Listele();
        }

        private void DiyetisyenSil_Load(object sender, EventArgs e)
        {
            Listele();
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

        private void diyetisyenBilgileriGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiyetisyenGüncelle git = new DiyetisyenGüncelle();
            git.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPaneli git = new AdminPaneli();
            git.Show();
            this.Hide();
        }
    }
}
