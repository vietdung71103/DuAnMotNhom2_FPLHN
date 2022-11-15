using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private Form activeForm;
        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void ChangeForm(Form form)
        {
            if (activeForm != null)
            {

                activeForm.Close();
            }
            activeForm = form;
            form.TopLevel = false;
            pnl_showmanhinh.Controls.Add(form);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmQLBanHang frm = new FrmQLBanHang();
            ChangeForm(frm);
           
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            FrmQLNhanVien frm = new FrmQLNhanVien();
            ChangeForm(frm);
        }

        private void btn_sach_Click(object sender, EventArgs e)
        {
            FrmQLSanPham frm = new FrmQLSanPham();
            ChangeForm(frm);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmDoiMatKhau frm = new FrmDoiMatKhau();
            ChangeForm(frm);
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            FrmHoaDon frm = new FrmHoaDon();
            ChangeForm(frm);
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            FrmQLKhachHang frm = new FrmQLKhachHang();
            ChangeForm(frm);
        }
    }
}
