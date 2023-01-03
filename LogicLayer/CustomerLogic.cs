using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using EntityLayer;
namespace LogicLayer
{
    public class CustomerLogic
    {
        PcToplamaEntities db = new PcToplamaEntities();
        CustomerProcess CustomerProcess = new CustomerProcess();
        public bool AddCustomer(tbl_Customer customer)
        {
            var ts = (DateTime.Now - Convert.ToDateTime(customer.Doğum_Tarihi)).TotalDays;
            int yıl = (int)(ts / 365);
            var temp = db.tbl_Customer.Where(x => x.Username == customer.Username).FirstOrDefault();

            if (customer.Ad.Length < 3)
            {
                MessageBox.Show("Ad girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (customer.Soyad.Length < 2 || customer.Soyad.All(Char.IsLetter) == false)
            {
                MessageBox.Show("Soyad girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;


            }
            else if (customer.TC.Length != 11 || customer.TC.All(Char.IsDigit) == false)
            {
                MessageBox.Show("TC girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;


            }
            else if (customer.Telno.Length < 10 || customer.Telno.All(Char.IsLetter) == true)
            {
                MessageBox.Show("Telefon numarası girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (customer.Adres.Length < 2)
            {
                MessageBox.Show("Adres alanı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (yıl < 18)
            {
                MessageBox.Show("Kayıt olmak için gerekli yaşa sahip değilsiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (customer.Email.Length < 1)
            {
                MessageBox.Show("Mail adresi yeri boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (temp != null)
            {
                MessageBox.Show("Bu kullanıcı adı hali hazırda kullanılmaktadır lütfen başka bir kullanıcı adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (customer.Password.Length <= 8)
            {
                MessageBox.Show("Girdiğiniz şifre çok kısadır lütfen başka bir şifre giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (customer.Username.Length <= 4)
            {
                MessageBox.Show("Lütfen daha fazla karakter içeren kullanıcı adı giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                customer.Admin_Customer = false;
                CustomerProcess.Addmy(customer);
                return true;

            }
            
        }
        public void RemoveCustomer(tbl_Customer customer)
        {
            CustomerProcess.Removemy(customer.ID);
        }
        public void UpdateCustomer(tbl_Customer customer)
        {
            var ts = (DateTime.Now - Convert.ToDateTime(customer.Doğum_Tarihi)).TotalDays;
            int yıl = (int)(ts / 365);
            var temp = db.tbl_Customer.Where(x => x.Username == customer.Username).FirstOrDefault();


            if (customer.Ad.Length < 3 || customer.Ad.All(Char.IsLetter) == false)
            {
                MessageBox.Show("Ad girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (customer.Soyad.Length < 2 || customer.Soyad.All(Char.IsLetter) == false)
            {
                MessageBox.Show("Soyad girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (customer.TC.Length != 11 || customer.TC.All(Char.IsDigit) == false)
            {
                MessageBox.Show("TC girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (customer.Telno.Length < 10 || customer.Telno.All(Char.IsDigit) == false)
            {
                MessageBox.Show("Telefon numarası girdisi yanlış yapılmıştır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (customer.Adres.Length < 2)
            {
                MessageBox.Show("Adres alanı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (yıl < 18)
            //{
            //    MessageBox.Show("Kayıt olmak için gerekli yaşa sahip değilsiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (customer.Email.Length < 1)
            {
                MessageBox.Show("Mail adresi yeri boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if(customer.Password.Length <= 8)// || customer.Password == temp.Password)
            {

                MessageBox.Show("Girdiğiniz şifre çok kısa lütfen başka bir şifre giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CustomerProcess.Updatemy(customer);
            }
        }
    }
}
