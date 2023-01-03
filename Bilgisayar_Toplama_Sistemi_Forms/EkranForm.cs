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
    public partial class EkranForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int ekranId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public EkranForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
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

            var monitor = (from x in db.tbl_Ekran.Where(x => x.Stok > 0)
                           select new
                       {
                           x.Id,
                           x.FullAD
                       }).ToList();

            UrunlerCmbBox.ValueMember = "Id";
            UrunlerCmbBox.DisplayMember = "FullAD";
            UrunlerCmbBox.DataSource = monitor;

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
            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\Monitor\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();
            var selectedMonitor= db.tbl_Ekran.Find(UrunlerCmbBox.SelectedValue);
            string temp;
            if(selectedMonitor.HDR == true)
            {
                temp = "Var";
            }
            else
            {
                temp = "Yok";
            }
            OzelliklerListBox.Items.Add("Marka:                   " + selectedMonitor.Marka);
            OzelliklerListBox.Items.Add("Model:                   " + selectedMonitor.Model);
            OzelliklerListBox.Items.Add("Boyut:                    " + selectedMonitor.Boyut);
            OzelliklerListBox.Items.Add("Çözünürlük:          " + selectedMonitor.Çözünürlük);
            OzelliklerListBox.Items.Add("Tazeleme Hızı:     " + selectedMonitor.Tazeleme_hızı+" Hz");
            OzelliklerListBox.Items.Add("HDR:                      " + temp);
            OzelliklerListBox.Items.Add("Panel:                    " + selectedMonitor.Panel);
            OzelliklerListBox.Items.Add("Tepkime Süresi:   " + selectedMonitor.MS+" ms");
            OzelliklerListBox.Items.Add("Display Port:          " + selectedMonitor.Display_Port);
            OzelliklerListBox.Items.Add("HDMI:                      " + selectedMonitor.HDMI);;
            OzelliklerListBox.Items.Add("Fiyat:                      " + selectedMonitor.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :                     " + selectedMonitor.Stok);

        }
        private void EkranForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.Screen_Id != null)
            {
                added = true;
                removed = false;
            }
        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMonitor = db.tbl_Ekran.Find(UrunlerCmbBox.SelectedValue);

            if (selectedMonitor.Id == 1)
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

                var monitörTemp = db.tbl_Ekran.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                ekranId = monitörTemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(monitörTemp.FullAD + " " + monitörTemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(monitörTemp.Fiyat);
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
                if (order.Screen_Id != null && k == 0)
                {
                    ekranId = (int)order.Screen_Id;
                    k++;
                }
                var monitorTemp = db.tbl_Ekran.Find(ekranId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(monitorTemp.FullAD));
                Toplam -= Convert.ToDecimal(monitorTemp.Fiyat);
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
                order.Screen_Id = ekranId;
                bool removed = true;
                bool added = false;
                KulaklıkForm form = new KulaklıkForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen monitör seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            PSUForm form = new PSUForm(order, ürünlerlistbox, added, removed, toplamgüç,customer);
            this.Close();
            form.Show();
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
