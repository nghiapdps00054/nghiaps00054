using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class NhanVienDAL
    {
        public static void Them(NhanVien entity)
        {
            String sql = "INSERT INTO NhanVien(MaNhanVien, TenNhanVien, TaiKhoan, MatKhau, VaiTro, GioiTinh,ThongTin) VALUES(@MaNhanVien, @TenNhanVien, @TaiKhoan, @MatKhau, @VaiTro, @GioiTinh, @ThongTin)";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);
            command.Parameters.AddWithValue("@TenNhanVien", entity.TenNhanVien);
            command.Parameters.AddWithValue("@TaiKhoan", entity.TaiKhoan);
            command.Parameters.AddWithValue("@MatKhau", entity.MatKhau);
            command.Parameters.AddWithValue("@VaiTro", entity.VaiTro);
            command.Parameters.AddWithValue("@GioiTinh", entity.GioiTinh);
            command.Parameters.AddWithValue("@ThongTin", entity.ThongTin);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void Sua(NhanVien entity)
        {
            String sql = "UPDATE NhanVien SET TenNhanVien=@TenNhanVien, TaiKhoan=@TaiKhoan, MatKhau=@MatKhau, VaiTro=@VaiTro, GioiTinh=@GioiTinh, ThongTin = @ThongTin WHERE MaNhanVien=@MaNhanVien";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);
            command.Parameters.AddWithValue("@TenNhanVien", entity.TenNhanVien);
            command.Parameters.AddWithValue("@TaiKhoan", entity.TaiKhoan);
            command.Parameters.AddWithValue("@MatKhau", entity.MatKhau);
            command.Parameters.AddWithValue("@VaiTro", entity.VaiTro);
            command.Parameters.AddWithValue("@GioiTinh", entity.GioiTinh);
            command.Parameters.AddWithValue("@ThongTin", entity.ThongTin);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void Xoa(String MaNhanVien)
        {
            String sql = "DELETE FROM NhanVien WHERE MaNhanVien=@MaNhanVien";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static NhanVien Tim(String MaNhanVien)
        {
            String sql = "SELECT * FROM NhanVien WHERE MaNhanVien=@MaNhanVien";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

            command.Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                var NhanVien = new NhanVien
                {
                    MaNhanVien = Convert.ToString(Reader["MaNhanVien"]),
                    TenNhanVien = Convert.ToString(Reader["TenNhanVien"]),
                    TaiKhoan = Convert.ToString(Reader["TaiKhoan"]),
                    MatKhau = Convert.ToString(Reader["MatKhau"]),
                    GioiTinh = Convert.ToBoolean(Reader["GioiTinh"]),
                    VaiTro = Convert.ToBoolean(Reader["VaiTro"]),
                    ThongTin = Convert.ToString(Reader["ThongTin"])
                };
                return NhanVien;
            }
            command.Connection.Close();
            return null;
        }

        public static List<NhanVien> LietKe()
        {
            String sql = "SELECT * FROM NhanVien";
            var dsnv = TimTheoSql(sql);

            return dsnv;
        }
        public static List<NhanVien> LietKeTheoTen(String TenNhanVien)
        {
            String sql = "SELECT * FROM NhanVien WHERE TenNhanVien LIKE '%" + TenNhanVien + "%'";
            var dsnv = TimTheoSql(sql);

            return dsnv;
        }

        public static List<NhanVien> TimTheoSql(String sql)
        {
            SqlCommand command = new SqlCommand(sql, DB.Connection);

            command.Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            var dsNV = new List<NhanVien>();
            while (Reader.Read())
            {
                var NhanVien = new NhanVien
                {
                    MaNhanVien = Convert.ToString(Reader["MaNhanVien"]),
                    TenNhanVien = Convert.ToString(Reader["TenNhanVien"]),
                    TaiKhoan = Convert.ToString(Reader["TaiKhoan"]),
                    MatKhau = Convert.ToString(Reader["MatKhau"]),
                    GioiTinh = Convert.ToBoolean(Reader["GioiTinh"]),
                    VaiTro = Convert.ToBoolean(Reader["VaiTro"]),
                    ThongTin = Convert.ToString(Reader["ThongTin"])
                };
                dsNV.Add(NhanVien);
            }
            command.Connection.Close();
            return dsNV;
        }
        public static void SuaMatKhau(NhanVien entity)
        {
            String sql = "UPDATE NhanVien SET  MatKhau=@MatKhau WHERE MaNhanVien=@MaNhanVien";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaNhanVien", entity.MaNhanVien);   
            command.Parameters.AddWithValue("@MatKhau", entity.MatKhau);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        
    }
}
