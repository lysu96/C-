using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DanhMuc
    {
        private int _iD;
       
        private String _tenDanhMuc;
        private String _moTa;

        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public string TenDanhMuc
        {
            get
            {
                return _tenDanhMuc;
            }

            set
            {
                _tenDanhMuc = value;
            }
        }

        public string MoTa
        {
            get
            {
                return _moTa;
            }

            set
            {
                _moTa = value;
            }
        }

        public DanhMuc(int _iD, string _tenDanhMuc, string _moTa)
        {
            this.ID = _iD;
            this.TenDanhMuc = _tenDanhMuc;
            this.MoTa = _moTa;
        }
        public DanhMuc()
        {
            
        }

        public static List<DanhMuc> LayDanhMuc(String id)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            String sql;
            if (id==null)
            {
               sql = " Select * from DanhMuc";
            }
            else
            {
                sql = " Select * from DanhMuc where ID ="+id ;
            }
            SqlConnection connect = DBConnect.Connect();
            connect.Open();
            SqlCommand com = new SqlCommand(sql, connect);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            
            da.Fill(dt);

            connect.Dispose();
            connect.Close();
            foreach (DataRow dr in dt.Rows)
            {
                DanhMuc dm = new DanhMuc();
                dm.ID = int.Parse(dr["ID"].ToString());
                dm.TenDanhMuc = dr["TenDanhMuc"].ToString();
                dm.MoTa = dr["MoTa"].ToString();

                list.Add(dm);
            }

            return list;

        } 
    }
}