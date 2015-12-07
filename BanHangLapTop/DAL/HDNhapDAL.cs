using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class HDNhapDAL
    {
       public static void Them(HDNhap entity)
        {
            String sql = "INSERT INTO HoaDonNhap(MaHDNhap, NgayNhap, MaNhaCC, MaNhanVien, MoTa, TongTien) VALUES(@MaHDNhap, @NgayNhap, @MaNhaCC, @MaNhanVien, @MoTa, @TongTien)";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", entity.MaHDNhap);
            Command.Parameters.AddWithValue("@NgayNhap", entity.NgayNhap);
            Command.Parameters.AddWithValue("@MaNhaCC", entity.MaNhaCC);
            Command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);
            Command.Parameters.AddWithValue("@MoTa", entity.MoTa);
            Command.Parameters.AddWithValue("@TongTien", entity.TongTien);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

       public static void Sua(HDNhap entity)
        {
            String sql = "UPDATE HoaDonNhap SET NgayNhap=@NgayNhap, MaNhaCC=@MaNhaCC, MaNhanVien=@MaNhanVien, MoTa=@MoTa, TongTien=@TongTien WHERE MaHDNhap=@MaHDNhap";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", entity.MaHDNhap);
            Command.Parameters.AddWithValue("@NgayNhap", entity.NgayNhap);
            Command.Parameters.AddWithValue("@MaNhaCC", entity.MaNhaCC);
            Command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);
            Command.Parameters.AddWithValue("@MoTa", entity.MoTa);
            Command.Parameters.AddWithValue("@TongTien", entity.TongTien);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

       public static void Xoa(String MaHDNhap)
        {
            String sql = "DELETE FROM HoaDonNhap WHERE MaHDNhap=@MaHDNhap";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", MaHDNhap);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
       public static HDNhap Tim(String MaHDNhap)
        {
            String sql = "SELECT * FROM HoaDonNhap WHERE MaHDNhap = @MaHDNhap";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaHDNhap", MaHDNhap);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var HDNhap = new HDNhap
                {
                    MaHDNhap = Convert.ToString(Reader["MaHDNhap"]),
                    NgayNhap = Convert.ToDateTime(Reader["NgayNhap"]),
                    MaNhaCC = Convert.ToString(Reader["MaNhaCC"]),
                    MaNhanVien = Convert.ToString(Reader["MaNhanVien"]),
                    MoTa = Convert.ToString(Reader["MoTa"]),
                    TongTien = Convert.ToDouble(Reader["TongTien"])

                };
                return HDNhap;
            }
            Command.Connection.Close();
            return null;
        }
       public static List<HDNhap> LietKe()
        {
            String sql = "SELECT * FROM HoaDonNhap";
            var DSHD = TimTheoSql(sql);
            return DSHD;
        }

       public static List<HDNhap> TimTheoSql(String sql)
        {
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            var DSHDNhap = new List<HDNhap>();
            while (Reader.Read())
            {
                var HD = new HDNhap
                {
                    MaHDNhap = Convert.ToString(Reader["MaHDNhap"]),
                    NgayNhap = Convert.ToDateTime(Reader["NgayNhap"]),
                    MaNhaCC = Convert.ToString(Reader["MaNhaCC"]),
                    MaNhanVien = Convert.ToString(Reader["MaNhanVien"]),
                    MoTa = Convert.ToString(Reader["MoTa"]),
                    TongTien = Convert.ToDouble(Reader["TongTien"])
                };
                DSHDNhap.Add(HD);
            }
            Command.Connection.Close();
            return DSHDNhap;
        }
    }
}
