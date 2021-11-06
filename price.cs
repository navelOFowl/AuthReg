using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthReg
{
    public partial class Занятия
    {
        public string Price
        {
            get
            {
                return Стоимость.ToString() + "р.";
            }
        }
    }
}
