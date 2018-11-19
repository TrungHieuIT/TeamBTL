using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using DemoQLNhanVien_BTL_;
using System.Windows.Forms;

namespace DemoQLNhanVien_BTL_
{
   public class ChucNang
    {
       public SqlConnection cn;
       public DataTable memberTable;
       public SqlDataAdapter da;
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            string sql = " Select * FROM DSNhanVien1";
            DataProvider daP = new DataProvider();
            daP.Connection();
            da = new SqlDataAdapter(sql, daP.cnn);
            da.Fill(ds);
            return ds;
        }
        public void Them (DataTable daT, string id , string name , string phone , string address , string position )
        {
            foreach(DataRow r in daT.Rows)
            {
                if (string.Compare(r["MaNV"].ToString(),id) ==0)
                {
                    MessageBox.Show("Trùng Mã Nhân Viên", "Cảnh Báo");
                    return;
                }
                
            } 
            DataRow row = daT.NewRow();
            row["MaNV"] = id;
            row["HoTenNV"] = name;
            row["DiaChi"] = address;
            row["SDT"] = phone;
            row["ChucVu"] = position;
            daT.Rows.Add(row);       
        }
        public double TinhLuong (int soNgay, int chon)
        {
            double kq = 0;
            switch (chon)
            {
                case 1:
                    {
                        GiamDoc gd = new GiamDoc();
                        kq =gd.TinhTienLuong(soNgay);
                        break;      
                    }
                case 2:
                    {
                        PhoGiamDoc pgd = new PhoGiamDoc();
                        kq = pgd.TinhTienLuong(soNgay);
                        break;
                    }
                case 3:
                    {
                        TruongPhong tp = new TruongPhong();
                        kq = tp.TinhTienLuong(soNgay);
                        break;
                    }
                case 4:
                    {
                        NhanVien nv = new NhanVien();
                        kq = nv.TinhTienLuong(soNgay);
                        break;
                    }
            }
            return kq;
        }

        public void Sua(DataRow row , GiamDoc nv)
        {
            row["MaNV"] = nv.ID;
            row["HoTenNV"] = nv.Name;
            row["DiaChi"] = nv.Address;
            row["SDT"] = nv.Phone;
            row["ChucVu"] = nv.Position;
        }
        public void Update (DataTable daT)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(daT);
        }
        public void Del(int row,DataTable daT)
        {

            daT.Rows[row].Delete();
            da.Update(daT);

        }
    }
}
