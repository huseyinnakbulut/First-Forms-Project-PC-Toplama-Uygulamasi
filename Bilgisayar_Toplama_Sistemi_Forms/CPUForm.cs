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
    public partial class CPUForm : Form
    {
        PcToplamaEntities db = new PcToplamaEntities();
        tbl_Order order = new tbl_Order(); //toplamaya başladıktan itibaren kulalnacağımız sipariş nesnesi
        List<string> ürünlerlistbox = new List<string>(); // eklediğimiz siparişleri fiyatlarıyla birlikte gördüğümüz ve daha sonra listboxa eklediğimiz string listesi
        decimal Toplam;  //orderda bulunmasına rağmen form içerisinde daha rahat bir kullanım olması için üretilen toplam fiyat değişkeni
        int cpuId; // order nesnesine ekleyeceğimiz işlemci id'si
       //aşşağıdaki 2 değişken aynı formda zaten bir ürün seçildiyse yeniden aynı türden bir ürün seçimini engellemek için kullanılmıştır
        bool removed;
        bool added;

        int toplamgüç; //daha sonra kullanılacak psu seçimini etkileyecek toplam güç değeri için kullandığımız değişken

        tbl_Customer customer;  //login ekranından itibaren taşıdığımız kullanıcı bilgileri


        public CPUForm(tbl_Order order, List<string> ürünlerlistbox, bool added, bool removed, int toplamgüç, tbl_Customer customer)
        {
            //girişten itibaren elde edilen customer ve main formdan itibaren oluşturulan değişkenler constractor metodu sayesinde bu forma taşınmış oluyor.
            this.order = order;
            this.ürünlerlistbox = ürünlerlistbox;
            this.removed = removed;
            this.added = added;
            this.toplamgüç = toplamgüç;
            Toplam = 0;
            this.customer = customer;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ürünlerlistbox.Clear();  // Aynı ürünler ekli kalmasın diye önce temizlenip daha sonra tekrardan ekleme yapılacak.

            // eğer ürün eklenmişse ve bu butana basıldıysa sepetdeki itemleri listeye atıp sonraki formda hemen sepet listboxına eklenmesi sağlanıcak.
            //seçilmiş ürünün idsi order nesnesine eklenicek ve sonraki formlara taşınacak.
            //sonraki formun costractor metodunda çalışması için gerekli değişkenler gönderilecek.
            if (added == true)
            {
                foreach (var item in SepetListBox.Items)
                {
                    ürünlerlistbox.Add(item.ToString());
                }
                order.Total_Price = Toplam;
                order.Cpu_Id = cpuId;
                bool removed = true;
                bool added = false;

                MotherBoardForm motherBoardForm = new MotherBoardForm(order, ürünlerlistbox,added,removed,toplamgüç,customer);
                this.Hide();
                motherBoardForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen işlemci seçiniz");
            }
            // anakart seçim formuna gitme işlemi
        }

            
        private void CPUForm_Load(object sender, EventArgs e)
        {
            Listele();
            
            if (order.Cpu_Id != null)
            {
                //ilerideki formlardan geri gelirsek ve daha önce ürün seçildiyse silinmeden eklenmesini engelliyoruz.
                added = true;
                removed = false;
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            if(added == false)
            {
                var cputemp = db.tbl_CPU.Find(UrunlerCmbBox.SelectedValue); // comboboxda seçilen ürünü ürünün kendi tablosundan tüm özellikleriyle birlikte çekiyoruz
                cpuId = cputemp.Id; //id sini daha sonra sales'de kullanmak için vs. saklıyoruz.
                SepetListBox.Items.Add(cputemp.Full_Ad + " " + cputemp.Fiyat + " TL"); //Sepet listboxına ürünün adını ve fiyatını ekliyoruz.
                Toplam += Convert.ToDecimal(cputemp.Fiyat);
                totalPriceLabel.Text = Toplam.ToString();
                added = true;
                removed = false;
                toplamgüç = (int)cputemp.Güç;

            }
            else
            {
                MessageBox.Show("Hali hazırda Ürün eklediniz öncelikle en son eklediğiniz ürünü çıkartınız");
            }


        }
        //buton 4 de kullanılması için geçici olarak atanmış bir değişken.
        public int k = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            
            if (removed == false)
            {
                if (order.Cpu_Id != null && k == 0)
                {
                    //bu kodun sebebi eğer daha önce ürün eklenmiş ileri formlara gidilmiş ve geri gelinmiş ise silinmesi gereken id yi elde ediyor ve kaldırırken onu kaldırıyoruz.
                    //k değişkeninin sebebi ise ileri formdan geri gelindiğinde bu işleme bir defa ihtiyaç duyuyoruz daha sonra bu kodun çalışmasını istemiyoruz.
                    cpuId = (int)order.Cpu_Id;
                    k++;
                }
                var cputemp = db.tbl_CPU.Find(cpuId);
                SepetListBox.Items.RemoveAt(SepetListBox.FindString(cputemp.Full_Ad));
                Toplam -= Convert.ToDecimal(cputemp.Fiyat);
                removed = true;
                added = false;
                totalPriceLabel.Text = Toplam.ToString();
                toplamgüç = toplamgüç - (int)cputemp.Güç;


            }
            else
            {
                MessageBox.Show("Bu sayfada henüz bir ürün eklemediniz");
            }
            

        }

        
        private void CPUForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UrunlerCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProduct();
        }
        public void GetProduct()
        {
            // Her ürün değiştirildiğinde ona göre resim,özellikler vs. güncelleniyor.

            UrunPictureBox.Image = Image.FromFile($"C:\\Users\\husey\\source\\repos\\Bilgisayar_Toplama_Sistemi_Forms\\Resimler\\CPU\\{UrunlerCmbBox.Text}.jpg");

            UrunLabel.Text = UrunlerCmbBox.Text;

            OzelliklerListBox.Items.Clear();

            //combobox'da seçilen ürünün arakada tutulan id değerine göre ürünün tamamını elde ediyoruz
            var selectedcpu = db.tbl_CPU.Find(UrunlerCmbBox.SelectedValue);

            //soketin adını elde etmek için id sinden soket formundaki soket adına ulaşıyoruz(özellikleri yazarken).
            var soket = db.tbl_Socket.Find(selectedcpu.Soket_Id);
            OzelliklerListBox.Items.Add("Marka:               " + selectedcpu.Marka);
            OzelliklerListBox.Items.Add("Model:               " + selectedcpu.Model);
            OzelliklerListBox.Items.Add("Seri :                 " + selectedcpu.Seri);
            OzelliklerListBox.Items.Add("Soket:                " + soket.Soket_Name);
            OzelliklerListBox.Items.Add("Hız  :                  " + selectedcpu.Hız);
            OzelliklerListBox.Items.Add("Ön bellek:         " + selectedcpu.Ön_Bellek + " Mb");
            OzelliklerListBox.Items.Add("Güç Tüketimi:   " + selectedcpu.Güç + "W");
            OzelliklerListBox.Items.Add("Fiyat:                 " + selectedcpu.Fiyat + " TL");
            OzelliklerListBox.Items.Add("Stok :                 " + selectedcpu.Stok);

        }
        public void Listele()
        {
            //stoğu olmayan ürünler listelenmiyor.
            var cpu = (from x in db.tbl_CPU.Where(x => x.Stok>0)
                       select new
                       {
                           x.Id,
                           x.Full_Ad,                           
                       }).ToList();
            UrunlerCmbBox.ValueMember = "Id";
            foreach (var item in ürünlerlistbox)
            {
                SepetListBox.Items.Add(item);
            }
            UrunlerCmbBox.DisplayMember = "Full_Ad";
            UrunlerCmbBox.DataSource = cpu;
            Toplam = Convert.ToDecimal(order.Total_Price);
            totalPriceLabel.Text = Toplam.ToString();
            // combobax'a ürünlerin isimlerini gönderiyor ve  value olarak ıd sini tutuyor

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(customer);
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
            
                
            
            
            
            

