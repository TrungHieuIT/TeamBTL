using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DemoQLNhanVien_BTL_;

namespace DemoQLNhanVien_BTL_
{
    public partial class FrmQuanLy : Form
    {
        public FrmQuanLy()
        {
            InitializeComponent();
        }
        ChucNang cng = new ChucNang();
        private void FrmQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void FrmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cng.Them(cng.memberTable, txtID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, cmbPosition.Text);
            dgvDanhSachQL.DataSource = cng.memberTable;
            txtID.Text = txtName.Text = txtAddress.Text = txtPhone.Text = cmbPosition.Text = "";
            txtID.Focus();
        }
    }
}
