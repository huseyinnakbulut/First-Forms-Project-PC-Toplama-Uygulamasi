using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
namespace DAL
{
    public class CustomerProcess : ICrud<tbl_Customer>
    {
        PcToplamaEntities db = new PcToplamaEntities();
        public void Addmy(tbl_Customer Entity)
        {

            tbl_Customer ekle = new tbl_Customer();
            ekle.Ad = Entity.Ad;
            ekle.Soyad = Entity.Soyad;
            ekle.TC = Entity.TC;
            ekle.City = Entity.City;
            ekle.Telno = Entity.Telno;
            ekle.Adres = Entity.Adres;
            //var date1 = new DateTime(2008, 5, 1, 8, 30, 52);  //bu düzeltilecek
            ekle.Doğum_Tarihi = Entity.Doğum_Tarihi;
            ekle.Email = Entity.Email;
            ekle.Username = Entity.Username;
            ekle.Password = Entity.Password;
            ekle.Admin_Customer = Entity.Admin_Customer;

            db.tbl_Customer.Add(ekle);

            db.SaveChanges();

        }

        public void Removemy(int Id)
        {

            var customer = db.tbl_Customer.Find(Id);
            db.tbl_Customer.Remove(customer);
            db.SaveChanges();
        }

        public void Updatemy(tbl_Customer Entity)
        {
            //tbl_Customer update = new tbl_Customer();
            var customer = db.tbl_Customer.Find(Entity.ID);
            customer.Ad = Entity.Ad;
            customer.Soyad = Entity.Soyad;
            customer.TC = Entity.TC;
            customer.City = Entity.City;
            customer.Telno = Entity.Telno;
            customer.Adres = Entity.Adres;
            customer.Doğum_Tarihi = Entity.Doğum_Tarihi;
            customer.Email = Entity.Email;
            customer.Password = Entity.Password;
            db.SaveChanges();

        }
    }
}
