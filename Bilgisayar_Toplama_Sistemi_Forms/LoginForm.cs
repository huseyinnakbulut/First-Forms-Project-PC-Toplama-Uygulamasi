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

namespace Bilgisayar_Toplama_Sistemi_Forms
{
    public partial class LoginForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Customer user = new tbl_Customer();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUserFormcs form = new CreateUserFormcs();
            this.Hide();
            form.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = db.tbl_Customer.Where(x => x.Username == textBox1.Text).FirstOrDefault();
            if (temp == null)
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı");
            }
            else if (temp.Username != null && temp.Username == textBox1.Text && temp.Password == textBox2.Text && temp.Admin_Customer == false)
            {
                MainForm mainForm = new MainForm(temp);
                this.Hide();
                mainForm.Show();
            }
            else if (temp.Username != null && temp.Username == textBox1.Text && temp.Password == textBox2.Text && temp.Admin_Customer == true)
            {
                MainForm mainForm = new MainForm(temp);
                this.Hide();
                mainForm.Show();
                //ADMİN FORMU AÇILACAK
                //MessageBox.Show("ADMİN HG");
            }
            else if (temp.Password != textBox2.Text)
            {
                MessageBox.Show("Girdiğiniz Şifre yanlıştır");
            }
        }
        public int k = 2;
        private void buttonPAS_Click(object sender, EventArgs e)
        {
            if (k % 2 == 0)
            {
                
                textBox2.UseSystemPasswordChar = false;
                buttonPAS.BackgroundImage = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Normal.png");


            }
            else
            {
                
                textBox2.UseSystemPasswordChar = true;
                buttonPAS.BackgroundImage = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Yıldızlı.png");

            }
            k++;
        }
    }
}
