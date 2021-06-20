
namespace HMATarimsalBorsa
{
    partial class Form_Rapor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Rapor));
            this.dataGridView_islemGecmisi = new System.Windows.Forms.DataGridView();
            this.button_raporla = new System.Windows.Forms.Button();
            this.button_filtrele = new System.Windows.Forms.Button();
            this.dateTimePicker_ilkTarih = new System.Windows.Forms.DateTimePicker();
            this.label_ilkTarih = new System.Windows.Forms.Label();
            this.label_sonTarih = new System.Windows.Forms.Label();
            this.dateTimePicker_sonTarih = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_islemGecmisi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_islemGecmisi
            // 
            this.dataGridView_islemGecmisi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_islemGecmisi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dataGridView_islemGecmisi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_islemGecmisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView_islemGecmisi.Location = new System.Drawing.Point(1, 42);
            this.dataGridView_islemGecmisi.Name = "dataGridView_islemGecmisi";
            this.dataGridView_islemGecmisi.Size = new System.Drawing.Size(767, 368);
            this.dataGridView_islemGecmisi.TabIndex = 0;
            // 
            // button_raporla
            // 
            this.button_raporla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_raporla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_raporla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_raporla.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_raporla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_raporla.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_raporla.Location = new System.Drawing.Point(0, 413);
            this.button_raporla.Margin = new System.Windows.Forms.Padding(4);
            this.button_raporla.Name = "button_raporla";
            this.button_raporla.Size = new System.Drawing.Size(769, 37);
            this.button_raporla.TabIndex = 4;
            this.button_raporla.Text = "Rapor Al";
            this.button_raporla.UseVisualStyleBackColor = false;
            this.button_raporla.Click += new System.EventHandler(this.button_raporla_Click);
            // 
            // button_filtrele
            // 
            this.button_filtrele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_filtrele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_filtrele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_filtrele.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_filtrele.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_filtrele.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_filtrele.Location = new System.Drawing.Point(443, 7);
            this.button_filtrele.Margin = new System.Windows.Forms.Padding(4);
            this.button_filtrele.Name = "button_filtrele";
            this.button_filtrele.Size = new System.Drawing.Size(313, 29);
            this.button_filtrele.TabIndex = 5;
            this.button_filtrele.Text = "Filtrele";
            this.button_filtrele.UseVisualStyleBackColor = false;
            this.button_filtrele.Click += new System.EventHandler(this.button_filtrele_Click);
            // 
            // dateTimePicker_ilkTarih
            // 
            this.dateTimePicker_ilkTarih.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_ilkTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dateTimePicker_ilkTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ilkTarih.Location = new System.Drawing.Point(134, 10);
            this.dateTimePicker_ilkTarih.Name = "dateTimePicker_ilkTarih";
            this.dateTimePicker_ilkTarih.Size = new System.Drawing.Size(101, 24);
            this.dateTimePicker_ilkTarih.TabIndex = 6;
            // 
            // label_ilkTarih
            // 
            this.label_ilkTarih.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_ilkTarih.AutoSize = true;
            this.label_ilkTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label_ilkTarih.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_ilkTarih.Location = new System.Drawing.Point(12, 13);
            this.label_ilkTarih.Name = "label_ilkTarih";
            this.label_ilkTarih.Size = new System.Drawing.Size(116, 18);
            this.label_ilkTarih.TabIndex = 7;
            this.label_ilkTarih.Text = "Başlangıç Tarihi:";
            // 
            // label_sonTarih
            // 
            this.label_sonTarih.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_sonTarih.AutoSize = true;
            this.label_sonTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label_sonTarih.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_sonTarih.Location = new System.Drawing.Point(248, 13);
            this.label_sonTarih.Name = "label_sonTarih";
            this.label_sonTarih.Size = new System.Drawing.Size(80, 18);
            this.label_sonTarih.TabIndex = 9;
            this.label_sonTarih.Text = "Bitiş Tarihi:";
            // 
            // dateTimePicker_sonTarih
            // 
            this.dateTimePicker_sonTarih.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_sonTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dateTimePicker_sonTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_sonTarih.Location = new System.Drawing.Point(335, 9);
            this.dateTimePicker_sonTarih.Name = "dateTimePicker_sonTarih";
            this.dateTimePicker_sonTarih.Size = new System.Drawing.Size(101, 24);
            this.dateTimePicker_sonTarih.TabIndex = 8;
            // 
            // Form_Rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(769, 450);
            this.Controls.Add(this.label_sonTarih);
            this.Controls.Add(this.dateTimePicker_sonTarih);
            this.Controls.Add(this.label_ilkTarih);
            this.Controls.Add(this.dateTimePicker_ilkTarih);
            this.Controls.Add(this.button_filtrele);
            this.Controls.Add(this.button_raporla);
            this.Controls.Add(this.dataGridView_islemGecmisi);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Rapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HMA Tarımsal Borsa Uygulaması - Rapor Oluşturma Sihirbazı";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_islemGecmisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_islemGecmisi;
        private System.Windows.Forms.Button button_raporla;
        private System.Windows.Forms.Button button_filtrele;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ilkTarih;
        private System.Windows.Forms.Label label_ilkTarih;
        private System.Windows.Forms.Label label_sonTarih;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sonTarih;
    }
}