using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal interface ICrud<T>
    {
        void Addmy(T Entity);
        void Removemy(int t);
        void Updatemy(T Entity);

    }
}
