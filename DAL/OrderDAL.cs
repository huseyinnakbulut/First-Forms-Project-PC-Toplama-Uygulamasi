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
    public class OrderDAL : ICrud<tbl_Order>
    {
        PcToplamaEntities db = new PcToplamaEntities();

        public void Addmy(tbl_Order Entity)
        {
            tbl_Order order = new tbl_Order();
            order.Cpu_Id = Entity.Cpu_Id;
            order.GPU_Id= Entity.GPU_Id;
            order.MotherBoard_Id= Entity.MotherBoard_Id;
            order.Ram_Id= Entity.Ram_Id;
            order.Disk_Id= Entity.Disk_Id;
            order.Kulaklık_Id = Entity.Kulaklık_Id;
            order.Case_Id= Entity.Case_Id;
            order.Customer_ID = Entity.Customer_ID;
            order.Date=Entity.Date;
            order.Powersup_Id= Entity.Powersup_Id;
            order.Keyboard_Id= Entity.Keyboard_Id;
            order.Mouse_Id= Entity.Mouse_Id;
            order.Screen_Id= Entity.Screen_Id;
            order.Total_Price= Entity.Total_Price;


            db.tbl_Order.Add(order);
            db.SaveChanges();
        }

        public void Removemy(int Id)
        {
            var order = db.tbl_Order.Find(Id);
            db.tbl_Order.Remove(order);
            db.SaveChanges();
        }

        public void Updatemy(tbl_Order Entity)
        {
            
            var order = db.tbl_Order.Find(Entity.Id);
            order.Cpu_Id = Entity.Cpu_Id;
            order.GPU_Id = Entity.GPU_Id;
            order.MotherBoard_Id = Entity.MotherBoard_Id;
            order.Ram_Id = Entity.Ram_Id;
            order.Disk_Id = Entity.Disk_Id;
            order.Kulaklık_Id = Entity.Kulaklık_Id;
            order.Case_Id = Entity.Case_Id;
            order.Customer_ID = Entity.Customer_ID;
            //order.Date = DateTime.Now;
            order.Powersup_Id = Entity.Powersup_Id;
            order.Keyboard_Id = Entity.Keyboard_Id;
            order.Mouse_Id = Entity.Mouse_Id;
            order.Screen_Id = Entity.Screen_Id;
            order.Total_Price = Entity.Total_Price;
            db.SaveChanges();

        }
    }
}
