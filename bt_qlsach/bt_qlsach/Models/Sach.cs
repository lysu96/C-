using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace bt_qlsach.Models
{
    public class Sach
    {
        public int ID { set; get; }
        public string maS { set; get; }
        public string tenS { set; get; }
        public int nSX { set; get; }
        public float donGia { set; get; }
        public string maTG { set; get; }

        public static List<Sach> getSach(string ID)
        {
            /*  String sql;
              if (string.IsNullOrEmpty(ID))
              {
                  sql = "SELECT * FROM tbl_sach";
              }
              else
              {
                  sql = "SELECT * FROM tbl_sach WHERE ID='"+ ID +"'";
              }
              List<Sach> dsach = new List<Sach>();
              SqlConnection conn = DBConnect.getConnection();
              conn.Open();
              SqlDataAdapter sqlData = new SqlDataAdapter(sql,conn);
              DataTable dataTable = new DataTable();
              sqlData.Fill(dataTable);
              sqlData.Dispose();
              conn.Close();
              foreach(DataRow dataRow in dataTable.Rows)
              {
                  Sach s = new Sach();
                  s.ID = Convert.ToInt32(dataRow["ID"].ToString());
                  s.maS = dataRow["maS"].ToString();
                  s.tenS = dataRow["tenS"].ToString();
                  s.nSX = int.Parse(dataRow["nSX"].ToString());
                  s.donGia = float.Parse(dataRow["donGia"].ToString());
                  s.maTG = dataRow["maTG"].ToString();
                  dsach.Add(s);
              } */

            var dsach = new List<Sach>();
            dsach.Add(new Sach
            {
                ID = 1,
                maS = "SH01",
                tenS = "Lập trình c#",
                nSX = 2005,
                donGia = 100000,
                maTG = "TG02"
            });
            dsach.Add(new Sach
            {
                ID = 2,
                maS = "SH02",
                tenS = "Lập trình databasebox",
                nSX = 2007,
                donGia = 200000,
                maTG = "TG03"
            });
            dsach.Add(new Sach
            {
                ID = 3,
                maS = "SH03",
                tenS = "Lập trình javascriptbox",
                nSX = 2012,
                donGia = 500000,
                maTG = "TG01"
            });


            return dsach;
        }

    }
}