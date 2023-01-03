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
    public partial class CaseForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int kasaId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public CaseForm(tbl_Order ordert, List<string> ürünlerlistboxt, bool added, bool removed,int toplamgüç, tbl_Customer customer)
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

            var kasa = (from x in db.tbl_kasa.Where(x => x.Stok > 0)
                        select new
                        {
                            x.Id,
                            x.Full_ad
                        }).ToList();

            UrunlerCmbBox.ValueMember = "Id";

            UrunlerCmbBox.DisplayMember = "Full_ad";
            UrunlerCmbBox.DataSource = kasa;
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

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Kasa\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            var selectedCase = db.tbl_kasa.Find(UrunlerCmbBox.SelectedValue);
            OzelliklerListBox.Items.Add("Marka:          " + selectedCase.Marka);
            OzelliklerListBox.Items.Add("Model:          " + selectedCase.Model);
            OzelliklerListBox.Items.Add("Tip:               " + selectedCase.Tip);
            OzelliklerListBox.Items.Add("USB Port :    " + selectedCase.USB_sayısı+"  Adet");
            OzelliklerListBox.Items.Add("Fiyat:            " + selectedCase.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :           " + selectedCase.Stok);

        }
        private void CaseForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Case_Id != null)
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
                var Kasatemp = db.tbl_kasa.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                kasaId = Kasatemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(Kasatemp.Full_ad + " " + Kasatemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(Kasatemp.Fiyat);
                totalPriceLabel.Text = Toplam.ToString();
                added = true;
                removed = false;
            }
            else
            {
                MessageBox.Show("Hali hazırda Ürün eklediniz öncelikle en son eklediğiniz ürünü çıkartınız");
            }
        }
        int k = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (removed == false)
            {
                if (order.Case_Id != null && k == 0)
                {
                    kasaId = (int)order.Case_Id;
                    k++;
                }
                var kasatemp = db.tbl_kasa.Find(kasaId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(kasatemp.Full_ad));
                Toplam -= Convert.ToDecimal(kasatemp.Fiyat);
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
                order.Case_Id = kasaId;
                bool removed = true;
                bool added = false;
                PSUForm form = new PSUForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
                this.Close();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            RamForm form = new RamForm(order, ürünlerlistbox, added, removed, toplamgüç, customer);
            this.Close();
            form.Show();
        }
    }
    
}

