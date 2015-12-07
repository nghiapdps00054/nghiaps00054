using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class KhachHangDAL
    {
        public static void Them(KhachHang entity)
        {
            String sql = "INSERT INTO KhachHang(MaKhachHang, TenKhachHang, GioiTinh, DiaChi, Email, MaLoaiKH) VALUES(@MaKhachHang, @TenKhachHang, @GioiTinh, @DiaChi, @Email, @MaLoaiKH)";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaKhachHang", entity.MaKhachHang);
            Command.Parameters.AddWithValue("@TenKhachHang", entity.TenKhachHang);
            Command.Parameters.AddWithValue("@GioiTinh", entity.GioiTinh);
            Command.Parameters.AddWithValue("@DiaChi", entity.DiaChi);
            Command.Parameters.AddWithValue("@Email", entity.Email);
            Command.Parameters.AddWithValue("@MaLoaiKH", entity.MaLoaiKH);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Sua(KhachHang entity)
        {
            String sql = "UPDATE KhachHang SET TenKhachHang=@TenKhachHang, GioiTinh=@GioiTinh, DiaChi=@DiaChi, Email=@Email, MaLoaiKH=@MaLoaiKH WHERE MaKhachHang=@MaKhachHang";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaKhachHang", entity.MaKhachHang);
            Command.Parameters.AddWithValue("@TenKhachHang", entity.TenKhachHang);
            Command.Parameters.AddWithValue("@GioiTinh", entity.GioiTinh);
            Command.Parameters.AddWithValue("@DiaChi", entity.DiaChi);
            Command.Parameters.AddWithValue("@Email", entity.Email);
            Command.Parameters.AddWithValue("@MaLoaiKH", entity.MaLoaiKH);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Xoa(String MaKhachHang)
        {
            String sql = "DELETE FROM KhachHang WHERE MaKhachHang=@MaKhachHang";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static KhachHang Tim(String MaKhachHang)
        {
            String sql = "SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var KhachHang = new KhachHang
                {
                    MaKhachHang = Convert.ToString(Reader["MaKhachHang"]),
                    TenKhachHang = Convert.ToString(Reader["TenKhachHang"]),
                    GioiTinh = Convert.ToBoolean(Reader["GioiTinh"]),
                    DiaChi = Convert.ToString(Reader["DiaChi"]),
                    Email = Convert.ToString(Reader["Email"]),
                    MaLoaiKH = Convert.ToString(Reader["MaLoaiKH"])

                };
                return KhachHang;
            }
            Command.Connection.Close();
            return null;
        }
        public static List<KhachHang> LietKe()
        {
            String sql = "SELECT * FROM KhachHang";
            var DSKhachHang = TimTheoSql(sql);
            return DSKhachHang;
        }

        public static List<KhachHang> TimTheoSql(String sql)
        {
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            var DSKhachHang = new List<KhachHang>();
            while (Reader.Read())
            {
                var KH = new KhachHang
                {
                    MaKhachHang = Convert.ToString(Reader["MaKhachHang"]),
                    TenKhachHang = Convert.ToString(Reader["TenKhachHang"]),
                    GioiTinh = Convert.ToBoolean(Reader["GioiTinh"]),
                    DiaChi = Convert.ToString(Reader["DiaChi"]),
                    Email = Convert.ToString(Reader["Email"]),
                    MaLoaiKH = Convert.ToString(Reader["MaLoaiKH"])

                };
                DSKhachHang.Add(KH);
            }
            Command.Connection.Close();
            return DSKhachHang;
        }
    }
}
