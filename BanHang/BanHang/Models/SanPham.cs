using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class SanPham
    {
        
        private int _iD;
       
        private String _tenSanPham;
        
        private String _xuatSu;
        private int _namSanXuat;
        
        private int _donGia;
        private int _maDanhMuc;

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
        [Required(ErrorMessage ="Tên không bỏ trống")]
        public string TenSanPham
        {
            get
            {
                return _tenSanPham;
            }

            set
            {
                _tenSanPham = value;
            }
        }
        [Required(ErrorMessage = "Xuất sứ phẩm không để trống")]
        public string XuatSu
        {
            get
            {
                return _xuatSu;
            }

            set
            {
                _xuatSu = value;
            }
        }

        public int NamSanXuat
        {
            get
            {
                return _namSanXuat;
            }

            set
            {
                _namSanXuat = value;
            }
        }
        [Required(ErrorMessage = "Đơn giá phẩm không để trống")]
        public int DonGia
        {
            get
            {
                return _donGia;
            }

            set
            {
                _donGia = value;
            }
        }

        public int MaDanhMuc
        {
            get
            {
                return _maDanhMuc;
            }

            set
            {
                _maDanhMuc = value;
            }
        }

        public SanPham()
        {

        }
        public SanPham(int _iD, string _tenSanPham, string _xuatSu, int _namSanXuat, int _donGia, int _maDanhMuc)
        {
            this.ID = _iD;
            this.TenSanPham = _tenSanPham;
            this.XuatSu = _xuatSu;
            this.NamSanXuat = _namSanXuat;
            this.DonGia = _donGia;
            this.MaDanhMuc = _maDanhMuc;
        }
        public String TenDanhMuc()
        {
           
              String  sql = " Select DanhMuc.TenDanhMuc  from SanPham , DanhMuc where DanhMuc.ID = MaDanhMuc and SanPham.ID = "+this.ID;
            
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
                return dr["TenDanhMuc"].ToString();
            }
            return "";
        }
        
        public static List<SanPham> LaySanPham(String id)
        {
            List<SanPham> list = new List<SanPham>();
            String sql;
            if (id==null)
            {
                sql = " Select * from SanPham";
            }
            else
            {
                sql = " Select SanPham.* , DanhMuc.TenDanhMuc from SanPham , DanhMuc where DanhMuc.ID = MaDanhMuc and SanPham.ID ="+id;
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
                SanPham sp = new SanPham();
                sp.ID = int.Parse(dr["ID"].ToString());
                sp.TenSanPham = dr["TenSanPham"].ToString();
                sp.XuatSu = dr["XuatSu"].ToString();
                sp.NamSanXuat = int.Parse(dr["NamSanXuat"].ToString());
                sp.DonGia = int.Parse(dr["DonGia"].ToString());
                sp.MaDanhMuc = int.Parse(dr["MaDanhMuc"].ToString());
                

                list.Add(sp);
            }

            return list;

        }
        public static List<SanPham> LaySanPhamGiaNhoHon(String gia)
        {
            List<SanPham> list = new List<SanPham>();
            String sql;
          
                sql = " Select * from SanPham where DonGia < "+gia;
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
                SanPham sp = new SanPham();
                sp.ID = int.Parse(dr["ID"].ToString());
                sp.TenSanPham = dr["TenSanPham"].ToString();
                sp.XuatSu = dr["XuatSu"].ToString();
                sp.NamSanXuat = int.Parse(dr["NamSanXuat"].ToString());
                sp.DonGia = int.Parse(dr["DonGia"].ToString());
                sp.MaDanhMuc = int.Parse(dr["MaDanhMuc"].ToString());


                list.Add(sp);
            }

            return list;

        }
        public static List<SanPham> TimTheoTen(String ten)
        {
            List<SanPham> list = new List<SanPham>();
            String sql;

            sql = " Select SanPham.* from SanPham, DanhMuc where DanhMuc.ID = MaDanhMuc and TenDanhMuc = N'"+ten+"'";
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
                SanPham sp = new SanPham();
                sp.ID = int.Parse(dr["ID"].ToString());
                sp.TenSanPham = dr["TenSanPham"].ToString();
                sp.XuatSu = dr["XuatSu"].ToString();
                sp.NamSanXuat = int.Parse(dr["NamSanXuat"].ToString());
                sp.DonGia = int.Parse(dr["DonGia"].ToString());
                sp.MaDanhMuc = int.Parse(dr["MaDanhMuc"].ToString());


                list.Add(sp);
            }

            return list;

        }

        public static Boolean SuaSanPham(SanPham sp)
        {

            string sqlInsert = "UPDATE SanPham SET TenSanPham =N'"+sp.TenSanPham+"' , XuatSu =N'"+sp.XuatSu+"', NamSanXuat = "+sp.NamSanXuat+" , DonGia ="+sp.DonGia+", MaDanhMuc="+sp.MaDanhMuc+"  where ID ="+sp.ID ;
            SqlConnection con = DBConnect.Connect();
            con.Open();
            SqlCommand cm = new SqlCommand(sqlInsert, con);
            try
            {
                cm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}