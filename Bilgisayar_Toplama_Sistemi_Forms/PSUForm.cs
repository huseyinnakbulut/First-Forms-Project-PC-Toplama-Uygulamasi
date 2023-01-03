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
    public partial class PSUForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int psuId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;

        public PSUForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
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
            var psu = (from x in db.tbl_PSU.Where(x => x.Güc >= toplamgüç+100).Where(x => x.Stok > 0)
                       select new
                      {
                          x.Id,
                          x.Full_Ad
                      }).ToList();

            UrunlerCmbBox.ValueMember = "Id";
            UrunlerCmbBox.DisplayMember = "Full_Ad";
            UrunlerCmbBox.DataSource = psu;

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

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\PSU\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();

            var selectedPsu = db.tbl_PSU.Find(UrunlerCmbBox.SelectedValue);
            OzelliklerListBox.Items.Add("Marka:          " + selectedPsu.Marka);
            OzelliklerListBox.Items.Add("Verimlilik:     " + selectedPsu.Verimlilik_sertifikası);
            OzelliklerListBox.Items.Add("Güç:             " + selectedPsu.Güc + "W");
            OzelliklerListBox.Items.Add("Fiyat:            " + selectedPsu.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :           " + selectedPsu.Stok);

        }
        private void PSUForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Powersup_Id != null)
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

                var psutemp = db.tbl_PSU.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                psuId = psutemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(psutemp.Full_Ad + " " + psutemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(psutemp.Fiyat);
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
                if (order.Powersup_Id != null && k == 0)
                {
                    psuId = (int)order.Powersup_Id;
                    k++;
                }
                var psutemp = db.tbl_PSU.Find(psuId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(psutemp.Full_Ad));
                Toplam -= Convert.ToDecimal(psutemp.Fiyat);
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
            CaseForm form = new CaseForm(order, ürünlerlistbox, added, removed, toplamgüç, customer);
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
                order.Powersup_Id = psuId;
                bool removed = true;
                bool added = false;
                EkranForm form = new EkranForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen PSU seçiniz");
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
