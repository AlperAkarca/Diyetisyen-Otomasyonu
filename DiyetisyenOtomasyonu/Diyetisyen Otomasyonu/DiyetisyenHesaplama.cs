using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp11
{
    public partial class DiyetisyenHesaplama : Form
    {
        public DiyetisyenHesaplama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                double boy, kilo, vki;
                boy = Convert.ToDouble(textBox1.Text) / 100;
                kilo = Convert.ToDouble(textBox2.Text);
                vki = kilo / (boy * boy);

                bool hasError = false; 

                if (boy < 0.4 || boy > 2.50)
                {
                    MessageBox.Show("Lütfen geçerli bir boy(cm) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (kilo < 50 || kilo > 300)
                {
                    MessageBox.Show("Lütfen geçerli bir kilo(kg) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (!hasError)
                {
                    
                    if (vki < 18)
                    {
                        label32.Text = "Zayıf";
                        label31.Text = Convert.ToString(vki);
                    }
                    else if (vki >= 18 && vki < 25)
                    {
                        label32.Text = "Normal";
                        label31.Text = Convert.ToString(vki);
                    }
                    else if (vki >= 25 && vki < 30)
                    {
                        label32.Text = "Kilolu";
                        label31.Text = Convert.ToString(vki);
                    }
                    else if (vki >= 30 && vki < 35)
                    {
                        label32.Text = "Obez";
                        label31.Text = Convert.ToString(vki);
                    }
                    else
                    {
                        label32.Text = "Ciddi Obez";
                        label31.Text = Convert.ToString(vki);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                double boy, kilo;
                boy = Convert.ToDouble(textBox4.Text);
                kilo = Convert.ToDouble(textBox3.Text);

                bool hasError = false; 

                if (boy < 40 || boy > 250)
                {
                    MessageBox.Show("Lütfen geçerli bir boy(cm) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (kilo < 50 || kilo > 300)
                {
                    MessageBox.Show("Lütfen geçerli bir kilo(kg) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (!hasError)
                {
                    if (radioButton4.Checked == true)
                    {
                        label34.Text = Convert.ToString(Math.Round(45.5 + 2.3 * ((boy / 2.54) - 60)));
                    }
                    else if (radioButton3.Checked == true)
                    {
                        label34.Text = Convert.ToString(Math.Round(50 + 2.3 * ((boy / 2.54) - 60)));
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text))
            {
                double boy, kilo;
                int yas;
                boy = Convert.ToDouble(textBox6.Text);
                kilo = Convert.ToDouble(textBox5.Text);
                yas = Convert.ToInt32(textBox7.Text);

                bool hasError = false; 

                if (boy < 40 || boy > 250)
                {
                    MessageBox.Show("Lütfen geçerli bir boy(cm) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (kilo < 50 || kilo > 300)
                {
                    MessageBox.Show("Lütfen geçerli bir kilo(kg) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }
                if (yas > 100 || yas < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir yaş giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (!hasError)
                {
                    if (radioButton6.Checked == true)
                    {
                        label35.Text = Convert.ToString(Math.Round(655.1 + (9.56 * kilo) + (1.85 * boy) - (4.68 * yas)));
                    }
                    else if (radioButton5.Checked == true)
                    {
                        label35.Text = Convert.ToString(Math.Round(66.5 + (13.75 * kilo) + (5.03 * boy) - (6.75 * yas)));
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrEmpty(textBox10.Text))
            {
                double boy, kilo;
                int yas;
                boy = Convert.ToDouble(textBox10.Text);
                kilo = Convert.ToDouble(textBox9.Text);
                yas = Convert.ToInt32(textBox8.Text);

                bool hasError = false; 

                if (boy < 40 || boy > 250)
                {
                    MessageBox.Show("Lütfen geçerli bir boy(cm) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (kilo < 50 || kilo > 300)
                {
                    MessageBox.Show("Lütfen geçerli bir kilo(kg) giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }
                if (yas > 100 || yas < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir yaş giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hasError = true; 
                }

                if (!hasError)
                {
                    if (radioButton6.Checked == true)
                    {
                        double sonuc = 655.1 + (9.56 * kilo) + (1.85 * boy) - (4.68 * yas);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            sonuc = sonuc * 1.2;
                        }
                        else if(comboBox1.SelectedIndex == 1)
                        {
                            sonuc = sonuc * 1.375;
                        }
                        else if (comboBox1.SelectedIndex == 2)
                        {
                            sonuc = sonuc * 1.55;
                        }
                        else if (comboBox1.SelectedIndex == 3)
                        {
                            sonuc = sonuc * 1.725;
                        }
                        else if (comboBox1.SelectedIndex == 4)
                        {
                            sonuc = sonuc * 1.9;
                        }
                        label36.Text = Convert.ToString(sonuc) + "kcal/gün";
                    }
                    else if (radioButton7.Checked == true)
                    {
                        double sonuc = 66.5 + (13.75 * kilo) + (5.03 * boy) - (6.75 * yas);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            sonuc = sonuc * 1.2;
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            sonuc = sonuc * 1.375;
                        }
                        else if (comboBox1.SelectedIndex == 2)
                        {
                            sonuc = sonuc * 1.55;
                        }
                        else if (comboBox1.SelectedIndex == 3)
                        {
                            sonuc = sonuc * 1.725;
                        }
                        else if (comboBox1.SelectedIndex == 4)
                        {
                            sonuc = sonuc * 1.9;
                        }
                        label36.Text = Convert.ToString(sonuc) + "kcal/gün";
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox9.Clear();  
            textBox10.Clear();
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiyetisyenHastaPanel git = new DiyetisyenHastaPanel();
            git.Show();
            this.Hide();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
