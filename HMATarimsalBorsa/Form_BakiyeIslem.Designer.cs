
namespace HMATarimsalBorsa
{
    partial class Form_BakiyeIslem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BakiyeIslem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_onayBekleyenIslemler = new System.Windows.Forms.Button();
            this.button_islemGecmisi = new System.Windows.Forms.Button();
            this.groupBox_dovizCinsi = new System.Windows.Forms.GroupBox();
            this.button_cekmeIslemi = new System.Windows.Forms.Button();
            this.textBox_bakiyeIslemMiktari = new System.Windows.Forms.TextBox();
            this.button_esklemeIslemi = new System.Windows.Forms.Button();
            this.comboBox_dovizKuru = new System.Windows.Forms.ComboBox();
            this.groupBox_miktar = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox_dovizCinsi.SuspendLayout();
            this.groupBox_miktar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox_miktar);
            this.panel1.Controls.Add(this.groupBox_dovizCinsi);
            this.panel1.Location = new System.Drawing.Point(31, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 350);
            this.panel1.TabIndex = 0;
            // 
            // button_onayBekleyenIslemler
            // 
            this.button_onayBekleyenIslemler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_onayBekleyenIslemler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_onayBekleyenIslemler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_onayBekleyenIslemler.Location = new System.Drawing.Point(10, 97);
            this.button_onayBekleyenIslemler.Margin = new System.Windows.Forms.Padding(4);
            this.button_onayBekleyenIslemler.Name = "button_onayBekleyenIslemler";
            this.button_onayBekleyenIslemler.Size = new System.Drawing.Size(190, 32);
            this.button_onayBekleyenIslemler.TabIndex = 10;
            this.button_onayBekleyenIslemler.Text = "Onay Bekleyen İşlemler";
            this.button_onayBekleyenIslemler.UseVisualStyleBackColor = false;
            this.button_onayBekleyenIslemler.Click += new System.EventHandler(this.button_onayBekleyenIslemler_Click);
            // 
            // button_islemGecmisi
            // 
            this.button_islemGecmisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_islemGecmisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_islemGecmisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_islemGecmisi.Location = new System.Drawing.Point(10, 57);
            this.button_islemGecmisi.Margin = new System.Windows.Forms.Padding(4);
            this.button_islemGecmisi.Name = "button_islemGecmisi";
            this.button_islemGecmisi.Size = new System.Drawing.Size(190, 32);
            this.button_islemGecmisi.TabIndex = 9;
            this.button_islemGecmisi.Text = "İşlem Geçmişi";
            this.button_islemGecmisi.UseVisualStyleBackColor = false;
            this.button_islemGecmisi.Click += new System.EventHandler(this.button_islemGecmisi_Click);
            // 
            // groupBox_dovizCinsi
            // 
            this.groupBox_dovizCinsi.Controls.Add(this.comboBox_dovizKuru);
            this.groupBox_dovizCinsi.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox_dovizCinsi.Location = new System.Drawing.Point(20, 15);
            this.groupBox_dovizCinsi.Name = "groupBox_dovizCinsi";
            this.groupBox_dovizCinsi.Size = new System.Drawing.Size(213, 66);
            this.groupBox_dovizCinsi.TabIndex = 8;
            this.groupBox_dovizCinsi.TabStop = false;
            this.groupBox_dovizCinsi.Text = "Doviz Cinsi";
            // 
            // button_cekmeIslemi
            // 
            this.button_cekmeIslemi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_cekmeIslemi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cekmeIslemi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_cekmeIslemi.Location = new System.Drawing.Point(109, 17);
            this.button_cekmeIslemi.Margin = new System.Windows.Forms.Padding(4);
            this.button_cekmeIslemi.Name = "button_cekmeIslemi";
            this.button_cekmeIslemi.Size = new System.Drawing.Size(91, 32);
            this.button_cekmeIslemi.TabIndex = 7;
            this.button_cekmeIslemi.Text = "Çek";
            this.button_cekmeIslemi.UseVisualStyleBackColor = false;
            this.button_cekmeIslemi.Click += new System.EventHandler(this.button_cekmeIslemi_Click);
            // 
            // textBox_bakiyeIslemMiktari
            // 
            this.textBox_bakiyeIslemMiktari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.textBox_bakiyeIslemMiktari.Location = new System.Drawing.Point(10, 24);
            this.textBox_bakiyeIslemMiktari.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_bakiyeIslemMiktari.Name = "textBox_bakiyeIslemMiktari";
            this.textBox_bakiyeIslemMiktari.Size = new System.Drawing.Size(190, 26);
            this.textBox_bakiyeIslemMiktari.TabIndex = 5;
            this.textBox_bakiyeIslemMiktari.Text = "275,00";
            this.textBox_bakiyeIslemMiktari.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_esklemeIslemi
            // 
            this.button_esklemeIslemi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_esklemeIslemi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_esklemeIslemi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_esklemeIslemi.Location = new System.Drawing.Point(10, 17);
            this.button_esklemeIslemi.Margin = new System.Windows.Forms.Padding(4);
            this.button_esklemeIslemi.Name = "button_esklemeIslemi";
            this.button_esklemeIslemi.Size = new System.Drawing.Size(91, 32);
            this.button_esklemeIslemi.TabIndex = 6;
            this.button_esklemeIslemi.Text = "Ekle";
            this.button_esklemeIslemi.UseVisualStyleBackColor = false;
            this.button_esklemeIslemi.Click += new System.EventHandler(this.button_esklemeIslemi_Click);
            // 
            // comboBox_dovizKuru
            // 
            this.comboBox_dovizKuru.FormattingEnabled = true;
            this.comboBox_dovizKuru.Items.AddRange(new object[] {
            "TRY",
            "USD",
            "EUR",
            "RUB"});
            this.comboBox_dovizKuru.Location = new System.Drawing.Point(10, 23);
            this.comboBox_dovizKuru.Name = "comboBox_dovizKuru";
            this.comboBox_dovizKuru.Size = new System.Drawing.Size(192, 26);
            this.comboBox_dovizKuru.TabIndex = 1;
            // 
            // groupBox_miktar
            // 
            this.groupBox_miktar.Controls.Add(this.textBox_bakiyeIslemMiktari);
            this.groupBox_miktar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox_miktar.Location = new System.Drawing.Point(20, 99);
            this.groupBox_miktar.Name = "groupBox_miktar";
            this.groupBox_miktar.Size = new System.Drawing.Size(213, 66);
            this.groupBox_miktar.TabIndex = 9;
            this.groupBox_miktar.TabStop = false;
            this.groupBox_miktar.Text = "Doviz Cinsi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_esklemeIslemi);
            this.groupBox1.Controls.Add(this.button_cekmeIslemi);
            this.groupBox1.Controls.Add(this.button_onayBekleyenIslemler);
            this.groupBox1.Controls.Add(this.button_islemGecmisi);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(20, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 142);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // Form_BakiyeIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(305, 402);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_BakiyeIslem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bakiye İşlem";
            this.panel1.ResumeLayout(false);
            this.groupBox_dovizCinsi.ResumeLayout(false);
            this.groupBox_miktar.ResumeLayout(false);
            this.groupBox_miktar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_islemGecmisi;
        private System.Windows.Forms.GroupBox groupBox_dovizCinsi;
        private System.Windows.Forms.Button button_cekmeIslemi;
        private System.Windows.Forms.TextBox textBox_bakiyeIslemMiktari;
        private System.Windows.Forms.Button button_esklemeIslemi;
        private System.Windows.Forms.Button button_onayBekleyenIslemler;
        private System.Windows.Forms.ComboBox comboBox_dovizKuru;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_miktar;
    }
}