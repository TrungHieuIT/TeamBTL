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
            string cnStr = "Server =TrungHieuIT\\SQLEXPRESS; Database = EE; Integrated security = true ;";
            cng.cn = new SqlConnection(cnStr);
            DataSet ds = cng.GetData();
            cng.memberTable = ds.Tables[0];
            dgvDanhSachQL.DataSource = cng.memberTable;
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            cmbPosition.Visible = true;
            for (int i = 0; i < dgvDanhSachQL.Rows.Count; i++)
            {
                if (dgvDanhSachQL.Rows[i].Selected)
                {
                    string id, name, address, phone, position;
                    id = txtID.Text;
                    name = txtName.Text;
                    address = txtAddress.Text;
                    phone = txtPhone.Text;
                    position = cmbPosition.Text;
                    GiamDoc gd = new GiamDoc(id, name, address, phone, position);
                    DataRow row = cng.memberTable.Rows[i];
                    cng.Sua(row, gd);
                }
            }
        }

        private void dgvDanhSachQL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            int aa = Convert.ToInt32(txtdayQL.Text);
            int chon = 0;
            ChucNang cng = new ChucNang();
            double kq = 0;
            if (cmbPosition.Text == "Giám Ðốc")
            {
                chon = 1;
                kq = cng.TinhLuong(aa, chon);
                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtdayQL.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Phó Giám Đốc")
            {
                chon = 2;
                kq = cng.TinhLuong(aa, chon);
                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtdayQL.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Trưởng Phòng")
            {
                chon = 3;
                kq = cng.TinhLuong(aa, chon);

                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtdayQL.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Nhân Viên")
            {
                chon = 4;
                kq = cng.TinhLuong(aa, chon);
                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtdayQL.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
        }
    }
}
