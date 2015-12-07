using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanHangLapTop.BLL
{
   public class KhachHang
    {
       public String MaKhachHang { get; set; }
       public String TenKhachHang { get; set; }
       public bool GioiTinh { get; set; }
       public String DiaChi { get; set; }
       public String Email { get; set; }
       public String MaLoaiKH { get; set; }

       public String TenGioiTinh
       {
           get
           {
               if (GioiTinh == true)
               {
                   return "Nam";
               }
               else
               {
                   return "Nữ";
               }
           }
       }
    }
}
