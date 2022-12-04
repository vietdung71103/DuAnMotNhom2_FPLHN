using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.Views
{
    public partial class FrmMain : Form
    {
        string AnhURL = "";
        public FrmMain()
        {
            InitializeComponent();
            _iql = new QLNhanVienServices();
            _iqlCV = new QLChucVuServices();
            //var nv = _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined);
        }
        private Form activeForm;
        private Login hello;
        IQLNhanVienServices _iql;
        IQLChucVuServices _iqlCV;
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
            groupBox1.Visible = false;
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                this.Hide();
            Login frm = new Login();
                frm.ShowDialog();
            this.Close();
            }

            if(result == DialogResult.No)
            {
                return;
            }
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            var cv = _iql.GetAll().Where(c => c.NhanViens.Email == Properties.Settings1.Default.userlogined).Select(c => c.ChucVus.Ten).FirstOrDefault();
            if (cv == "Quản lý")
            {
                FrmQLNhanVien frm = new FrmQLNhanVien();
            ChangeForm(frm);
                groupBox1.Visible = false;
            }
            else if(cv != "Quản lý")
            {
                MessageBox.Show("Nhân viên cùi làm gì có quyền này");
            
            }
        }

        private void btn_sach_Click(object sender, EventArgs e)
        {
            FrmQLSanPham frm = new FrmQLSanPham();
            ChangeForm(frm);
            groupBox1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmDoiMatKhau frm = new FrmDoiMatKhau();
            ChangeForm(frm);
            groupBox1.Visible = false;
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            FrmHoaDon frm = new FrmHoaDon();
            ChangeForm(frm);
            groupBox1.Visible = false;
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            FrmQLKhachHang frm = new FrmQLKhachHang();
            ChangeForm(frm);
            groupBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            this.Hide(); 
            FrmMain frm = new FrmMain();
            frm.ShowDialog();
            this.Close();
            //this.Hide();
             //groupBox1.Visible = false;
        }

        //private void pcb_avt_Click(object sender, EventArgs e)
        //{
        //    var nvc = _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined).FirstOrDefault();
        //    lb_mnv.Text = nvc.Ma;
        //    lb_tnv.Text = nvc.Ten;
        //    lb_gt.Text = nvc.GioiTinh;
        //    string formattedDate = nvc.NgaySinh.ToString("dd-MM-yyyy");
        //    lb_ngaysinh.Text = Convert.ToString(formattedDate);
        //    lb_email.Text = nvc.Email;
        //    lb_sdt.Text = nvc.Sdt;
        //    lb_diachi.Text = nvc.DiaChi;
        //    lb_tt.Text = nvc.TrangThai;
        //}

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var layemail = Properties.Settings1.Default.userlogined;
            var nv = _iql.GetListNV().Where(c => c.Email == layemail).FirstOrDefault();
            if(nv.Anh != null)
            {
                string linkanh = nv.Anh.Replace(@"\", @"/");
                if (File.Exists(linkanh))
                {
                    pcb_avt.Image = Image.FromFile(linkanh);
                    pcb_avt.SizeMode = PictureBoxSizeMode.StretchImage;
                }
             //   var cv = _iqlCV.GetListChucVu().FirstOrDefault(c => c.Id == nv.IdChucVu);
                lb_name.Text = "Xin chào " + nv.Ten;
                
            }
        }

        private void pcb_avt_Click_1(object sender, EventArgs e)
        {
            var nvc = _iql.GetAll().Where(c => c.NhanViens.Email == Properties.Settings1.Default.userlogined).FirstOrDefault();
            lb_mnv.Text = nvc.NhanViens.Ma;
            lb_tnv.Text = nvc.NhanViens.Ten;
            lb_gt.Text = nvc.NhanViens.GioiTinh;
            string formattedDate = nvc.NhanViens.NgaySinh.ToString("dd-MM-yyyy");
            lb_ngaysinh.Text = Convert.ToString(formattedDate);
            lb_email.Text = nvc.NhanViens.Email;
            lb_sdt.Text = nvc.NhanViens.Sdt;
            lb_diachi.Text = nvc.NhanViens.DiaChi;
            lb_tt.Text = nvc.NhanViens.TrangThai;
            lb_cv.Text = nvc.ChucVus.Ten;
        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                AnhURL = op.FileName;
            

                var doi = _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined).FirstOrDefault();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đổi ảnh đại diện?", "Thông báo", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    foreach (var item in _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined))
                    {
                        //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                        //File.Copy(AnhURL, Path.Combine(projectDirectory, "Image", "NhanVien", Path.GetFileName(AnhURL)), true);
                        //AnhURL = Path.Combine(projectDirectory, "Image", "NhanVien", Path.GetFileName(AnhURL));
                        item.Anh = AnhURL;
                        _iql.Update(item);
                        pcb_avt.Image = Image.FromFile(op.FileName);
                        pcb_avt.SizeMode = PictureBoxSizeMode.StretchImage;
                        MessageBox.Show("Đổi ảnh đại diện thành công");
                    }
                }
                else
                {
                   
                    return;
                }
            }
            else
            {
                return;
            }
            
            
        }

        private void btn_thongbao_Click(object sender, EventArgs e)
        {
            FrmQLThongKe frm = new FrmQLThongKe();
            ChangeForm(frm);
            groupBox1.Visible = false;
        }
    }
}
