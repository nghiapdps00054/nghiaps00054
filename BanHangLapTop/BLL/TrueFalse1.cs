using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanHangLapTop.BLL
{
   public class TrueFalse1
    {
       public bool Type { get; set; }

       public string Name { get; set; }

       public TrueFalse1(bool type, string name)
       {
           this.Type = type;
           this.Name = name;
       }
    }
}
