namespace Bilgisayar_Toplama_Sistemi_Forms
{
    partial class RamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RamForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.UrunlerCmbBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.SepetLabel = new System.Windows.Forms.Label();
            this.SepetListBox = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.OzelliklerListBox = new System.Windows.Forms.ListBox();
            this.UrunLabel = new System.Windows.Forms.Label();
            this.UrunPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrunPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.UrunlerCmbBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.totalPriceLabel);
            this.panel1.Controls.Add(this.SepetLabel);
            this.panel1.Controls.Add(this.SepetListBox);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.OzelliklerListBox);
            this.panel1.Controls.Add(this.UrunLabel);
            this.panel1.Controls.Add(this.UrunPictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 608);
            this.panel1.TabIndex = 31;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(194, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "İndirim dahilinde dual ya da single kit ram  olmak üzere tek bir seçim yapabilirs" +
    "iniz.";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(676, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 70);
            this.button4.TabIndex = 28;
            this.button4.Text = "SON EKLENENİ SEPETTEN ÇIKAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.Location = new System.Drawing.Point(587, 34);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 72);
            this.button5.TabIndex = 27;
            this.button5.Text = "SEPETE EKLE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // UrunlerCmbBox
            // 
            this.UrunlerCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UrunlerCmbBox.DropDownWidth = 500;
            this.UrunlerCmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunlerCmbBox.FormattingEnabled = true;
            this.UrunlerCmbBox.Location = new System.Drawing.Point(145, 9);
            this.UrunlerCmbBox.Name = "UrunlerCmbBox";
            this.UrunlerCmbBox.Size = new System.Drawing.Size(641, 21);
            this.UrunlerCmbBox.TabIndex = 26;
            this.UrunlerCmbBox.SelectedIndexChanged += new System.EventHandler(this.UrunlerCmbBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(0, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "RAM SEÇ;";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalPriceLabel.Location = new System.Drawing.Point(723, 427);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(15, 16);
            this.totalPriceLabel.TabIndex = 12;
            this.totalPriceLabel.Text = "0";
            // 
            // SepetLabel
            // 
            this.SepetLabel.AutoSize = true;
            this.SepetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SepetLabel.Location = new System.Drawing.Point(568, 132);
            this.SepetLabel.Name = "SepetLabel";
            this.SepetLabel.Size = new System.Drawing.Size(47, 13);
            this.SepetLabel.TabIndex = 10;
            this.SepetLabel.Text = "SEPET";
            // 
            // SepetListBox
            // 
            this.SepetListBox.FormattingEnabled = true;
            this.SepetListBox.HorizontalScrollbar = true;
            this.SepetListBox.Location = new System.Drawing.Point(571, 160);
            this.SepetListBox.Name = "SepetListBox";
            this.SepetListBox.ScrollAlwaysVisible = true;
            this.SepetListBox.Size = new System.Drawing.Size(244, 264);
            this.SepetListBox.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(688, 507);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 44);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(608, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "GERİ DÖN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(713, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "DEVAM ET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(568, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Toplam Sepet Tutarı:";
            // 
            // OzelliklerListBox
            // 
            this.OzelliklerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OzelliklerListBox.FormattingEnabled = true;
            this.OzelliklerListBox.ItemHeight = 16;
            this.OzelliklerListBox.Location = new System.Drawing.Point(3, 337);
            this.OzelliklerListBox.Name = "OzelliklerListBox";
            this.OzelliklerListBox.Size = new System.Drawing.Size(276, 228);
            this.OzelliklerListBox.TabIndex = 4;
            // 
            // UrunLabel
            // 
            this.UrunLabel.AutoSize = true;
            this.UrunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunLabel.Location = new System.Drawing.Point(0, 315);
            this.UrunLabel.Name = "UrunLabel";
            this.UrunLabel.Size = new System.Drawing.Size(53, 13);
            this.UrunLabel.TabIndex = 3;
            this.UrunLabel.Text = "ürün adı";
            // 
            // UrunPictureBox
            // 
            this.UrunPictureBox.Location = new System.Drawing.Point(0, 79);
            this.UrunPictureBox.Name = "UrunPictureBox";
            this.UrunPictureBox.Size = new System.Drawing.Size(276, 221);
            this.UrunPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UrunPictureBox.TabIndex = 2;
            this.UrunPictureBox.TabStop = false;
            // 
            // RamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(834, 605);
            this.Controls.Add(this.panel1);
            this.Name = "RamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RamForm";
            this.Load += new System.EventHandler(this.RamForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrunPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox UrunlerCmbBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label SepetLabel;
        private System.Windows.Forms.ListBox SepetListBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox OzelliklerListBox;
        private System.Windows.Forms.Label UrunLabel;
        private System.Windows.Forms.PictureBox UrunPictureBox;
        private System.Windows.Forms.Label label1;
    }
}