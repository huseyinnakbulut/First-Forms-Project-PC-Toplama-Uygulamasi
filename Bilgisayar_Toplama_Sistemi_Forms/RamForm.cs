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
    public partial class RamForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int RamId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public RamForm(tbl_Order ordert, List<string> ürünlerlistboxt, bool added, bool removed, int toplamgüç, tbl_Customer customer)
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

            var disk = (from x in db.tbl_RAM.Where(x => x.Stok > 0)
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

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\RAM\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            var selectedRam = db.tbl_RAM.Find(UrunlerCmbBox.SelectedValue);
            OzelliklerListBox.Items.Add("Marka:              " + selectedRam.Marka);
            OzelliklerListBox.Items.Add("Kit:                    " + selectedRam.Kit);
            OzelliklerListBox.Items.Add("Soket:              " + selectedRam.Soket);
            OzelliklerListBox.Items.Add("Kapasite :        " + selectedRam.Toplam_GB + "GB");
            OzelliklerListBox.Items.Add("Fiyat:                " + selectedRam.Fiyat + " TL");
            OzelliklerListBox.Items.Add("MHz:                " + selectedRam.MHz+" MHz");
            OzelliklerListBox.Items.Add("Stok :               " + selectedRam.Stok);

        }
        private void RamForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Ram_Id != null)
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
                var Ramtemp = db.tbl_RAM.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                RamId = Ramtemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(Ramtemp.Full_Ad + " " + Ramtemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(Ramtemp.Fiyat);
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
                if (order.Ram_Id != null && k == 0)
                {
                    RamId = (int)order.Ram_Id;
                    k++;
                }
                var Ramtemp = db.tbl_RAM.Find(RamId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(Ramtemp.Full_Ad));
                Toplam -= Convert.ToDecimal(Ramtemp.Fiyat);
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
                order.Ram_Id = RamId;
                bool removed = true;
                bool added = false;
                CaseForm caseForm = new CaseForm(order, ürünlerlistbox, added, removed,toplamgüç,customer);
                this.Close();
                caseForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen RAM seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            DiskForm form = new DiskForm(order, ürünlerlistbox, added, removed,toplamgüç,customer);
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
