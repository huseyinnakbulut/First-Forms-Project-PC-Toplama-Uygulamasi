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
    public partial class KlavyeForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int klavyeId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public KlavyeForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
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

            var klavye = (from x in db.tbl_Keyboard.Where(x => x.Stok > 0)
                          select new
                           {
                               x.Id,
                               x.FullAd
                           }).ToList();

            UrunlerCmbBox.ValueMember = "Id";
            UrunlerCmbBox.DisplayMember = "FullAd";
            UrunlerCmbBox.DataSource = klavye;

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
            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Klavye\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            var selectedKlavye = db.tbl_Keyboard.Find(UrunlerCmbBox.SelectedValue);
            string rgb;
            if (selectedKlavye.RGB == true)
            {
                rgb = "Var";
            }
            else
            {
                rgb = "yok";
            }
            string temp;
            if (selectedKlavye.Kablolu == true)
            {
                temp = "Kablolu";
            }
            else
            {
                temp = "Kablosuz";
            }
            string dil;
            if (selectedKlavye.Türkçe_İngilizce == true)
            {
                dil = "Türkçe";
            }
            else
            {
                dil = "İngilizce";
            }
            string mekanik;
            if (selectedKlavye.Mekanik == true)
            {
                mekanik = "Evet";
            }
            else
            {
                mekanik = "Hayır";
            }
            OzelliklerListBox.Items.Add("Marka:               " + selectedKlavye.Marka);
            OzelliklerListBox.Items.Add("Model:               " + selectedKlavye.Model);
            OzelliklerListBox.Items.Add("Mekanik:            " + mekanik);
            OzelliklerListBox.Items.Add("RGB:                 " + rgb);
            OzelliklerListBox.Items.Add("Kablolu/Kablosuz:    " + temp);
            OzelliklerListBox.Items.Add("Dil:                  " + dil);
            OzelliklerListBox.Items.Add("Renk:                " + selectedKlavye.Renk);
            OzelliklerListBox.Items.Add("Switch:              " + selectedKlavye.@switch);
            OzelliklerListBox.Items.Add("Fiyat:                " + selectedKlavye.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :               " + selectedKlavye.Stok);

        }

        private void KlavyeForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Keyboard_Id != null)
            {
                added = true;
                removed = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (added == false)
            {

                var klavyeTemp = db.tbl_Keyboard.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                klavyeId = klavyeTemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(klavyeTemp.FullAd + " " + klavyeTemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(klavyeTemp.Fiyat);
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
                if (order.Keyboard_Id != null && k == 0)
                {
                    klavyeId = (int)order.Keyboard_Id;
                    k++;
                }
                var klavyeTemp = db.tbl_Keyboard.Find(klavyeId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(klavyeTemp.FullAd));
                Toplam -= Convert.ToDecimal(klavyeTemp.Fiyat);
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
            KulaklıkForm form = new KulaklıkForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
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
                order.Keyboard_Id = klavyeId;
                bool removed = true;
                bool added = false;
                MouseForm form = new MouseForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen klavye seçiniz");
            }
        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedKlavye = db.tbl_Keyboard.Find(UrunlerCmbBox.SelectedValue);

            if (selectedKlavye.Id == 1)
            {
                UrunPictureBox.Visible = false;
                UrunLabel.Visible = false;
                OzelliklerListBox.Visible = false;
            }
            else
            {
                GetProduct();

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
