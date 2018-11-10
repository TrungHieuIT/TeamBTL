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
    public partial class FrmGiamDoc : Form
    {
       
        public FrmGiamDoc()
        {
            InitializeComponent();
        }

   
        ChucNang cng = new ChucNang();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cng.Them(cng.memberTable, txtID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, cmbPosition.Text);
            dgvDanhSach.DataSource =cng.memberTable;
            txtID.Text = txtDay.Text = txtName.Text = txtAddress.Text = txtPhone.Text = cmbPosition.Text = "";
            txtID.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e) //pass
        {
           cng.Update();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) //pass
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dgvDanhSach.Columns[col] is DataGridViewButtonColumn && dgvDanhSach.Columns[col].Name == "delete")
            {
               
                if (row >= 0 && row < dgvDanhSach.Rows.Count)
                {
                    cng.Del(row);
                }
            }
        }

        private void FrmGiamDoc_Load(object sender, EventArgs e)//pass
        {
            string cnStr = "Server =DESKTOP-7AHBV06\\SQLEXPRESS; Database = QLNV; Integrated security = true ;";
            cng.cn = new SqlConnection(cnStr);
            DataSet ds = cng.GetData();
            cng.memberTable = ds.Tables[0];
            dgvDanhSach.DataSource = cng.memberTable;
        }
        private void FrmGiamDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//pass
        {
            int numrow;
            numrow = e.RowIndex;
            txtID.Text = dgvDanhSach.Rows[numrow].Cells["id"].Value.ToString();
            txtName.Text = dgvDanhSach.Rows[numrow].Cells["name"].Value.ToString();
            txtAddress.Text = dgvDanhSach.Rows[numrow].Cells["address"].Value.ToString();
            txtPhone.Text = dgvDanhSach.Rows[numrow].Cells["phone"].Value.ToString();
            cmbPosition.Text = dgvDanhSach.Rows[numrow].Cells["position"].Value.ToString();

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

        private void btnCalculator_Click(object sender, EventArgs e) // pass
        {
            int a = Convert.ToInt32(txtDay.Text);
            int chon = 0;
            ChucNang cng = new ChucNang();
            double kq = 0;
            if (cmbPosition.Text == "Giám Ðốc")
            {
                chon = 1;
                kq = cng.TinhLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Phó Giám Đốc")
            {
                chon = 2;
                kq = cng.TinhLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Trưởng Phòng")
            {
                chon = 3;
                kq = cng.TinhLuong(a, chon);

                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }
            if (cmbPosition.Text == "Nhân Viên")
            {
                chon = 4;
                kq = cng.TinhLuong(a, chon);
                dgvDanhSach.SelectedRows[0].Cells["day"].Value = txtDay.Text;
                dgvDanhSach.SelectedRows[0].Cells["Luong"].Value = kq.ToString();
            }


        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
            {
                if (dgvDanhSach.Rows[i].Selected)
                {
                    string id, name, address, phone, position;
                    id = txtID.Text;
                    name = txtName.Text;
                    address = txtAddress.Text;
                    phone = txtPhone.Text;
                    position = cmbPosition.Text;

                    GiamDoc gd = new GiamDoc(id , name,address,phone,position);
                    DataRow row = cng.memberTable.Rows[i];
                    cng.Sua(row,gd);
                }
            
            //for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
            //{
            //    if (dgvDanhSach.Rows[i].Selected)
            //    {
            //        dgvDanhSach.Rows[i].Cells["id"].Value = txtID.Text;
            //        dgvDanhSach.Rows[i].Cells["name"].Value = txtName.Text;
            //        dgvDanhSach.Rows[i].Cells["address"].Value = txtAddress.Text;
            //        dgvDanhSach.Rows[i].Cells["phone"].Value = txtPhone.Text;
            //        dgvDanhSach.Rows[i].Cells["position"].Value = cmbPosition.Text;
            //    }
        }
        }
            
        }
    }

