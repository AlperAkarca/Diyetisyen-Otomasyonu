﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DanışmaGiriş : Form
    {
        public DanışmaGiriş()
        {
            InitializeComponent();
        }
        static public string kimlik;
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.hidden;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                button1.BackgroundImage = WindowsFormsApp11.Properties.Resources.eye;
            }
        }

        private void DanışmaGiriş_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool kullanicivarmi = false;

            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "select * from  danisma where kullanici_adi = '" + textBox1.Text.ToString() + "' and sifre ='" + textBox2.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                kullanicivarmi = true;
                kimlik = reader["kimlik"].ToString();
            }
            if (kullanicivarmi)
            {

                DanışmaPanel user = new DanışmaPanel();
                user.Show();
                this.Hide();

            }
            else if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Bu alan boş bırakılamaz");
                errorProvider1.SetError(textBox2, "Bu alan boş bırakılamaz");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
            conn.Close();
        }
    }
}
