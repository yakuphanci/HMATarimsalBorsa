
namespace HMATarimsalBorsa
{
    partial class Form_BeklemedekiAlisEmirleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BeklemedekiAlisEmirleri));
            this.dataGridView_beklemedekiIslemler = new System.Windows.Forms.DataGridView();
            this.button_yenile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_beklemedekiIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_beklemedekiIslemler
            // 
            this.dataGridView_beklemedekiIslemler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_beklemedekiIslemler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dataGridView_beklemedekiIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_beklemedekiIslemler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView_beklemedekiIslemler.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_beklemedekiIslemler.Location = new System.Drawing.Point(2, 54);
            this.dataGridView_beklemedekiIslemler.Name = "dataGridView_beklemedekiIslemler";
            this.dataGridView_beklemedekiIslemler.Size = new System.Drawing.Size(551, 463);
            this.dataGridView_beklemedekiIslemler.TabIndex = 1;
            // 
            // button_yenile
            // 
            this.button_yenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button_yenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_yenile.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_yenile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_yenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_yenile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_yenile.Location = new System.Drawing.Point(0, 0);
            this.button_yenile.Margin = new System.Windows.Forms.Padding(4);
            this.button_yenile.Name = "button_yenile";
            this.button_yenile.Size = new System.Drawing.Size(552, 47);
            this.button_yenile.TabIndex = 6;
            this.button_yenile.Text = "Yenile";
            this.button_yenile.UseVisualStyleBackColor = false;
            this.button_yenile.Click += new System.EventHandler(this.button_yenile_Click);
            // 
            // Form_BeklemedekiAlisEmirleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(552, 518);
            this.Controls.Add(this.button_yenile);
            this.Controls.Add(this.dataGridView_beklemedekiIslemler);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(568, 557);
            this.Name = "Form_BeklemedekiAlisEmirleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alış Emirlerim";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_beklemedekiIslemler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_beklemedekiIslemler;
        private System.Windows.Forms.Button button_yenile;
    }
}