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
    public partial class DiskForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int diskId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public DiskForm(tbl_Order ordert, List<string> ürünlerlistboxt, bool added, bool removed, int toplamgüç, tbl_Customer customer)
        {
            InitializeComponent();
            this.order = ordert;
            this.ürünlerlistbox = ürünlerlistboxt;
            Toplam = (decimal)order.Total_Price;
            this.removed = removed;
            this.added = added;
            this.toplamgüç = toplamgüç;
            this.customer = customer;
        }
        public void Listele()
        {

            var disk = (from x in db.tbl_Disk.Where(x => x.Stok > 0)
                        select new
                       {
                           x.Id,
                           x.Full_Ad
                       }).ToList();

            UrunlerCmbBox.ValueMember = "Id";

            UrunlerCmbBox.DisplayMember = "Full_Ad";
            UrunlerCmbBox.DataSource = disk;
            totalPriceLabel.Text = Toplam.ToString();
            foreach (var item in ürünlerlistbox)
            {
                SepetListBox.Items.Add(item);
            }
            // combobax'a ürünlerin isimlerini gönderiyor ve  value olarak ıd sini tutuyor

        }
        public void GetProduct()
        {
            // Her ürün değiştirildiğinde ona göre resim,özellikler vs. güncelleniyor.

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Disk\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            string temp;
            var selectedDisk = db.tbl_Disk.Find(UrunlerCmbBox.SelectedValue);
            if (selectedDisk.SSD_Sabit_Disk == true)
            {
                temp = "SSD";
            }
            else
            {
                temp = "HDD";
            }
            OzelliklerListBox.Items.Add("SSD/HDD:      " + temp);
            OzelliklerListBox.Items.Add("Marka:            " + selectedDisk.Marka);
            OzelliklerListBox.Items.Add("Model:            " + selectedDisk.Model);           
            OzelliklerListBox.Items.Add("Kapasite :     " + selectedDisk.GB + "GB");
            OzelliklerListBox.Items.Add("Soket:            " + selectedDisk.Soket);
            OzelliklerListBox.Items.Add("Fiyat:              " + selectedDisk.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :             " + selectedDisk.Stok);

        }
        private void DiskForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Disk_Id != null)
            {
                added = true;
                removed = false;
            }

        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (added == false)
            {
                var disktemp = db.tbl_Disk.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                diskId = disktemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(disktemp.Full_Ad + " " + disktemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(disktemp.Fiyat);
                totalPriceLabel.Text = Toplam.ToString();
                added = true;
                removed = false;
            }
            else
            {
                MessageBox.Show("Hali hazırda Ürün eklediniz öncelikle en son eklediğiniz ürünü çıkartınız");
            }
        }
        public int k = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (removed == false)
            {
                if (order.Disk_Id != null && k == 0)
                {
                    diskId = (int)order.Disk_Id;
                    k++;
                }
                var disktemp = db.tbl_Disk.Find(diskId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(disktemp.Full_Ad));
                Toplam -= Convert.ToDecimal(disktemp.Fiyat);
                removed = true;
                added = false;
                totalPriceLabel.Text = Toplam.ToString();

            }
            else
            {
                MessageBox.Show("Bu sayfada henüz bir ürün eklemediniz");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ürünlerlistbox.Clear();
            if (added == true)
            {
                foreach (var item in SepetListBox.Items)
                {
                    ürünlerlistbox.Add(item.ToString());
                }
                order.Total_Price = Toplam;
                order.Disk_Id = diskId;
                bool removed = true;
                bool added = false;
                RamForm ramForm = new RamForm(order, ürünlerlistbox, added, removed,toplamgüç,customer);
                this.Close();
                ramForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Disk seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            GPUForm form = new GPUForm(order, ürünlerlistbox, added, removed,toplamgüç, customer);
            this.Close();
            form.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(customer);
            this.Close();
            form.Show();
            MessageBox.Show("Sepete eklediğiniz ürünler sıfırlanmıştır");
        }
    }
}
