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

    public partial class MouseForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int mouseId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public MouseForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
        {
            InitializeComponent();
            this.order = order;
            this.ürünlerlistbox = ürünlerlistbox;
            Toplam = (decimal)order.Total_Price;
            this.removed = removed;
            this.added = added;
            this.toplamgüç = toplamgüç;
            this.customer = customer;
        }
        public void Listele()
        {

            var mouse = (from x in db.tbl_mouse.Where(x => x.Stok > 0)
                         select new
                           {
                               x.Id,
                               x.FullAd
                           }).ToList();

            UrunlerCmbBox.ValueMember = "Id";
            UrunlerCmbBox.DisplayMember = "FullAd";
            UrunlerCmbBox.DataSource = mouse;

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

            UrunPictureBox.Visible = true;
            UrunLabel.Visible = true;
            OzelliklerListBox.Visible = true;
            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Mouse\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            var selectedMouse = db.tbl_mouse.Find(UrunlerCmbBox.SelectedValue);
            string temp;
            if (selectedMouse.Kablolu_kablosuz == true)
            {
                temp = "Kablolu";
            }
            else
            {
                temp = "Kablosuz";
            }
            string rgb;
            if (selectedMouse.RGB == true)
            {
                rgb = "Var";
            }
            else
            {
                rgb = "Yok";
            }
            OzelliklerListBox.Items.Add("Marka:                      " + selectedMouse.Marka);
            OzelliklerListBox.Items.Add("Model:                      " + selectedMouse.Model);
            OzelliklerListBox.Items.Add("DPI:                          " + selectedMouse.DPI);
            OzelliklerListBox.Items.Add("Tuş Sayısı:               " + selectedMouse.Tuş_sayısı);
            OzelliklerListBox.Items.Add("Kablolu/Kablosuz:    " + temp);
            OzelliklerListBox.Items.Add("RGB:                        " + rgb);
            OzelliklerListBox.Items.Add("RENK:                      " + selectedMouse.Renk);
            OzelliklerListBox.Items.Add("Fiyat:                        " + selectedMouse.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :                       " + selectedMouse.Stok);
                      
        }

        private void MouseForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Mouse_Id != null)
            {
                added = true;
                removed = false;
            }
        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMouse = db.tbl_mouse.Find(UrunlerCmbBox.SelectedValue);

            if (selectedMouse.Id==1)
            {
                UrunPictureBox.Visible = false;
                UrunLabel.Visible = false;
                OzelliklerListBox.Visible= false;
            }
            else
            {
                GetProduct();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (added == false)
            {

                var mouseTemp = db.tbl_mouse.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                mouseId = mouseTemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(mouseTemp.FullAd + " " + mouseTemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(mouseTemp.Fiyat);
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
                if (order.Mouse_Id != null && k == 0)
                {
                    mouseId = (int)order.Mouse_Id;
                    k++;
                }
                var mouseTemp = db.tbl_mouse.Find(mouseId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(mouseTemp.FullAd));
                Toplam -= Convert.ToDecimal(mouseTemp.Fiyat);
                removed = true;
                added = false;
                totalPriceLabel.Text = Toplam.ToString();


            }
            else
            {
                MessageBox.Show("Bu sayfada henüz bir ürün eklemediniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            KlavyeForm form = new KlavyeForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
            this.Close();
            form.Show();
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
                order.Mouse_Id= mouseId;
                bool removed = true;
                bool added = false;
                OrderForm form = new OrderForm(order, ürünlerlistbox, added, removed, toplamgüç, customer);
                this.Close();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen mouse seçiniz");
            }

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
