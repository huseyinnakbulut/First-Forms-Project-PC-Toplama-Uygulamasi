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
    public partial class MainForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        bool removed = true;
        bool added = false;
        int toplamgüç;
        tbl_Customer customer;
        
        public MainForm(tbl_Customer temp)
        {
            customer = temp;
            InitializeComponent();
        }
        public bool CheckForOrder()
        {
            var order = db.tbl_Order.Where(x => x.Customer_ID == customer.ID).FirstOrDefault();
            if (order != null)
            {
                return true;
            }
            else
            {
                return false;
            }

            //kullanıcıya ait mevcut bir order olup olmadığını kontrol ediyor
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OldPurchaseForm form = new OldPurchaseForm(customer);
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckForOrder() == true)
            {
                MessageBox.Show("Mevcut bir siparişiniz bulunmaktadır siparişinizi teslim almadan ya da iptal etmeden yeni bir sipariş veremezsiniz!");
            }
            else
            {
                CPUForm form = new CPUForm(order, ürünlerlistbox, added, removed, toplamgüç, customer);
                this.Close();
                form.Show();
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelUser.Text = customer.Username;
            pictureBox1.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\user.png");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProfilForm form = new ProfilForm(customer);
            this.Hide();
            form.Show();
        }
    }
}
