using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using DemoQLNhanVien_BTL_;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private DataProvider daP;
        private ChucNang cn;
        private DataSet ds;
        // private DataTable daT;
        [TestInitialize]
        public void SetUp()
        {
            daP = new DataProvider();
            cn = new ChucNang();
            ds = cn.GetData();
        }
        [TestMethod]
        public void TestLoginGiamDoc()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "Admin";
            string pass = "GiamDoc";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginQuanLy()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "Client";
            string pass = "QuanLy";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginNullID()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = "sasa";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginNullPass()
        {
            SetUp();
            bool expected = false;

            string user = "Admin";
            string pass = " ";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestLoginEmpty()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = " ";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThem()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);

        }
        [TestMethod]
        public void TestThemNullID()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, " ", "Nguyen Van A", "31 NK", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }

        [TestMethod]
        public void TestThemNullHoTen()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", " ", "31 NK", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullDiaChi()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", " ", "0123465789", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }

        [TestMethod]
        public void TestThemNullSDT()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", "31 NK", " ", "Nhan Vien");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullChucVu()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "123", "Nguyen Van A", "31 NK", "0123465789", " ");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemEmpty()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, " ", " ", " ", " ", " ");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestSuaID()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("12", "Nguyen Van A", "acb", "0123", "Nhân Viên");

            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("12", daTs.Rows[0][0]);
        }
        [TestMethod]
        public void TestSuaHoTen()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van B", "acb", "0123", "Nhân Viên");

            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("Nguyen Van B", daTs.Rows[0][1]);
        }


        [TestMethod]
        public void TestSuaDiaChi()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van A", "3711 NK", "0123", "Nhân Viên");
            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("3711 NK", daTs.Rows[0][2]);
        }

        [TestMethod]
        public void TestSuaSDT()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van A", "3711 NK", "0123456789", "Nhân Viên");
            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("0123456789", daTs.Rows[0][3]);
        }

        [TestMethod]
        public void TestSuaChucVu()
        {
            SetUp();
            DataTable daTs = ds.Tables[0];
            cn.Them(daTs, "123", "Nguyen Van A", "acb", "0123", "Nhân Viên");
            GiamDoc gd = new GiamDoc("123", "Nguyen Van A", "3711 NK", "0123456789", "Giam Doc");
            cn.Sua(daTs.Rows[0], gd);
            Assert.AreEqual("Giam Doc", daTs.Rows[0][4]);
        }
        private int luong = 200000;
        [TestMethod]
        public void TesTTinhLuongGD()
        {
            int soNgayLam = 26;
            int chon = 1;
            double expected = 26 * 2.5 * luong;
            double actual = cn.TinhLuong(soNgayLam, chon);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TesTTinhLuongPGD()
        {
            int soNgayLam = 26;
            int chon = 2;
            double expected = 26 * 2.0 * luong;
            double actual = cn.TinhLuong(soNgayLam, chon);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TesTTinhLuongTP()
        {
            int soNgayLam = 26;
            int chon = 3;
            double expected = 26 * 1.5 * luong;
            double actual = cn.TinhLuong(soNgayLam, chon);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TesTTinhLuongNV()
        {
            int soNgayLam = 26;
            int chon = 4;
            double expected = 26 * 1.2 * luong;
            double actual = cn.TinhLuong(soNgayLam, chon);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestXoa()
        {
            SetUp();
            DataTable daTx = ds.Tables[0];
            cn.Them(daTx, "1232123", "Nguyen Van A", "acb", "0123", "Nhân Viên");//dong 0
            cn.Them(daTx, "12343", "Nguyen Van B", "acb", "0123", "Nhân Viên");//dong muon xoa 1
            cn.Them(daTx, "12351", "Nguyen Van C", "acb", "0123", "Nhân Viên");//dong 2
            cn.Them(daTx, "12353", "Nguyen Van D", "acb", "0123", "Nhân Viên");
            cn.Them(daTx, "10353", "Nguyen Van E", "acb", "0123", "Nhân Viên");

            cn.Del(0, daTx);// xoa 1 dong muon xoa
            Assert.AreEqual(4, daTx.Rows.Count);// so dong con lai
            cn.Del(0, daTx);//xoa nhung dong con lai
            cn.Del(0, daTx);
            cn.Del(0, daTx);
            cn.Del(0, daTx);

        }
        [TestMethod]
        public void TestXoaGiua()
        {
            SetUp();
            DataTable daTx = ds.Tables[0];
            cn.Them(daTx, "1232123", "Nguyen Van A", "acb", "0123", "Nhân Viên");//dong 0
            cn.Them(daTx, "12343", "Nguyen Van B", "acb", "0123", "Nhân Viên");//dong muon xoa 1
            cn.Them(daTx, "12351", "Nguyen Van C", "acb", "0123", "Nhân Viên");//dong 2
            cn.Them(daTx, "12353", "Nguyen Van D", "acb", "0123", "Nhân Viên");
            cn.Them(daTx, "10353", "Nguyen Van E", "acb", "0123", "Nhân Viên");

            cn.Del(2, daTx);// xoa 1 dong muon xoa
            Assert.AreEqual(4, daTx.Rows.Count);// so dong con lai
            cn.Del(0, daTx);//xoa nhung dong con lai
            cn.Del(0, daTx);
            cn.Del(0, daTx);
            cn.Del(0, daTx);

        }
        [TestMethod]
        public void TestXoaCuoi()
        {
            SetUp();
            DataTable daTx = ds.Tables[0];
            cn.Them(daTx, "1232123", "Nguyen Van A", "acb", "0123", "Nhân Viên");//dong 0
            cn.Them(daTx, "12343", "Nguyen Van B", "acb", "0123", "Nhân Viên");//dong muon xoa 1
            cn.Them(daTx, "12351", "Nguyen Van C", "acb", "0123", "Nhân Viên");//dong 2
            cn.Them(daTx, "12353", "Nguyen Van D", "acb", "0123", "Nhân Viên");
            cn.Them(daTx, "10353", "Nguyen Van E", "acb", "0123", "Nhân Viên");

            cn.Del(4, daTx);// xoa 1 dong muon xoa
            Assert.AreEqual(4, daTx.Rows.Count);// so dong con lai
            cn.Del(0, daTx);//xoa nhung dong con lai
            cn.Del(0, daTx);
            cn.Del(0, daTx);
            cn.Del(0, daTx);

        }
    }
}

