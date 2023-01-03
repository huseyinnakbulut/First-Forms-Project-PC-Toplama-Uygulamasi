namespace Bilgisayar_Toplama_Sistemi_Forms
{
    partial class MotherBoardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotherBoardForm));
            this.UrunPictureBox = new System.Windows.Forms.PictureBox();
            this.UrunLabel = new System.Windows.Forms.Label();
            this.OzelliklerListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SepetListBox = new System.Windows.Forms.ListBox();
            this.SepetLabel = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UrunPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UrunPictureBox
            // 
            this.UrunPictureBox.Location = new System.Drawing.Point(12, 84);
            this.UrunPictureBox.Name = "UrunPictureBox";
            this.UrunPictureBox.Size = new System.Drawing.Size(276, 221);
            this.UrunPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UrunPictureBox.TabIndex = 2;
            this.UrunPictureBox.TabStop = false;
            // 
            // UrunLabel
            // 
            this.UrunLabel.AutoSize = true;
            this.UrunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunLabel.Location = new System.Drawing.Point(12, 320);
            this.UrunLabel.Name = "UrunLabel";
            this.UrunLabel.Size = new System.Drawing.Size(53, 13);
            this.UrunLabel.TabIndex = 3;
            this.UrunLabel.Text = "ürün adı";
            // 
            // OzelliklerListBox
            // 
            this.OzelliklerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OzelliklerListBox.FormattingEnabled = true;
            this.OzelliklerListBox.ItemHeight = 16;
            this.OzelliklerListBox.Location = new System.Drawing.Point(15, 342);
            this.OzelliklerListBox.Name = "OzelliklerListBox";
            this.OzelliklerListBox.Size = new System.Drawing.Size(276, 212);
            this.OzelliklerListBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(579, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Toplam Sepet Tutarı:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(724, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "DEVAM ET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(619, 483);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "GERİ DÖN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(699, 533);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 44);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SepetListBox
            // 
            this.SepetListBox.FormattingEnabled = true;
            this.SepetListBox.HorizontalScrollbar = true;
            this.SepetListBox.Location = new System.Drawing.Point(582, 186);
            this.SepetListBox.Name = "SepetListBox";
            this.SepetListBox.ScrollAlwaysVisible = true;
            this.SepetListBox.Size = new System.Drawing.Size(244, 264);
            this.SepetListBox.TabIndex = 9;
            // 
            // SepetLabel
            // 
            this.SepetLabel.AutoSize = true;
            this.SepetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SepetLabel.Location = new System.Drawing.Point(579, 158);
            this.SepetLabel.Name = "SepetLabel";
            this.SepetLabel.Size = new System.Drawing.Size(47, 13);
            this.SepetLabel.TabIndex = 10;
            this.SepetLabel.Text = "SEPET";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalPriceLabel.Location = new System.Drawing.Point(734, 453);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(15, 16);
            this.totalPriceLabel.TabIndex = 12;
            this.totalPriceLabel.Text = "0";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.Location = new System.Drawing.Point(598, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 72);
            this.button5.TabIndex = 27;
            this.button5.Text = "SEPETE EKLE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "ANAKART SEÇ:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(687, 62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 70);
            this.button4.TabIndex = 28;
            this.button4.Text = "SON EKLENENİ SEPETTEN ÇIKAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 500;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(141, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(643, 21);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(303, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Seçtiğiniz işlemciyle uyumlu Anakartlar listelenmiştir.";
            // 
            // MotherBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(834, 591);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.SepetLabel);
            this.Controls.Add(this.SepetListBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OzelliklerListBox);
            this.Controls.Add(this.UrunLabel);
            this.Controls.Add(this.UrunPictureBox);
            this.Name = "MotherBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPUForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CPUForm_FormClosing);
            this.Load += new System.EventHandler(this.CPUForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UrunPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox UrunPictureBox;
        private System.Windows.Forms.Label UrunLabel;
        private System.Windows.Forms.ListBox OzelliklerListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox SepetListBox;
        private System.Windows.Forms.Label SepetLabel;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}