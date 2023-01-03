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
    public class OrderLogic
    {
        PcToplamaEntities db = new PcToplamaEntities();
        OrderDAL orderDal = new OrderDAL();
        public bool AddOrder(tbl_Order order)
        {
            if (order.Cpu_Id == null || order.GPU_Id == null || order.MotherBoard_Id == null || order.Ram_Id == null || order.Disk_Id == null || order.Kulaklık_Id == null || order.Case_Id == null || order.Customer_ID == null || order.Powersup_Id == null || order.Keyboard_Id == null || order.Mouse_Id == null || order.Screen_Id == null || order.Total_Price == null)
            {
                MessageBox.Show("HATA", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                orderDal.Addmy(order);
                return true;
            }
        }
        public void RemoveOrder(tbl_Order order)
        {
            orderDal.Removemy(order.Id);
        }

        public void UpdateOrder(tbl_Order order)
        {
            orderDal.Updatemy(order);

        }
    }
}
