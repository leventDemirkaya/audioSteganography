
namespace SesVerileriÜzerineVeriGizleme
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sesOynatici = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstbx_SesDosyalari = new System.Windows.Forms.ListBox();
            this.bt_SesDosyasiEkle = new System.Windows.Forms.Button();
            this.lbl_GizlenecekMetin = new System.Windows.Forms.Label();
            this.txt_GizlenecekMetin = new System.Windows.Forms.TextBox();
            this.bt_MesajGizle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gizlenmisMesajOynatici = new AxWMPLib.AxWindowsMediaPlayer();
            this.txt_GizlenenMesaj = new System.Windows.Forms.TextBox();
            this.lbl_GizlenenMesaj = new System.Windows.Forms.Label();
            this.Zamanlayici = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sesOynatici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gizlenmisMesajOynatici)).BeginInit();
            this.SuspendLayout();
            // 
            // sesOynatici
            // 
            this.sesOynatici.Enabled = true;
            this.sesOynatici.Location = new System.Drawing.Point(13, 13);
            this.sesOynatici.Name = "sesOynatici";
            this.sesOynatici.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sesOynatici.OcxState")));
            this.sesOynatici.Size = new System.Drawing.Size(443, 240);
            this.sesOynatici.TabIndex = 0;
            // 
            // lstbx_SesDosyalari
            // 
            this.lstbx_SesDosyalari.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstbx_SesDosyalari.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbx_SesDosyalari.FormattingEnabled = true;
            this.lstbx_SesDosyalari.ItemHeight = 15;
            this.lstbx_SesDosyalari.Location = new System.Drawing.Point(462, 13);
            this.lstbx_SesDosyalari.Name = "lstbx_SesDosyalari";
            this.lstbx_SesDosyalari.Size = new System.Drawing.Size(326, 199);
            this.lstbx_SesDosyalari.TabIndex = 1;
            this.lstbx_SesDosyalari.SelectedIndexChanged += new System.EventHandler(this.lstbx_SesDosyalari_SelectedIndexChanged);
            // 
            // bt_SesDosyasiEkle
            // 
            this.bt_SesDosyasiEkle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_SesDosyasiEkle.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SesDosyasiEkle.Location = new System.Drawing.Point(462, 218);
            this.bt_SesDosyasiEkle.Name = "bt_SesDosyasiEkle";
            this.bt_SesDosyasiEkle.Size = new System.Drawing.Size(326, 35);
            this.bt_SesDosyasiEkle.TabIndex = 2;
            this.bt_SesDosyasiEkle.Text = "Ses Dosyası Ekle";
            this.bt_SesDosyasiEkle.UseVisualStyleBackColor = false;
            this.bt_SesDosyasiEkle.Click += new System.EventHandler(this.bt_SesDosyasiEkle_Click);
            // 
            // lbl_GizlenecekMetin
            // 
            this.lbl_GizlenecekMetin.AutoSize = true;
            this.lbl_GizlenecekMetin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_GizlenecekMetin.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GizlenecekMetin.Location = new System.Drawing.Point(9, 273);
            this.lbl_GizlenecekMetin.Name = "lbl_GizlenecekMetin";
            this.lbl_GizlenecekMetin.Size = new System.Drawing.Size(228, 19);
            this.lbl_GizlenecekMetin.TabIndex = 3;
            this.lbl_GizlenecekMetin.Text = "Gizlenecek Metni Giriniz : ";
            this.lbl_GizlenecekMetin.Visible = false;
            // 
            // txt_GizlenecekMetin
            // 
            this.txt_GizlenecekMetin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_GizlenecekMetin.Enabled = false;
            this.txt_GizlenecekMetin.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GizlenecekMetin.Location = new System.Drawing.Point(231, 270);
            this.txt_GizlenecekMetin.MaxLength = 17;
            this.txt_GizlenecekMetin.Name = "txt_GizlenecekMetin";
            this.txt_GizlenecekMetin.Size = new System.Drawing.Size(546, 26);
            this.txt_GizlenecekMetin.TabIndex = 4;
            this.txt_GizlenecekMetin.Text = "17 Karaktere Kadar Gizleme Yapılabilmektedir.";
            this.txt_GizlenecekMetin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_GizlenecekMetin.Visible = false;
            this.txt_GizlenecekMetin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_GizlenecekMetin_MouseClick);
            // 
            // bt_MesajGizle
            // 
            this.bt_MesajGizle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_MesajGizle.Enabled = false;
            this.bt_MesajGizle.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_MesajGizle.Location = new System.Drawing.Point(380, 302);
            this.bt_MesajGizle.Name = "bt_MesajGizle";
            this.bt_MesajGizle.Size = new System.Drawing.Size(225, 35);
            this.bt_MesajGizle.TabIndex = 5;
            this.bt_MesajGizle.Text = "Mesajı Gizle";
            this.bt_MesajGizle.UseVisualStyleBackColor = false;
            this.bt_MesajGizle.Visible = false;
            this.bt_MesajGizle.Click += new System.EventHandler(this.bt_MesajGizle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // gizlenmisMesajOynatici
            // 
            this.gizlenmisMesajOynatici.Enabled = true;
            this.gizlenmisMesajOynatici.Location = new System.Drawing.Point(12, 343);
            this.gizlenmisMesajOynatici.Name = "gizlenmisMesajOynatici";
            this.gizlenmisMesajOynatici.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("gizlenmisMesajOynatici.OcxState")));
            this.gizlenmisMesajOynatici.Size = new System.Drawing.Size(765, 240);
            this.gizlenmisMesajOynatici.TabIndex = 6;
            this.gizlenmisMesajOynatici.Visible = false;
            // 
            // txt_GizlenenMesaj
            // 
            this.txt_GizlenenMesaj.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_GizlenenMesaj.Enabled = false;
            this.txt_GizlenenMesaj.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GizlenenMesaj.Location = new System.Drawing.Point(192, 598);
            this.txt_GizlenenMesaj.MaxLength = 17;
            this.txt_GizlenenMesaj.Name = "txt_GizlenenMesaj";
            this.txt_GizlenenMesaj.ReadOnly = true;
            this.txt_GizlenenMesaj.Size = new System.Drawing.Size(585, 26);
            this.txt_GizlenenMesaj.TabIndex = 8;
            this.txt_GizlenenMesaj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_GizlenenMesaj.Visible = false;
            // 
            // lbl_GizlenenMesaj
            // 
            this.lbl_GizlenenMesaj.AutoSize = true;
            this.lbl_GizlenenMesaj.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_GizlenenMesaj.Enabled = false;
            this.lbl_GizlenenMesaj.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GizlenenMesaj.Location = new System.Drawing.Point(9, 601);
            this.lbl_GizlenenMesaj.Name = "lbl_GizlenenMesaj";
            this.lbl_GizlenenMesaj.Size = new System.Drawing.Size(177, 19);
            this.lbl_GizlenenMesaj.TabIndex = 7;
            this.lbl_GizlenenMesaj.Text = "Gizlediginiz Mesaj : ";
            this.lbl_GizlenenMesaj.Visible = false;
            // 
            // Zamanlayici
            // 
            this.Zamanlayici.Interval = 600000;
            this.Zamanlayici.Tick += new System.EventHandler(this.Zamanlayici_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 640);
            this.Controls.Add(this.txt_GizlenenMesaj);
            this.Controls.Add(this.lbl_GizlenenMesaj);
            this.Controls.Add(this.gizlenmisMesajOynatici);
            this.Controls.Add(this.bt_MesajGizle);
            this.Controls.Add(this.txt_GizlenecekMetin);
            this.Controls.Add(this.lbl_GizlenecekMetin);
            this.Controls.Add(this.bt_SesDosyasiEkle);
            this.Controls.Add(this.lstbx_SesDosyalari);
            this.Controls.Add(this.sesOynatici);
            this.Name = "Form1";
            this.Text = "Ses Verileri Üzerine Veri Gizleme";
            ((System.ComponentModel.ISupportInitialize)(this.sesOynatici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gizlenmisMesajOynatici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer sesOynatici;
        private System.Windows.Forms.ListBox lstbx_SesDosyalari;
        private System.Windows.Forms.Button bt_SesDosyasiEkle;
        private System.Windows.Forms.Label lbl_GizlenecekMetin;
        private System.Windows.Forms.TextBox txt_GizlenecekMetin;
        private System.Windows.Forms.Button bt_MesajGizle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxWMPLib.AxWindowsMediaPlayer gizlenmisMesajOynatici;
        private System.Windows.Forms.TextBox txt_GizlenenMesaj;
        private System.Windows.Forms.Label lbl_GizlenenMesaj;
        private System.Windows.Forms.Timer Zamanlayici;
    }
}

