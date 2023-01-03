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
namespace Bilgisayar_Toplama_Sistemi_Forms
{
    public partial class OrderForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public OrderForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
        {
            this.order = order;
            this.ürünlerlistbox = ürünlerlistbox;
            Toplam = (decimal)order.Total_Price;
            this.removed = removed;
            this.added = added;
            this.toplamgüç = toplamgüç;
            InitializeComponent();
            this.customer = customer;
        }
        public void Listele()
        {
            totalPriceLabel.Text = Toplam.ToString();
            foreach (var item in ürünlerlistbox)
            {
                SepetListBox.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            MouseForm form = new MouseForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
            this.Close();
            form.Show();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MainForm form = new MainForm();
            //this.Close();
            //form.Show();
        }
        public void Reduceproducts()
        {
            var cpu = db.tbl_CPU.Find(order.Cpu_Id); cpu.Stok--;
            var mb = db.tbl_MotherBoard.Find(order.MotherBoard_Id);  mb.Stok--;
            var ram = db.tbl_RAM.Find(order.Ram_Id); ram.Stok--;
            var psu = db.tbl_PSU.Find(order.Powersup_Id); psu.Stok--;
            var gpu = db.tbl_GPU.Find(order.GPU_Id); gpu.Stok--;
            var kasa = db.tbl_kasa.Find(order.Case_Id); kasa.Stok--;
            var klavye = db.tbl_Keyboard.Find(order.Keyboard_Id);  klavye.Stok--;
            var mouse = db.tbl_mouse.Find(order.Mouse_Id);  mouse.Stok--;
            var ekran = db.tbl_Ekran.Find(order.Screen_Id); ekran.Stok--;
            var kulaklık = db.tbl_Kulaklık.Find(order.Kulaklık_Id); kulaklık.Stok--;
            var disk=db.tbl_Disk.Find(order.Disk_Id); disk.Stok--;


            db.SaveChanges();
             
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrderLogic orderLogic = new OrderLogic();
            order.Date= DateTime.Now;
            order.Customer_ID= customer.ID;

            bool check = orderLogic.AddOrder(order);
            if(check==true)
            {
                Reduceproducts();
                MessageBox.Show("Siparişiniz oluşturulmuştur");
                MainForm form = new MainForm(customer);
                this.Close();
                form.Show();
            }
            else
            {
                MessageBox.Show("Siparişiniz oluşturulamadı eksik bir ürün olup olmadığını kontrol ediniz");
            }
        }
    }
}
