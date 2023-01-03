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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bilgisayar_Toplama_Sistemi_Forms
{
    public partial class MotherBoardForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order();
        List<string> ürünlerlistbox = new List<string>();
        decimal Toplam;
        int mbId;
        bool removed;
        bool added;
        bool exit = false;
        int toplamgüç;
        tbl_Customer customer;



        public MotherBoardForm(tbl_Order order, List<string> ürünlerlistbox,bool added,bool removed,int toplamgüç,tbl_Customer customer)
        {
            InitializeComponent();
            // Bir önceki formdan alınan bilgiler alınıyor.
            this.order = order;
            this.ürünlerlistbox = ürünlerlistbox;
            this.removed = removed;
            this.added = added;
            this.toplamgüç = toplamgüç;
            Toplam = (decimal)order.Total_Price;
            this.customer= customer;
        }

        private void UrunlerCmbBox_DrawItem(object sender, DrawItemEventArgs e)
        {         
        }            
        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
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
                order.MotherBoard_Id = mbId;
                bool removed = true;
                bool added = false;
                GPUForm gpuForm = new GPUForm(order, ürünlerlistbox,added, removed,toplamgüç,customer);
                this.Hide();
                gpuForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen anakart seçiniz");
            }
        }


        private void CPUForm_Load(object sender, EventArgs e)
        {
            Listele();
            if (order.MotherBoard_Id != null)
            {
                added = true;
                removed = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(added == false)
            {
                var mptemp = db.tbl_MotherBoard.Find(comboBox1.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                mbId = mptemp.MB_Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(mptemp.Full_Ad + " " + mptemp.Price + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(mptemp.Price);
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
                if(order.MotherBoard_Id != null&&k==0)
                {
                    mbId = (int)order.MotherBoard_Id;
                    k++;
                }
                var mbtemp = db.tbl_MotherBoard.Find(mbId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(mbtemp.Full_Ad));
                Toplam -= Convert.ToDecimal(mbtemp.Price);
                removed = true;
                added = false;
                totalPriceLabel.Text = Toplam.ToString();

            }
            else
            {
                MessageBox.Show("Bu sayfada henüz bir ürün eklemediniz");
            }
            

        }

        
        private void CPUForm_FormClosing(object sender, FormClosingEventArgs e)
        {


        }


        public void GetProduct()
        {
            // Her ürün değiştirildiğinde ona göre resim,özellikler vs. güncelleniyor.

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\MB\\{comboBox1.Text}.jpg");

            UrunLabel.Text = comboBox1.Text;

            OzelliklerListBox.Items.Clear();

            var selectedmb = db.tbl_MotherBoard.Find(comboBox1.SelectedValue);
            var soket = db.tbl_Socket.Find(selectedmb.Soket_Id);
            OzelliklerListBox.Items.Add("Marka:          " + selectedmb.Marka);
            OzelliklerListBox.Items.Add("Model:          " + selectedmb.Model);
            OzelliklerListBox.Items.Add("Yapı :            " + selectedmb.Yapı);
            OzelliklerListBox.Items.Add("Soket:           " + soket.Soket_Name);
            OzelliklerListBox.Items.Add("Ram Slot  :    " + selectedmb.Ram_Slot_sayısı);
            OzelliklerListBox.Items.Add("Bellek tipi:    " + selectedmb.Bellek_Tip);
            OzelliklerListBox.Items.Add("Fiyat:            " + selectedmb.Price + " TL");
            OzelliklerListBox.Items.Add("Stok :            " + selectedmb.Stok);

        }
        public void Listele()
        {
            var cpu = db.tbl_CPU.Find((int)order.Cpu_Id);
            int soketid = (int)cpu.Soket_Id;
            var mb = (from x in db.tbl_MotherBoard.Where(x => x.Soket_Id != soketid).Where(x => x.Stok > 0)
                      select new
                      {
                          x.MB_Id,
                          x.Full_Ad,
                      }).ToList();
            comboBox1.ValueMember = "MB_Id";
            comboBox1.DisplayMember = "Full_Ad";
            comboBox1.DataSource = mb;
            totalPriceLabel.Text = Toplam.ToString();
            foreach (var item in ürünlerlistbox)
            {
                SepetListBox.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                GetProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CPUForm form = new CPUForm(order, ürünlerlistbox, added, removed, toplamgüç, customer);
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
            
                
            
            
            
            

