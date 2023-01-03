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
    public partial class GPUForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int gpuId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;
        public GPUForm(tbl_Order order, List<string> ürünlerlistbox,bool added, bool removed, int toplamgüç, tbl_Customer customer)
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

            var gpu = (from x in db.tbl_GPU.Where(x => x.Stok > 0)
                       select new
                       {
                           x.Id,
                           x.Full_Ad
                       }).ToList();
                           
            UrunlerCmbBox.ValueMember = "Id";

            UrunlerCmbBox.DisplayMember = "Full_Ad";
            UrunlerCmbBox.DataSource = gpu;
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

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\GPU\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();

            var selectedGpu = db.tbl_GPU.Find(UrunlerCmbBox.SelectedValue);
            OzelliklerListBox.Items.Add("Üretici:              " + selectedGpu.Üretici);
            OzelliklerListBox.Items.Add("Marka:              " + selectedGpu.Marka);
            OzelliklerListBox.Items.Add("Model:              " + selectedGpu.Model);
            OzelliklerListBox.Items.Add("Seri :                 " + selectedGpu.Seri);
            OzelliklerListBox.Items.Add("Bellek :             " + selectedGpu.Bellek_Kapasitesi+" GB");
            OzelliklerListBox.Items.Add("Bit:                    " + selectedGpu.Bit);
            OzelliklerListBox.Items.Add("Soket:              " + selectedGpu.Soket);
            OzelliklerListBox.Items.Add("Güç Tüketimi:  " + selectedGpu.Güç+" W");
            OzelliklerListBox.Items.Add("Fiyat:                " + selectedGpu.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :               " + selectedGpu.Stok);

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
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
                order.GPU_Id = gpuId;
                bool removed = true;
                bool added = false;
                DiskForm diskForm = new DiskForm(order, ürünlerlistbox, added, removed,toplamgüç,customer);
                this.Hide();
                diskForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Ekran kartı seçiniz");
            }
        }

        private void GPUForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.GPU_Id != null)
            {
                added= true;
                removed = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (added == false)
            {
                
                var gputemp = db.tbl_GPU.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                gpuId = gputemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(gputemp.Full_Ad + " " + gputemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(gputemp.Fiyat);
                totalPriceLabel.Text = Toplam.ToString();
                added = true;
                removed = false;
                toplamgüç = toplamgüç + (int)gputemp.Güç;
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
                if (order.GPU_Id != null && k == 0)
                {
                    gpuId = (int)order.GPU_Id;
                    k++;
                }
                var gputemp = db.tbl_GPU.Find(gpuId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(gputemp.Full_Ad));
                Toplam -= Convert.ToDecimal(gputemp.Fiyat);
                removed = true;
                added = false;
                totalPriceLabel.Text = Toplam.ToString();
                toplamgüç = toplamgüç - (int)gputemp.Güç;

            }
            else
            {
                MessageBox.Show("Bu sayfada henüz bir ürün eklemediniz");
            }
        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool removed = false;
            bool added = true;
            MotherBoardForm form = new MotherBoardForm(order, ürünlerlistbox,added, removed, toplamgüç, customer);
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
