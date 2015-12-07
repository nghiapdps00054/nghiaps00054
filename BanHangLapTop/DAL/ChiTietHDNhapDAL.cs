using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BanHangLapTop.BLL;

namespace BanHangLapTop.DAL
{
   public class ChiTietHDNhapDAL
    {
        public static void Them(ChiTietHDNhap entity)
        {
            String sql = "INSERT INTO ChiTietHDNhap( MaHDNhap, MaLaptop, SoLuong, GiaNhap) VALUES( @MaHDNhap, @MaLaptop, @SoLuong, @GiaNhap)";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", entity.MaHDNhap);
            Command.Parameters.AddWithValue("@MaLaptop", entity.MaLaptop);
            Command.Parameters.AddWithValue("@SoLuong", entity.SoLuong);
            Command.Parameters.AddWithValue("@GiaNhap", entity.GiaNhap);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Sua(ChiTietHDNhap entity)
        {
            String sql = "UPDATE ChiTietHDNhap SET MaLaptop=@MaLaptop, SoLuong=@SoLuong, GiaNhap=@GiaNhap WHERE MaHDNhap=@MaHDNhap";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", entity.MaHDNhap);
            Command.Parameters.AddWithValue("@MaLaptop", entity.MaLaptop);
            Command.Parameters.AddWithValue("@SoLuong", entity.SoLuong);
            Command.Parameters.AddWithValue("@GiaNhap", entity.GiaNhap);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Xoa(String MaHDNhap)
        {
            String sql = "DELETE FROM ChiTietHDNhap WHERE MaHDNhap=@MaHDNhap";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", MaHDNhap);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static ChiTietHDNhap Tim(String MaHDNhap)
        {
            String sql = "SELECT * FROM ChiTietHDNhap WHERE MaHDNhap = @MaHDNhap";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaHDNhap", MaHDNhap);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var CTHDNhap = new ChiTietHDNhap
                {
                    MaHDNhap = Convert.ToString(Reader["MaHDNhap"]),
                    MaLaptop = Convert.ToString(Reader["MaLaptop"]),
                    SoLuong = Convert.ToInt32(Reader["SoLuong"]),
                    GiaNhap = Convert.ToDouble(Reader["GiaNhap"])

                };
                return CTHDNhap;
            }
            Command.Connection.Close();
            return null;
        }
        public static List<ChiTietHDNhap> LietKe()
        {
            String sql = "SELECT * FROM ChiTietHDNhap";
            var DSHD = TimTheoSql(sql);
            return DSHD;
        }

        public static List<ChiTietHDNhap> TimTheoSql(String sql)
        {
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            var DSHDNhap = new List<ChiTietHDNhap>();
            while (Reader.Read())
            {
                var HD = new ChiTietHDNhap
                {
                    MaHDNhap = Convert.ToString(Reader["MaHDNhap"]),
                    MaLaptop = Convert.ToString(Reader["MaLaptop"]),
                    SoLuong = Convert.ToInt32(Reader["SoLuong"]),
                    GiaNhap = Convert.ToDouble(Reader["GiaNhap"])

                };
                DSHDNhap.Add(HD);
            }
            Command.Connection.Close();
            return DSHDNhap;
        }
    }
}
