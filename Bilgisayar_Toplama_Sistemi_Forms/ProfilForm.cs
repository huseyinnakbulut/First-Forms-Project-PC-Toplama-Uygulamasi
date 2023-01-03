using EntityLayer;
using LogicLayer;
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


namespace Bilgisayar_Toplama_Sistemi_Forms
{
    public partial class ProfilForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Customer customer;
        public ProfilForm(tbl_Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            // önceki şifre yazma yeri gelicek önceki sifre doğruysa tüm bu güncelleme işlemine izin verecek!
            Listele();

        }
        public void Listele()
        {
            var sehir = (from x in db.tbl_City
                         select new
                         {
                             x.Id,
                             x.City_Name
                         }).ToList();
            comboBox1.ValueMember = "Id";

            comboBox1.DisplayMember = "City_Name";
            comboBox1.DataSource = sehir;
            pictureBox1.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\user.png");
            DateTime dt;
            labelUser.Text = customer.Username;
            //textBox2.Text= customer.Password;
            textBox3.Text= customer.Ad;
            textBox4.Text = customer.Soyad;
            dt = (DateTime)customer.Doğum_Tarihi;
            maskedTextBox1.Text= customer.Telno;
            maskedTextBox2.Text= customer.TC;
            textBox6.Text = Convert.ToString(dt);
            textBox5.Text = customer.Email;
            comboBox1.SelectedValue = customer.City;
            richTextBox1.Text= customer.Adres;
            //this.dateTimePicker1.Value.Date = dt;

        }
        public int k = 2;

        private void buttonPAS_Click(object sender, EventArgs e)
        {
        
            if (k % 2 == 0)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
                buttonPAS.BackgroundImage= Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Normal.png");
               

            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
                buttonPAS.BackgroundImage = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Yıldızlı.png");

            }
            k++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != customer.Password)
            {
                MessageBox.Show("Girdiğiniz Şifre yanlıştır!");
            }
            else
            {
                CustomerLogic customerLogic = new CustomerLogic();                
                customer.Password = textBox2.Text;
                customer.Ad = textBox3.Text;
                customer.Soyad = textBox4.Text;
                customer.Telno = maskedTextBox1.Text;
                customer.TC = maskedTextBox2.Text;
                customer.Email = textBox5.Text;
                customer.City = Convert.ToInt32(comboBox1.SelectedValue);
                customer.Adres = richTextBox1.Text;
                
                customerLogic.UpdateCustomer(customer);
                MessageBox.Show("Bilgileriniz Güncellenmiştir!");
                Listele();
                textBox1.Text=string.Empty; textBox2.Text=string.Empty;
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
            textBox1.Text = string.Empty; textBox2.Text = string.Empty;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(customer);
            this.Close();
            form.Show();
        }
    }
}
