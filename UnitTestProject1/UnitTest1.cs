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
            cn.Them(daTt, "123", "Nguyen Van A", "31 NK", "0123465789", "Nhân Viên");
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
    }
}

