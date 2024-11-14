using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp11
{
    public partial class RandevuArama : Form
    {
        public RandevuArama()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "kadın")
            {
                radioButton1.Checked = true;
            }
            else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "erkek")
            {
                radioButton2.Checked = true;
            }
            textBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();

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

           
        }

        private void RandevuArama_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    
                    int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    
                    string query = "SELECT dosya FROM randevu WHERE id = @Id";

                   
                    using (MySqlConnection connection = new MySqlConnection(connecting))
                    {
                        connection.Open();

                        
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            
                            command.Parameters.AddWithValue("@Id", selectedId);

                        
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read()) 
                                {
                                  
                                    byte[] pdfData = (byte[])reader["dosya"];

                                
                                    string tempFilePath = Path.GetTempFileName() + ".pdf";
                                    File.WriteAllBytes(tempFilePath, pdfData);

                                   
                                    System.Diagnostics.Process.Start(tempFilePath);
                                }
                                else
                                {
                                    MessageBox.Show("PDF dosyası bulunamadı.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir veri seçin.");
            }
        }
    }
}
