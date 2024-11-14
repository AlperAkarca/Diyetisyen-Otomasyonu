
namespace WindowsFormsApp11
{
    partial class DiyetisyenSil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sektreterKontrolüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sekreterEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sekreterSilmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sekreterBilgileriGüncellemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diyetisyenKontrolüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diyetisyenEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diyetisyenBilgileriGüncellemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(61, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 260);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diyetisyen Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(858, 234);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sektreterKontrolüToolStripMenuItem,
            this.diyetisyenKontrolüToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 27);
            this.menuStrip1.TabIndex = 86;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sektreterKontrolüToolStripMenuItem
            // 
            this.sektreterKontrolüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sekreterEkleToolStripMenuItem,
            this.sekreterSilmeToolStripMenuItem,
            this.sekreterBilgileriGüncellemeToolStripMenuItem});
            this.sektreterKontrolüToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.sektreterKontrolüToolStripMenuItem.Name = "sektreterKontrolüToolStripMenuItem";
            this.sektreterKontrolüToolStripMenuItem.Size = new System.Drawing.Size(140, 23);
            this.sektreterKontrolüToolStripMenuItem.Text = "Danışma Kontrolü";
            // 
            // sekreterEkleToolStripMenuItem
            // 
            this.sekreterEkleToolStripMenuItem.Name = "sekreterEkleToolStripMenuItem";
            this.sekreterEkleToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.sekreterEkleToolStripMenuItem.Text = "Danışma Ekleme";
            this.sekreterEkleToolStripMenuItem.Click += new System.EventHandler(this.sekreterEkleToolStripMenuItem_Click);
            // 
            // sekreterSilmeToolStripMenuItem
            // 
            this.sekreterSilmeToolStripMenuItem.Name = "sekreterSilmeToolStripMenuItem";
            this.sekreterSilmeToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.sekreterSilmeToolStripMenuItem.Text = "Danışma Silme";
            this.sekreterSilmeToolStripMenuItem.Click += new System.EventHandler(this.sekreterSilmeToolStripMenuItem_Click);
            // 
            // sekreterBilgileriGüncellemeToolStripMenuItem
            // 
            this.sekreterBilgileriGüncellemeToolStripMenuItem.Name = "sekreterBilgileriGüncellemeToolStripMenuItem";
            this.sekreterBilgileriGüncellemeToolStripMenuItem.Size = new System.Drawing.Size(273, 24);
            this.sekreterBilgileriGüncellemeToolStripMenuItem.Text = "Danışma Bilgileri Güncelleme";
            this.sekreterBilgileriGüncellemeToolStripMenuItem.Click += new System.EventHandler(this.sekreterBilgileriGüncellemeToolStripMenuItem_Click);
            // 
            // diyetisyenKontrolüToolStripMenuItem
            // 
            this.diyetisyenKontrolüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diyetisyenEkleToolStripMenuItem,
            this.diyetisyenBilgileriGüncellemeToolStripMenuItem});
            this.diyetisyenKontrolüToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.diyetisyenKontrolüToolStripMenuItem.Name = "diyetisyenKontrolüToolStripMenuItem";
            this.diyetisyenKontrolüToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.diyetisyenKontrolüToolStripMenuItem.Text = "Diyetisyen Kontrolü";
            // 
            // diyetisyenEkleToolStripMenuItem
            // 
            this.diyetisyenEkleToolStripMenuItem.Name = "diyetisyenEkleToolStripMenuItem";
            this.diyetisyenEkleToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.diyetisyenEkleToolStripMenuItem.Text = "Diyetisyen Ekle";
            this.diyetisyenEkleToolStripMenuItem.Click += new System.EventHandler(this.diyetisyenEkleToolStripMenuItem_Click);
            // 
            // diyetisyenBilgileriGüncellemeToolStripMenuItem
            // 
            this.diyetisyenBilgileriGüncellemeToolStripMenuItem.Name = "diyetisyenBilgileriGüncellemeToolStripMenuItem";
            this.diyetisyenBilgileriGüncellemeToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.diyetisyenBilgileriGüncellemeToolStripMenuItem.Text = "Diyetisyen Bilgileri Güncelleme";
            this.diyetisyenBilgileriGüncellemeToolStripMenuItem.Click += new System.EventHandler(this.diyetisyenBilgileriGüncellemeToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateGray;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(391, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 40);
            this.button2.TabIndex = 87;
            this.button2.Text = "Seçili Diyetisyeni Sil";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::WindowsFormsApp11.Properties.Resources.back;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(12, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 88;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DiyetisyenSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(964, 434);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.Name = "DiyetisyenSil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diyetisyen Silme Ekranı";
            this.Load += new System.EventHandler(this.DiyetisyenSil_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sektreterKontrolüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sekreterEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sekreterSilmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sekreterBilgileriGüncellemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diyetisyenKontrolüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diyetisyenEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diyetisyenBilgileriGüncellemeToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}