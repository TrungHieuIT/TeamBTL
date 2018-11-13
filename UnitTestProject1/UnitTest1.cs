﻿using System;
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
        

    }
}
