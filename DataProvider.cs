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
//
namespace DemoQLNhanVien_BTL_
{
   public class DataProvider
    {
      public SqlConnection cnn; 
    
        public void Connection()
        {
            try
            {
                string cnStr = "Server =.; Database =EE; Integrated security = true";

                 cnn = new SqlConnection(cnStr);
                if (cnn != null && cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void DisConnecTion()
        {
            cnn.Close();
        }
        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }
        public string type = null;
        public bool Login(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
          
            string userName = GetMD5(UserName);
            string password = GetMD5(Password);

            Connection();

            string sql = "SELECT Type FROM Users WHERE Username = '" + userName + "' AND Password = '" + password + "'";
            SqlCommand cmd = new SqlCommand(sql);
            
            cmd.Connection = cnn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
           // if(cmd.ExecuteScalar().ToString() != null)
           
                 type = (string)cmd.ExecuteScalar();
           
           
            DisConnecTion();
            try
            {
                if (type == "1" || type == "2")
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu", " error ");
                throw ex;
            }
            finally
            {
                DisConnecTion();
            }
        }
      
    }
}
