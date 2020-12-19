using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace onthilai.Models
{
    public class dlsach
    {
        private int ma_sach;
        private string ten_sach;
        private int nxb_sach;
        private float dongia_sach;
        private int tg_dach;

        public int masach
        {
            get
            {
                return ma_sach;
            }
            set
            {
                ma_sach = value;
            }
        }

        public string tensach
        {
            get
            {
                return ten_sach;
            }
            set
            {
                ten_sach = value;
            }
        }

        public int nxbsach
        {
            get
            {
                return nxb_sach;
            }
            set
            {
                nxb_sach = value;
            }
        }

        public float dongiasach
        {
            get
            {
                return dongia_sach;
            }
            set
            {
                dongia_sach = value;
            }
        }

        public int tgdach
        {
            get
            {
                return tg_dach;
            }
            set
            {
                tg_dach = value;
            }
        }

     /*   public dlsach()
        {

        }

        public dlsach(int ma_s, string ten_s, int nxb_s, float dongia_s, string tg_s)
        {
            this.masach = ma_s;
            this.tensach = ten_s;
            this.nxbsach = nxb_s;
            this.dongiasach = dongia_s;
            this.tgdach = tg_s;
        }
        */

        public static List<dlsach> getdlsach(string ma_s)
        {
            string sql;
            if (string.IsNullOrEmpty(ma_s))
            {
                sql = "SELECT * FROM tb_sach";
            }
            else
            {
                sql = "SELECT * FROM tb_sach WHERE ma_s='" + ma_s + "'";
            }

            List<dlsach> sach = new List<dlsach>();
            SqlConnection conn = connect.getSqlConnection();
            conn.Open();
            SqlCommand command = new SqlCommand(sql,conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            adapter.Dispose();
            conn.Close();

            foreach (DataRow data in table.Rows)
            {
                dlsach s = new dlsach();
                s.masach = Convert.ToInt32(data["ma_sach"].ToString());
                s.tensach = data["ten_sach"].ToString();
                s.nxbsach = int.Parse(data["nxb_sach"].ToString());
                s.dongiasach = float.Parse(data["dongia_sach"].ToString());
                s.tgdach = int.Parse(data["ma_tg"].ToString());

                sach.Add(s);
            }

            return sach;

        }





    }
}