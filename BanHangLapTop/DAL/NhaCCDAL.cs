using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class NhaCCDAL
    {
       public static void Them(NhaCC entity) 
       {
           String sql = "INSERT INTO NhaCC( TenNhaCC) VALUES( @TenNhaCC)";
           SqlCommand Command = new SqlCommand(sql, DB.Connection);
           Command.Parameters.AddWithValue("@MaNhaCC", entity.MaNhaCC);
           Command.Parameters.AddWithValue("@TenNhaCC",entity.TenNhaCC);

           Command.Connection.Open();
           Command.ExecuteNonQuery();
           Command.Connection.Close();
       }
       public static void Sua(NhaCC entity)
       {
           String sql = "UPDATE NhaCC SET TenNhaCC = @TenNhaCC WHERE MaNhaCC = @MaNhaCC";
           SqlCommand Command = new SqlCommand(sql, DB.Connection);
           Command.Parameters.AddWithValue("@MaNhaCC", entity.MaNhaCC);
           Command.Parameters.AddWithValue("@TenNhaCC", entity.TenNhaCC);

           Command.Connection.Open();
           Command.ExecuteNonQuery();
           Command.Connection.Close();
       }
       public static void Xoa(String MaNhaCC)
       {
           String sql = "DELETE FROM NhaCC WHERE MaNhaCC = @MaNhaCC";
           SqlCommand Command = new SqlCommand(sql, DB.Connection);
           Command.Parameters.AddWithValue("@MaNhaCC",MaNhaCC);

           Command.Connection.Open();
           Command.ExecuteNonQuery();
           Command.Connection.Close();
       }
       public static NhaCC Tim(String MaNhaCC)
       {
           String sql = "SELECT * FROM NhaCC WHERE MaNhaCC = @MaNhaCC";
           SqlCommand Command = new SqlCommand(sql, DB.Connection);

           Command.Parameters.AddWithValue("@MaNhaCC", MaNhaCC);

           Command.Connection.Open();
           SqlDataReader Reader = Command.ExecuteReader();
           if (Reader.Read())
           {
               var NhaCC = new NhaCC
               {
                   MaNhaCC = Convert.ToString(Reader["MaNhaCC"]),
                   TenNhaCC = Convert.ToString(Reader["TenNhaCC"]),

               };
               return NhaCC;
           }
           Command.Connection.Close();
           return null;
       }
       public static List<NhaCC> LietKe()
       {
           String sql = "SELECT * FROM NhaCC";
           var DSNHACC = TimTheoSql(sql);
           return DSNHACC;
       }
       public static List<NhaCC> TimTheoSql(String sql)
       {
           SqlCommand Command = new SqlCommand(sql, DB.Connection);

           Command.Connection.Open();
           SqlDataReader Reader = Command.ExecuteReader();
           var DSNCC = new List<NhaCC>();
           while (Reader.Read()) 
           {
               var NhaCC = new NhaCC
               {
                   MaNhaCC = Convert.ToString(Reader["MaNhaCC"]),
                   TenNhaCC = Convert.ToString(Reader["TenNhaCC"]),
               };
               DSNCC.Add(NhaCC);
           }
           Command.Connection.Close();
           return DSNCC;
       }
    }
}
