using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using DAL;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace Bilgisayar_Toplama_Sistemi_Forms
{
    public partial class CreateUserFormcs : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();

        public CreateUserFormcs()
        {
            InitializeComponent();
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
        }
        private void CreateUserFormcs_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Eğer Kaydınızı tamamlamadıysanız girilen veriler silinecektir emin misiniz?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                LoginForm form = new LoginForm();
                this.Hide();
                form.Show();
            }         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DateTime dt = this.dateTimePicker1.Value.Date;
            tbl_Customer customer = new tbl_Customer();
            CustomerLogic customerLogic = new CustomerLogic();

            labelUyarı.Visible = false;
            customer.Username = textBox1.Text;
            customer.Password = textBox2.Text;
            customer.Ad = textBox3.Text;
            customer.Soyad = textBox4.Text;
            customer.Doğum_Tarihi = dt;
            customer.Telno = maskedTextBox1.Text;
            customer.TC = maskedTextBox2.Text;
            customer.Email = textBox5.Text;
            customer.City = Convert.ToInt32(comboBox1.SelectedValue);
            customer.Adres = richTextBox1.Text;
            customer.Admin_Customer = false;
            
            bool check2 = customerLogic.AddCustomer(customer);
            if (check2 == true)
            {
                MessageBox.Show("Kaydınız başarıyla tamamlanmıştır", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm form = new LoginForm();
                this.Hide();
                form.Show();
            }
            else
            {
                labelUyarı.Text = "Tüm kutucukları doğru girdiğinizden emin olunuz!";
                labelUyarı.Visible = true;
            }
        }
                

                

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && maskedTextBox1.Text.Length > 0 && maskedTextBox2.Text.Length > 0 && richTextBox1.Text.Length > 0)
            {
                button3.Enabled = true;
            }

        }

    }
}
