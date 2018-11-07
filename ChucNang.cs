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
namespace DemoQLNhanVien_BTL_
{
   public class ChucNang
    {
        public void Them (DataTable daT, string id , string name , string phone , string address , string position )
        {
             
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
    }
}
