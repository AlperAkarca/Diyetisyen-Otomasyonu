﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class DanışmaBilgileriGüncelleme : Form
    {
        public DanışmaBilgileriGüncelleme()
        {
            InitializeComponent();
        }
        string connecting = "server=localhost;uid=root;pwd=1234;database=diyetisyen_db";
        MySqlConnection conn = new MySqlConnection();
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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                conn.Open();
                string sql = "UPDATE danisma SET kullanici_adi=@kullaniciAdi, sifre=@sifre, telefon=@telefon WHERE kimlik=@kimlik";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                cmd.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@kimlik", DanışmaGiriş.kimlik);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bilgileriniz Güncellendi");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Şifre Tekrar Şifre(Yeni) ile uyuşmuyor");
            }
        }

        private void DanışmaBilgileriGüncelleme_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;

            conn.ConnectionString = connecting;
            conn.Open();
            string sql = "select kullanici_adi,sifre,telefon from danisma where kimlik = " + DanışmaGiriş.kimlik;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["kullanici_adi"].ToString();
                textBox2.Text = reader["sifre"].ToString();
                maskedTextBox1.Text = reader["telefon"].ToString();
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DanışmaPanel git = new DanışmaPanel();
            git.Show();
            this.Hide();
        }
    }
}
