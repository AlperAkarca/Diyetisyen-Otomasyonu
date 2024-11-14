using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp11
{
    public partial class DiyetisyenHastaPanel : Form
    {
        public DiyetisyenHastaPanel()
        {
            InitializeComponent();
        }

        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();

        DiyetisyenHesaplama git = new DiyetisyenHesaplama();

        private void button5_Click(object sender, EventArgs e)
        {
            git.Show();
            this.Hide();
            git.tabControl1.SelectedTab = git.tabPage1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            git.Show();
            this.Hide();
            git.tabControl1.SelectedTab = git.tabPage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            git.Show();
            this.Hide();
            git.tabControl1.SelectedTab = git.tabPage3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            git.Show();
            this.Hide();
            git.tabControl1.SelectedTab = git.tabPage4;
        }

       
        private void button9_Click(object sender, EventArgs e)
        {
            PDF git = new PDF();
            git.Show();

            string pdfFilePath = @"C:\Users\AA113\source\repos\DiyetisyenOtomasyonu\Diyetisyen Otomasyonu\Images\kalori_cetveli.pdf";

            if (File.Exists(pdfFilePath))
            {
                git.axAcroPDF1.LoadFile(pdfFilePath);
            }
            else
            {
                MessageBox.Show("PDF dosyası bulunamadı.");
            }


        }

        private void DiyetisyenHastaPanel_Load(object sender, EventArgs e)
        {
            textBox1.Text = DiyetisyenPanel.sikayet;
            textBox2.Text = DiyetisyenPanel.ad;
            textBox3.Text = DiyetisyenPanel.soyad;
            textBox6.Visible = false;
            dateTimePicker1.Text = DiyetisyenPanel.dogum_tarihi;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                conn.ConnectionString = connecting;
                conn.Open();


                DialogResult result = MessageBox.Show("Kayıtlı bilgileri güncellemek istediğinizden emin misiniz?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string updatequery = "UPDATE randevu SET boy = @boy, kilo = @kilo, hedef = @hedef, hastaliklar = @hastaliklar, alerjiler = @alerjiler, kullanilan_ilaclar = @kullanilan_ilaclar, operasyon_gecmisi = @operasyon_gecmisi, diyetisyen_notu = @diyetisyen_notu   WHERE id = @RecordId";
                    MySqlCommand updateCommand = new MySqlCommand(updatequery, conn);
                    updateCommand.Parameters.AddWithValue("@RecordId", DiyetisyenPanel.id);
                    updateCommand.Parameters.AddWithValue("@boy", textBox4.Text);
                    updateCommand.Parameters.AddWithValue("@kilo", textBox5.Text);

                    updateCommand.Parameters.AddWithValue("@hedef", textBox7.Text);
                    updateCommand.Parameters.AddWithValue("@hastaliklar", textBox8.Text);
                    updateCommand.Parameters.AddWithValue("@alerjiler", textBox9.Text);
                    updateCommand.Parameters.AddWithValue("@kullanilan_ilaclar", textBox10.Text);
                    updateCommand.Parameters.AddWithValue("@operasyon_gecmisi", textBox11.Text);
                    updateCommand.Parameters.AddWithValue("@diyetisyen_notu", textBox12.Text);
                    updateCommand.ExecuteNonQuery();

                    string filePath = textBox6.Text;
                    if (string.IsNullOrEmpty(filePath))
                    {
                        MessageBox.Show("Yüklemek istediğiniz dosyayı seçiniz.");
                        return;
                    }

                    try
                    {
                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        using (conn = new MySqlConnection(connecting))
                        {
                            conn.Open();
                            string query = "UPDATE randevu SET dosya_adi = @dosya_adi, dosya = @dosya where id = @RecordId";
                            MySqlCommand command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("@RecordId", DiyetisyenPanel.id);
                            command.Parameters.AddWithValue("@dosya_adi", Path.GetFileName(filePath));
                            command.Parameters.AddWithValue("@dosya", fileBytes);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading file: " + ex.Message);
                    }

                }
            }
            conn.Close();
            MessageBox.Show("Bilgiler kaydedildi.");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.ShowDialog();
            textBox6.Text = openFileDialog.FileName;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DiyetisyenPanel git = new DiyetisyenPanel();
            git.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int hastaID = Convert.ToInt32(DiyetisyenPanel.id);

            using (MySqlConnection conn = new MySqlConnection(connecting))
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand("SELECT besin_dosya FROM randevu WHERE id = @diyetisyenID", conn);
                command.Parameters.AddWithValue("@diyetisyenID", hastaID);
                byte[] dosyaBytes = (byte[])command.ExecuteScalar();

                if (dosyaBytes != null && dosyaBytes.Length > 0)
                {
                    string tempFilePath = Path.Combine(Path.GetTempPath(), "gecici_dosya.pdf");
                    File.WriteAllBytes(tempFilePath, dosyaBytes);
                    Process.Start(tempFilePath);
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı.");
                }

            }
        }
    }
    
}
    

