using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanHangLapTop.BLL
{
   public class NhanVien
    {
       public String MaNhanVien { get; set; }
       public String TenNhanVien { get; set; }
       public String TaiKhoan { get; set; }
       public String MatKhau { get; set; }
       public bool VaiTro { get; set; }
       public bool GioiTinh { get; set; }
       public String ThongTin { get; set; }

       public String TenVaiTro
       {
           get
           {
               if (VaiTro == true)
               {
                   return "admin";
               }
               else
               {
                   return "nhân viên";
               }
           }
       }

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
