using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class LoaiLaptopDAL
    {
        public static void Them(LoaiLaptop entity)
        {
            String sql = "INSERT INTO LoaiLaptop(MaLoai, TenLoai) VALUES(@MaLoai, @TenLoai)";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaLoai", entity.MaLoai);
            Command.Parameters.AddWithValue("@TenLoai", entity.TenLoai);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static void Sua(LoaiLaptop entity)
        {
            String sql = "UPDATE LoaiLaptop SET TenLoai = @TenLoai WHERE MaLoai = @MaLoai";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaLoai", entity.MaLoai);
            Command.Parameters.AddWithValue("@TenLoai", entity.TenLoai);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static void Xoa(String MaLoai)
        {
            String sql = "DELETE FROM LoaiLaptop WHERE MaLoai = @MaLoai";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaLoai",MaLoai);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static LoaiLaptop Tim(String MaLoai)
        {
            String sql = "SELECT * FROM LoaiLaptop WHERE MaLoai = @MaLoai";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaLoai", MaLoai);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var LoaiLaptop = new LoaiLaptop
                {
                    MaLoai = Convert.ToString(Reader["MaLoai"]),
                    TenLoai = Convert.ToString(Reader["TenLoai"]),

                };
                return LoaiLaptop;
            }
            Command.Connection.Close();
            return null;
        }
        public static List<LoaiLaptop> LietKe()
        {
            String sql = "SELECT * FROM LoaiLaptop";
            var DSLoaiLaptop = TimTheoSql(sql);
            return DSLoaiLaptop;
        }

        public static List<LoaiLaptop> TimTheoSql(String sql)
        {
            SqlCommand command = new SqlCommand(sql, DB.Connection);

            command.Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            var DSLoaiLaptop = new List<LoaiLaptop>();
            while (Reader.Read())
            {
                var LoaiLaptop = new LoaiLaptop
                {
                    MaLoai = Convert.ToString(Reader["MaLoai"]),
                    TenLoai = Convert.ToString(Reader["TenLoai"])

                };
                DSLoaiLaptop.Add(LoaiLaptop);
            }
            command.Connection.Close();
            return DSLoaiLaptop;
        }
    }
}
