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
    public partial class KulaklıkForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int kulaklıkId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public KulaklıkForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
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

            var kulaklık = (from x in db.tbl_Kulaklık.Where(x => x.Stok > 0)
                            select new
                           {
                               x.Id,
                               x.Full_Ad
                           }).ToList();

            UrunlerCmbBox.ValueMember = "Id";
            UrunlerCmbBox.DisplayMember = "Full_Ad";
            UrunlerCmbBox.DataSource = kulaklık;

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
            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Kulaklık\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            var selectedKulaklık = db.tbl_Kulaklık.Find(UrunlerCmbBox.SelectedValue);
            string temp;
            if (selectedKulaklık.Kablolu_Kablosuz == true)
            {
                temp = "Kablolu";
            }
            else
            {
                temp = "Kablosuz";
            }
            string rgb;
            if (selectedKulaklık.RGB == true)
            {
                rgb = "Var";
            }
            else
            {
                rgb = "yok";
            }
            string mikrofon;
            if (selectedKulaklık.Mikrofon_var_yok == true)
            {
                mikrofon = "Var";
            }
            else
            {
                mikrofon = "Yok";
            }
            string seskartı;
            if (selectedKulaklık.Ses_Kartı_var_yok == true)
            {
                seskartı = "Var";
            }
            else
            {
                seskartı = "Yok";
            }

            OzelliklerListBox.Items.Add("Marka:                    " + selectedKulaklık.Marka);
            OzelliklerListBox.Items.Add("Model:                        " + selectedKulaklık.Model);
            OzelliklerListBox.Items.Add("Kablolu/Kablosuz:      " + temp);
            OzelliklerListBox.Items.Add("RGB:                           " + rgb);
            OzelliklerListBox.Items.Add("Frekans:                   " + selectedKulaklık.Frekans_Tepkisi);
            OzelliklerListBox.Items.Add("Mikrofon:                   " + mikrofon);
            OzelliklerListBox.Items.Add("Ses Çıkışı:                 " + selectedKulaklık.Ses_Çıkışı);
            OzelliklerListBox.Items.Add("Ses Kartı:                  " + seskartı);
            OzelliklerListBox.Items.Add("Fiyat:                          " + selectedKulaklık.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :                         " + selectedKulaklık.Stok);

        }

        private void KulaklıkForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Kulaklık_Id != null)
            {
                added = true;
                removed = false;
            }
        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedKulaklık = db.tbl_Kulaklık.Find(UrunlerCmbBox.SelectedValue);

            if (selectedKulaklık.Id == 1)
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (added == false)
            {

                var kulaklıkTemp = db.tbl_Kulaklık.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                kulaklıkId = kulaklıkTemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(kulaklıkTemp.Full_Ad + " " + kulaklıkTemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(kulaklıkTemp.Fiyat);
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
                if (order.Kulaklık_Id != null && k == 0)
                {
                    kulaklıkId = (int)order.Kulaklık_Id;
                    k++;
                }
                var kulaklıkTemp = db.tbl_Kulaklık.Find(kulaklıkId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(kulaklıkTemp.Full_Ad));
                Toplam -= Convert.ToDecimal(kulaklıkTemp.Fiyat);
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
            EkranForm form = new EkranForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
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
                order.Kulaklık_Id = kulaklıkId;
                bool removed = true;
                bool added = false;
                KlavyeForm form = new KlavyeForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen kulaklık seçiniz");
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
