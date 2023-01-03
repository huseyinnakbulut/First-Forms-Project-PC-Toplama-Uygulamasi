using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;

namespace Bilgisayar_Toplama_Sistemi_Forms
{
    public partial class OldPurchaseForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Customer customer;
        public OldPurchaseForm(tbl_Customer temp)
        {
            
            InitializeComponent();
            this.customer= temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(customer);
            this.Hide();
            form.Show();
        }
        public void Listele()
        {
         

            label2.Text = customer.Username;
            var order = (from x in db.tbl_Order.Where(x => x.Customer_ID==customer.ID)
                           select new
                           {
                               Tarih = x.Date,
                               Toplam_Fiyat=x.Total_Price,
                               İşlemci=x.tbl_CPU.Full_Ad,
                               Anakart=x.tbl_MotherBoard.Full_Ad,
                               Ekran_Kartı=x.tbl_GPU.Full_Ad,
                               RAM=x.tbl_RAM.Full_Ad,
                               PSU=x.tbl_PSU.Full_Ad,
                               Kasa=x.tbl_kasa.Full_ad,
                               Disk=x.tbl_Disk.Full_Ad,
                               Ekran=x.tbl_Ekran.FullAD,
                               Mouse=x.tbl_mouse.FullAd,
                               Kulaklık =x.tbl_Kulaklık.Full_Ad,
                               Klavye=x.tbl_Keyboard.FullAd,
                           }).ToList();
            dataGridView1.DataSource= order;

        }
        public bool CheckForOrder()
        {
            var order = db.tbl_Order.Where(x => x.Customer_ID ==customer.ID).FirstOrDefault();
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
        private void OldPurchaseForm_Load(object sender, EventArgs e)
        {
            if(CheckForOrder()==true)
            {
                Listele();
                label3.Visible= false;
            }
            else
            {
                label3.Visible = true;
            }
        }
        public void Reduceproducts()
        {
            var order = db.tbl_Order.Where(x => x.Customer_ID == customer.ID).FirstOrDefault();

            var cpu = db.tbl_CPU.Find(order.Cpu_Id); cpu.Stok++;
            var mb = db.tbl_MotherBoard.Find(order.MotherBoard_Id); mb.Stok++;
            var ram = db.tbl_RAM.Find(order.Ram_Id); ram.Stok++;
            var psu = db.tbl_PSU.Find(order.Powersup_Id); psu.Stok++;
            var gpu = db.tbl_GPU.Find(order.GPU_Id); gpu.Stok++;
            var kasa = db.tbl_kasa.Find(order.Case_Id); kasa.Stok++;
            var klavye = db.tbl_Keyboard.Find(order.Keyboard_Id); klavye.Stok++;
            var mouse = db.tbl_mouse.Find(order.Mouse_Id); mouse.Stok++;
            var ekran = db.tbl_Ekran.Find(order.Screen_Id); ekran.Stok++;
            var kulaklık = db.tbl_Kulaklık.Find(order.Kulaklık_Id); kulaklık.Stok++;
            var disk = db.tbl_Disk.Find(order.Disk_Id); disk.Stok++;


            db.SaveChanges();

        }
        private void button2_Click(object sender, EventArgs e)
        {

            //tekrardan listeleme işlemi
            if (CheckForOrder() == true)
            {
                //Mevcut sipariş siliniyor silmeden önce onay isteniyor
                string message = "Siparişinizi iptal etmek istediğinize emin misiniz?";
                string caption = "UYARI";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Reduceproducts();

                    OrderLogic logic = new OrderLogic();
                    var order = db.tbl_Order.Where(x => x.Customer_ID == customer.ID).FirstOrDefault();
                    logic.RemoveOrder(order);
                }
                Listele();
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }


        }
    }
}
