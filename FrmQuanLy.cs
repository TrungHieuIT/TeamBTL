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
           
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvDanhSachQL.Columns[col] is DataGridViewButtonColumn && dgvDanhSachQL.Columns[col].Name == "delete")
            {

                if (row >= 0 && row < dgvDanhSachQL.Rows.Count)
                {
                    cng.Del(row,cng.memberTable);
                }
            }
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            int aa = Convert.ToInt32(txtDay.Text);
            int chon = 0;
            ChucNang cng = new ChucNang();
            double kq = 0;
            if (cmbPosition.Text == "Giám Ðốc")
            {
                chon = 1;
                kq = cng.TinhLuong(aa, chon);
                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Phó Giám Đốc")
            {
                chon = 2;
                kq = cng.TinhLuong(aa, chon);
                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Trưởng Phòng")
            {
                chon = 3;
                kq = cng.TinhLuong(aa, chon);

                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Nhân Viên")
            {
                chon = 4;
                kq = cng.TinhLuong(aa, chon);
                dgvDanhSachQL.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSachQL.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
        }

        private void dgvDanhSachQL_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbChucVu.Visible = false;
            cmbPosition.Visible = false;
            int numrow;
            numrow = e.RowIndex;
            txtID.Text = dgvDanhSachQL.Rows[numrow].Cells["id"].Value.ToString();
            txtName.Text = dgvDanhSachQL.Rows[numrow].Cells["name"].Value.ToString();
            txtAddress.Text = dgvDanhSachQL.Rows[numrow].Cells["address"].Value.ToString();
            txtPhone.Text = dgvDanhSachQL.Rows[numrow].Cells["phone"].Value.ToString();
            cmbPosition.Text = dgvDanhSachQL.Rows[numrow].Cells["position"].Value.ToString();

            if (txtID.Text != "")
            {
                lbSoNgayLam.Visible = true;
                txtDay.Visible = true;
                btnChange.Enabled = true;

                btnCalculator.Enabled = true;
            }
            else
            {
                lbSoNgayLam.Visible = false;
                txtDay.Visible = false;
                btnChange.Enabled = false;

                btnCalculator.Enabled = false;


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cng.Update(cng.memberTable);
            MessageBox.Show("Cập nhập thành công ", "Cập Nhập");
            txtID.Text = txtDay.Text = txtName.Text = txtAddress.Text = txtPhone.Text = cmbPosition.Text = "";
            txtID.Focus();
        }
    }
}
