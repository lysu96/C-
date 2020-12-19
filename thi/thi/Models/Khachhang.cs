using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;
using System.Data;
namespace thi.Models
{
    public class Khachhang
    {
        public int ID { get; set; }
     //   [Required(ErrorMessage = "* Họ và tên không được để trống")]
     //   [StringLength(30, ErrorMessage = "* Độ dài tối đa là 30")]
        public string ma_kh { get; set; }
     //   [Required(ErrorMessage = "* Địa chỉ không được để trống")]
      //  [StringLength(50, ErrorMessage = "* Độ dài tối đa là 50")]
        public string ten_kh { get; set; }
        public int cmt { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string tt_them { get; set; }

        // hiện thị
        public static List<Khachhang> GetHocSinh(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM tb_taikhoan";
            }
            else
            {
                sql = "SELECT * FROM tb_taikhoan WHERE ID='" + ID + "'";
            }
            List<Khachhang> dskh = new List<Khachhang>();
            // string strcon = ConfigurationManager.ConnectionStrings["CSDL"].ConnectionString;
            // MySqlConnection connection = new MySqlConnection(strcon);

            MySqlConnection connection = Dbconnect.GetSqlConnection();
            connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataAdapter.Dispose();
            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                Khachhang kh = new Khachhang();
                kh.ID = Convert.ToInt32(row["id"].ToString());
                kh.ma_kh = row["ma_kh"].ToString();
                kh.ten_kh = row["ten_kh"].ToString();
                kh.cmt = int.Parse(row["cmt"].ToString());
                kh.sdt = int.Parse(row["sdt"].ToString());
                kh.diachi = row["diachi"].ToString();
                kh.tt_them = row["tt_them"].ToString();
                dskh.Add(kh);
            }
            return dskh;
        }

        // Thêm
        public static bool them(Khachhang kh)
        {
            string sql = "INSERT INTO `tb_taikhoan`(`id`, `ma_kh`, `ten_kh`, `cmt`, `sdt`, `diachi`, `tt_them`) VALUES (null,'" + kh.ma_kh + "','" + kh.ten_kh + "','" + kh.cmt + "','" + kh.sdt + "','" + kh.diachi + "','" + kh.tt_them + "')";
            string strcon = ConfigurationManager.ConnectionStrings["CSDL"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(strcon); // DatabasaConnect.GetSqlConnection();   
                                                                      //  MySqlCommand sqlCommand = new MySqlCommand(sql);
                                                                      // sqlCommand.Connection = connection;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        // sửa
        public static bool sua(Khachhang kh)
        {
            string sql = "UPDATE `tb_taikhoan` SET ``ma_kh`='" + kh.ma_kh + "',`ten_kh`='" + kh.ten_kh + "',`cmt`='" + kh.cmt + "',`sdt`='" + kh.sdt + "',`diachi`='" + kh.diachi + "',`tt_them`='" + kh.tt_them + "' WHERE ID='" + kh.ID + "'";
            string strcon = ConfigurationManager.ConnectionStrings["CSDL"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(strcon); // DatabasaConnect.GetSqlConnection();
                                                                      //  MySqlCommand sqlCommand = new MySqlCommand(sql);
                                                                      //  sqlCommand.Connection = connection;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}