using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class HDXuatDAL
    {
        public static void Them(HDXuat entity)
        {
            String sql = "INSERT INTO HoaDonXuat(MaHDXuat, NgayXuat, MaKhachHang, MaNhanVien, TongTien) VALUES(@MaHDXuat, @NgayXuat, @MaKhachHang, @MaNhanVien, @TongTien)";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDXuat", entity.MaHDXuat);
            Command.Parameters.AddWithValue("@NgayXuat", entity.NgayXuat);
            Command.Parameters.AddWithValue("@MaKhachHang", entity.MaKhachHang);
            Command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);
            Command.Parameters.AddWithValue("@TongTien", entity.TongTien);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Sua(HDXuat entity)
        {
            String sql = "UPDATE HoaDonXuat SET NgayXuat=@NgayXuat, MaKhachHang=@MaKhachHang, MaNhanVien=@MaNhanVien, TongTien=@TongTien WHERE MaHDXuat=@MaHDXuat";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDXuat", entity.MaHDXuat);
            Command.Parameters.AddWithValue("@NgayXuat", entity.NgayXuat);
            Command.Parameters.AddWithValue("@MaKhachHang", entity.MaKhachHang);
            Command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);
            Command.Parameters.AddWithValue("@TongTien", entity.TongTien);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Xoa(String MaHDXuat)
        {
            String sql = "DELETE FROM HoaDonXuat WHERE MaHDXuat=@MaHDXuat";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDXuat", MaHDXuat);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static HDXuat Tim(String MaHDXuat)
        {
            String sql = "SELECT * FROM HoaDonXuat WHERE MaHDXuat = @MaHDXuat";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaHDXuat", MaHDXuat);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var HDXuat = new HDXuat
                {
                    MaHDXuat = Convert.ToString(Reader["MaHDXuat"]),
                    NgayXuat = Convert.ToDateTime(Reader["NgayXuat"]),
                    MaKhachHang = Convert.ToString(Reader["MaKhachHang"]),
                    MaNhanVien = Convert.ToString(Reader["MaNhanVien"]),
                    
                    TongTien = Convert.ToDouble(Reader["TongTien"])

                };
                return HDXuat;
            }
            Command.Connection.Close();
            return null;
        }
        public static List<HDXuat> LietKe()
        {
            String sql = "SELECT * FROM HoaDonXuat";
            var DSHD = TimTheoSql(sql);
            return DSHD;
        }

        public static List<HDXuat> TimTheoSql(String sql)
        {
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            var DSHDXuat = new List<HDXuat>();
            while (Reader.Read())
            {
                var HD = new HDXuat
                {
                    MaHDXuat = Convert.ToString(Reader["MaHDXuat"]),
                    NgayXuat = Convert.ToDateTime(Reader["NgayXuat"]),
                    MaKhachHang = Convert.ToString(Reader["MaKhachHang"]),
                    MaNhanVien = Convert.ToString(Reader["MaNhanVien"]),

                    TongTien = Convert.ToDouble(Reader["TongTien"])
                };
                DSHDXuat.Add(HD);
            }
            Command.Connection.Close();
            return DSHDXuat;
        }
    }
}
