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
using _3.PL.Utilities;
using System.Text.RegularExpressions;

namespace _3.PL.Views
{
    public partial class FrmQLNhanVien : Form
    {
        IQLChucVuServices _iqlCV;
        IQLNhanVienServices _iqlNV;
        Guid _getID;
        CheckClass _check;
        NhanVien nhanVien;
        string AnhURL = "";
        public FrmQLNhanVien()
        {
            InitializeComponent();
            _iqlCV = new QLChucVuServices();
            _iqlNV = new QLNhanVienServices();
            LoadData();
            LoadCBB();
            _check = new CheckClass();
        }
        void LoadCBB()
        {
            foreach (var x in _iqlCV.GetListChucVu())
            {
                cbb_chucvu.Items.Add(x.Ten);

            }
            foreach (var x in _iqlCV.GetListChucVu())
            {
                cbb_loccv.Items.Add(x.Ten);
            }
            foreach (var x in _iqlNV.GetListNV())
            {
                cbb_bc.Items.Add(x.Ma);
            }
          
           
            cbb_gioitinh.Items.Add("Nam");
            cbb_gioitinh.Items.Add("Nữ");
            cbb_trangthai.Items.Add("Hoạt động");
            cbb_trangthai.Items.Add("Không hoạt động");

            cbb_loctrangthai.Items.Add("Hoạt động");
            cbb_loctrangthai.Items.Add("Không hoạt động");
            cbb_loctrangthai.Items.Add("Bỏ lọc");

        }


        void LoadData()
        {
            dtg_show.ColumnCount = 13;
            dtg_show.Rows.Clear();
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã";
            dtg_show.Columns[3].Name = "Tên";
            dtg_show.Columns[4].Name = "Giới tính";
            dtg_show.Columns[5].Name = "Địa chỉ";
            dtg_show.Columns[6].Name = "Chức vụ";
            dtg_show.Columns[7].Name = "Ngày sinh";
            dtg_show.Columns[8].Name = "Trạng thái";
            dtg_show.Columns[9].Name = "Email";
            dtg_show.Columns[10].Name = "Mật khẩu";
            dtg_show.Columns[11].Name = "SDT";
            dtg_show.Columns[12].Name = "Gửi BC";
            foreach (var x in _iqlNV.GetAll())
            {
                dtg_show.Rows.Add(x.NhanViens.Id,
                    stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                    x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh,x.NhanViens.TrangThai, 
                    x.NhanViens.Email, x.NhanViens.Password,x.NhanViens.Sdt);
            }
            
        }

        //private void btn_them_Click(object sender, EventArgs e)
        //{
           
        //}
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Form activeForm;
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();



        }
        private void quảnLýChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLChucVu(), sender);
        }
        private string VietHoaChuDau(string text)
        {
            var temp = text.ToLower();
            return temp.Substring(0, 1).ToUpper() + temp.Substring(1, temp.Length - 1);
        }
        private string MaNhanVien(string ten)
        {
            string[] arrTen = ten.Split(' ');
            string ma = "NV_"; //VietHoaChuDau(arrTen[arrTen.Length - 1]);
            for (int i = 0; i < arrTen.Length; i++)
            {
                ma += VietHoaChuDau(arrTen[i]).Substring(0, 1);
            }
            Random rand = new Random();
            int z = rand.Next(1000, 9999);
            var so = z.ToString();
            return ma + so;
        }
        private void btn_them_Click_1(object sender, EventArgs e)
        {
            
            var checkEmail = _iqlNV.GetListNV().FirstOrDefault(p => p.Email == tbt_email.Text);
            string email = tbt_email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MessageBox.Show("Email không hợp lệ!!!");
                tbt_email.Text = "";
                return ;
            }
            if (tbt_email.Text.Length == 0)
            {
                MessageBox.Show("Email không được trống");
                return;
            
            }
            //if (_check.CheckEmail(tbt_email.Text))
            //{
            //    MessageBox.Show("Email sai định dạng");
            //    return;
            //}
            if (checkEmail != null)
            {
                MessageBox.Show("Email không trùng");
                return;
            }
            if (tbt_tennv.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên");
                return ;
            }
             if (tbt_tennv.Text.Length < 8)
            {
                MessageBox.Show("Tên nhân viên phải có ít nhất 8 kí tự");
                return ;
            }
             if (tbt_sodt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");
                return ;
            }
            if (cbb_chucvu.Text == "")
            {
                MessageBox.Show("Phải chọn chức vụ !");
                return;
            }
            if (!tbt_sodt.Text.All(char.IsNumber))
            {
                MessageBox.Show("Số điện thoại phải là số !");
                return;
            }
            if (cbb_gioitinh.Text == "")
            {
                MessageBox.Show("Phải chọn giới tính !");
                return;
            }
            if (cbb_trangthai.Text == "")
            {
                MessageBox.Show("Phải có trạng thái !");
                return;
            }
            if (pcb_avt.Image == null)
            {
                MessageBox.Show("Ảnh đại diện chưa có kìa bạn trẻ");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                    File.Copy(AnhURL, Path.Combine(projectDirectory, "Image", "NhanVien", Path.GetFileName(AnhURL)), true);
                    AnhURL = Path.Combine(projectDirectory, "Image", "NhanVien", Path.GetFileName(AnhURL));
                    //int mnv = _iqlNV.GetListNV().Count + 1;
                    NhanVien nv = new NhanVien();
                    nv.Ma = MaNhanVien(tbt_tennv.Text);
                    nv.Ten = tbt_tennv.Text;
                    nv.IdChucVu = _iqlCV.GetListChucVu().Where(c => c.Ten == cbb_chucvu.Text).Select(c => c.Id).FirstOrDefault();
                    nv.GioiTinh = cbb_gioitinh.Text;
                    nv.DiaChi = tbt_diachi.Text;
                    nv.NgaySinh = dtp_ngaysinh.Value;
                    nv.Email = tbt_email.Text;
                    nv.Password = tbt_password.Text;
                    nv.Sdt = tbt_sodt.Text;
                    nv.TrangThai = cbb_trangthai.Text;

                    nv.IdGuiBC = _iqlCV.GetListChucVu().Where(c => c.Ma == cbb_bc.Text).Select(c => c.Id).FirstOrDefault();
                    nv.Anh = AnhURL;
                    MessageBox.Show(_iqlNV.Add(nv));
                    ResetForm();
                }
                else
                {
                    return;
                }
            }
           
        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                AnhURL = op.FileName;
                pcb_avt.Image = Image.FromFile(op.FileName);
                pcb_avt.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        //dtg_show.Columns[0].Name = "ID";
        //    dtg_show.Columns[0].Visible = false;
        //    dtg_show.Columns[1].Name = "STT";
        //    dtg_show.Columns[2].Name = "Mã";
        //    dtg_show.Columns[3].Name = "Tên";
        //    dtg_show.Columns[4].Name = "Giới tính";
        //    dtg_show.Columns[5].Name = "Địa chỉ";
        //    dtg_show.Columns[6].Name = "Chức vụ";
        //    dtg_show.Columns[7].Name = "Ngày sinh";
        //    dtg_show.Columns[8].Name = "Trạng thái";
        //    dtg_show.Columns[9].Name = "Email";
        //    dtg_show.Columns[10].Name = "Mật khẩu";
        //    dtg_show.Columns[11].Name = "SDT";
        //    dtg_show.Columns[12].Name = "Gửi BC";
        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _iqlNV.GetListNV().Count) return;
            _getID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            nhanVien = _iqlNV.GetListNV().FirstOrDefault(c => c.Id == Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value)));
            tbt_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tbt_tennv.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            cbb_gioitinh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
            tbt_diachi.Text = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value);
            cbb_chucvu.Text = Convert.ToString(dtg_show.Rows[rd].Cells[6].Value);
            dtp_ngaysinh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[7].Value);
            cbb_trangthai.Text = Convert.ToString(dtg_show.Rows[rd].Cells[8].Value);
            tbt_email.Text = Convert.ToString(dtg_show.Rows[rd].Cells[9].Value);
            tbt_password.Text = Convert.ToString(dtg_show.Rows[rd].Cells[10].Value);
            tbt_sodt.Text = Convert.ToString(dtg_show.Rows[rd].Cells[11].Value);
            cbb_bc.Text = Convert.ToString(dtg_show.Rows[rd].Cells[12].Value);
            AnhURL = nhanVien.Anh;
            if(AnhURL != null && File.Exists(AnhURL))
            {
                pcb_avt.Image = Image.FromFile(AnhURL);
                pcb_avt.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pcb_avt.Image = null;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
           
            var checkEmail = _iqlNV.GetListNV().FirstOrDefault(p => p.Email == tbt_email.Text);
            if (tbt_email.Text.Length == 0)
            {
                MessageBox.Show("Email không được trống");
                return;
            }
            //if (checkEmail != null)
            //{
            //    MessageBox.Show("Email không trùng");
            //    return;
            //}
            if (_check.CheckEmail(tbt_email.Text))
            {
                MessageBox.Show("Email sai định dạng");
                return;
            }
            //if (checkEmail != null)
            //{
            //    MessageBox.Show("Email không trùng");
            //    return;
            //}
            if (tbt_tennv.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên");
                return;
            }
            if (tbt_tennv.Text.Length < 8)
            {
                MessageBox.Show("Tên nhân viên phải có ít nhất 8 kí tự");
                return;
            }
            if (tbt_sodt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");
                return;
            }
            if (!tbt_sodt.Text.All(char.IsNumber))
            {
                MessageBox.Show("Số điện thoại phải là số !");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if(_iqlNV.GetListNV().Any(c=>c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy");
                }
               
                else
                {
                    foreach (var x in _iqlNV.GetAll().Where(c=>c.NhanViens.Id == _getID))
                    {
                        if (nhanVien.Anh != AnhURL)
                        {
                            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                            File.Copy(AnhURL, Path.Combine(projectDirectory, "Image", "NhanVien", Path.GetFileName(AnhURL)), true);
                            AnhURL = Path.Combine(projectDirectory, "Image", "NhanVien", Path.GetFileName(AnhURL));
                        }
                        x.NhanViens.Ten = tbt_tennv.Text;
                        x.NhanViens.IdChucVu = _iqlCV.GetListChucVu().Where(c => c.Ten == cbb_chucvu.Text).Select(c => c.Id).FirstOrDefault();
                        x.NhanViens.GioiTinh = cbb_gioitinh.Text;
                        x.NhanViens.DiaChi = tbt_diachi.Text;
                        x.NhanViens.NgaySinh = dtp_ngaysinh.Value;
                        x.NhanViens.Email = tbt_email.Text;
                        x.NhanViens.Password = tbt_password.Text;
                        x.NhanViens.Sdt = tbt_sodt.Text;
                        x.NhanViens.TrangThai = cbb_trangthai.Text;

                        x.NhanViens.IdGuiBC = _iqlCV.GetListChucVu().Where(c => c.Ma == cbb_bc.Text).Select(c => c.Id).FirstOrDefault();
                        x.NhanViens.Anh = AnhURL;
                        MessageBox.Show(_iqlNV.Update(x.NhanViens));
                        ResetForm();
                    }
                   
                }

            }
            else
            {
                return;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var xoa = _iqlNV.GetListNV().Where(c => c.Id == _getID).FirstOrDefault();
            if (tbt_email.Text.Length == 0)
            {
                MessageBox.Show("Email không được trống");
                return;

            }
            if (_check.CheckEmail(tbt_email.Text))
            {
                MessageBox.Show("Email sai định dạng");
                return;
            }
            //if (checkEmail != null)
            //{
            //    MessageBox.Show("Email không trùng");
            //    return;
            //}
            if (tbt_tennv.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên");
                return;
            }
            if (tbt_tennv.Text.Length < 8)
            {
                MessageBox.Show("Tên nhân viên phải có ít nhất 8 kí tự");
                return;
            }
            if (tbt_sodt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");
                return;
            }
            if (!tbt_sodt.Text.All(char.IsNumber))
            {
                MessageBox.Show("Số điện thoại phải là số !");
                return;
            }
            if (pcb_avt.Image == null)
            {
                MessageBox.Show("Ảnh đại diện chưa có kìa bạn trẻ");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_iqlNV.GetListNV().Any(c => c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm");
                }
                else
                {
                    foreach (var x in _iqlNV.GetListNV().Where(c => c.Id == _getID))
                    {
                        MessageBox.Show(_iqlNV.Delete(xoa));
                    }
                    ResetForm();
                }
            }
        }
        void ResetForm()
        {
            LoadData();
            tbt_ma.Text = "";
            tbt_tennv.Text = "";
            cbb_gioitinh.Text = "";
            tbt_diachi.Text = "";
            cbb_chucvu.Text = "";
            dtp_ngaysinh.Text = "";
            cbb_trangthai.Text = "";
            tbt_email.Text = "";
            tbt_password.Text = "";
            tbt_sodt.Text = "";
            cbb_bc.Text = "";
            cbb_loctrangthai.Text = "";
            cbb_loccv.Text = "";
            pcb_avt.Image = null;
        }

        private void tbt_timkiem_TextChanged(object sender, EventArgs e)
        {
            if(cbb_loccv.Text != "")
            {
                if(cbb_loctrangthai.Text == "Hoạt động")
                {
                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text.ToLower()) && c.ChucVus.Ten ==  cbb_loccv.Text && c.NhanViens.TrangThai == "Hoạt động"))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                }

                     if(cbb_loctrangthai.Text == "Không hoạt động")
                     {
                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text.ToLower()) && c.ChucVus.Ten == cbb_loccv.Text && c.NhanViens.TrangThai == "Không hoạt động"))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                     }
                     if(cbb_loctrangthai.Text == "")
                     {
                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text) && c.ChucVus.Ten == cbb_loccv.Text))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                     }

            }

            if (cbb_loccv.Text == "")
            {
                if (cbb_loctrangthai.Text == "Hoạt động")
                {
                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text) && c.NhanViens.TrangThai == "Hoạt động"))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                }

                if (cbb_loctrangthai.Text == "Không hoạt động")
                {
                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text) && c.NhanViens.TrangThai == "Không hoạt động"))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                }
                if (cbb_loctrangthai.Text == "")
                {
                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text)))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                }

            }

            if(cbb_loctrangthai.Text == "Hoạt động")
            {
                if(cbb_chucvu.Text == "")
                {

                    dtg_show.ColumnCount = 13;
                    dtg_show.Rows.Clear();
                    int stt = 1;
                    dtg_show.Columns[0].Name = "ID";
                    dtg_show.Columns[0].Visible = false;
                    dtg_show.Columns[1].Name = "STT";
                    dtg_show.Columns[2].Name = "Mã";
                    dtg_show.Columns[3].Name = "Tên";
                    dtg_show.Columns[4].Name = "Giới tính";
                    dtg_show.Columns[5].Name = "Địa chỉ";
                    dtg_show.Columns[6].Name = "Chức vụ";
                    dtg_show.Columns[7].Name = "Ngày sinh";
                    dtg_show.Columns[8].Name = "Trạng thái";
                    dtg_show.Columns[9].Name = "Email";
                    dtg_show.Columns[10].Name = "Mật khẩu";
                    dtg_show.Columns[11].Name = "SDT";
                    dtg_show.Columns[12].Name = "Gửi BC";
                    foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text) && c.NhanViens.TrangThai == "Hoạt động"))
                    {
                        dtg_show.Rows.Add(x.NhanViens.Id,
                            stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                            x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                            x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                    }
                }
            }

            if(cbb_loctrangthai.Text == "Không hoạt động")
            {
                dtg_show.ColumnCount = 13;
                dtg_show.Rows.Clear();
                int stt = 1;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "STT";
                dtg_show.Columns[2].Name = "Mã";
                dtg_show.Columns[3].Name = "Tên";
                dtg_show.Columns[4].Name = "Giới tính";
                dtg_show.Columns[5].Name = "Địa chỉ";
                dtg_show.Columns[6].Name = "Chức vụ";
                dtg_show.Columns[7].Name = "Ngày sinh";
                dtg_show.Columns[8].Name = "Trạng thái";
                dtg_show.Columns[9].Name = "Email";
                dtg_show.Columns[10].Name = "Mật khẩu";
                dtg_show.Columns[11].Name = "SDT";
                dtg_show.Columns[12].Name = "Gửi BC";
                foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text) && c.NhanViens.TrangThai == "Không hoạt động"))
                {
                    dtg_show.Rows.Add(x.NhanViens.Id,
                        stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                        x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                        x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                }
            }

        }

        private void cbb_loccv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbt_timkiem.Text == "")
            {
                dtg_show.ColumnCount = 13;
                dtg_show.Rows.Clear();
                int stt = 1;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "STT";
                dtg_show.Columns[2].Name = "Mã";
                dtg_show.Columns[3].Name = "Tên";
                dtg_show.Columns[4].Name = "Giới tính";
                dtg_show.Columns[5].Name = "Địa chỉ";
                dtg_show.Columns[6].Name = "Chức vụ";
                dtg_show.Columns[7].Name = "Ngày sinh";
                dtg_show.Columns[8].Name = "Trạng thái";
                dtg_show.Columns[9].Name = "Email";
                dtg_show.Columns[10].Name = "Mật khẩu";
                dtg_show.Columns[11].Name = "SDT";
                dtg_show.Columns[12].Name = "Gửi BC";
                foreach (var x in _iqlNV.GetAll().Where(c => c.ChucVus.Ten == cbb_loccv.Text))
                {
                    dtg_show.Rows.Add(x.NhanViens.Id,
                        stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                        x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                        x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                }
            }
            if(tbt_timkiem.Text != null)
            {
                dtg_show.ColumnCount = 13;
                dtg_show.Rows.Clear();
                int stt = 1;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "STT";
                dtg_show.Columns[2].Name = "Mã";
                dtg_show.Columns[3].Name = "Tên";
                dtg_show.Columns[4].Name = "Giới tính";
                dtg_show.Columns[5].Name = "Địa chỉ";
                dtg_show.Columns[6].Name = "Chức vụ";
                dtg_show.Columns[7].Name = "Ngày sinh";
                dtg_show.Columns[8].Name = "Trạng thái";
                dtg_show.Columns[9].Name = "Email";
                dtg_show.Columns[10].Name = "Mật khẩu";
                dtg_show.Columns[11].Name = "SDT";
                dtg_show.Columns[12].Name = "Gửi BC";
                foreach (var x in _iqlNV.GetAll().Where(c => c.ChucVus.Ten == cbb_loccv.Text && c.NhanViens.Ten.ToLower()/*.ToUpper()*/.Contains(tbt_timkiem.Text)))
                {
                    dtg_show.Rows.Add(x.NhanViens.Id,
                        stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                        x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                        x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                }
            }
        }

        private void cbb_loctrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_loctrangthai.Text == "Hoạt động" )
            {
                dtg_show.ColumnCount = 13;
                dtg_show.Rows.Clear();
                int stt = 1;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "STT";
                dtg_show.Columns[2].Name = "Mã";
                dtg_show.Columns[3].Name = "Tên";
                dtg_show.Columns[4].Name = "Giới tính";
                dtg_show.Columns[5].Name = "Địa chỉ";
                dtg_show.Columns[6].Name = "Chức vụ";
                dtg_show.Columns[7].Name = "Ngày sinh";
                dtg_show.Columns[8].Name = "Trạng thái";
                dtg_show.Columns[9].Name = "Email";
                dtg_show.Columns[10].Name = "Mật khẩu";
                dtg_show.Columns[11].Name = "SDT";
                dtg_show.Columns[12].Name = "Gửi BC";
                foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.TrangThai.StartsWith("Hoạt động")))
                {
                    dtg_show.Rows.Add(x.NhanViens.Id,
                        stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                        x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                        x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                }
            }

            if (cbb_loctrangthai.Text == "Không hoạt động")
            {
                dtg_show.ColumnCount = 13;
                dtg_show.Rows.Clear();
                int stt = 1;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "STT";
                dtg_show.Columns[2].Name = "Mã";
                dtg_show.Columns[3].Name = "Tên";
                dtg_show.Columns[4].Name = "Giới tính";
                dtg_show.Columns[5].Name = "Địa chỉ";
                dtg_show.Columns[6].Name = "Chức vụ";
                dtg_show.Columns[7].Name = "Ngày sinh";
                dtg_show.Columns[8].Name = "Trạng thái";
                dtg_show.Columns[9].Name = "Email";
                dtg_show.Columns[10].Name = "Mật khẩu";
                dtg_show.Columns[11].Name = "SDT";
                dtg_show.Columns[12].Name = "Gửi BC";
                foreach (var x in _iqlNV.GetAll().Where(c => c.NhanViens.TrangThai.StartsWith("Không hoạt động")) )
                {
                    dtg_show.Rows.Add(x.NhanViens.Id,
                        stt++, x.NhanViens.Ma, x.NhanViens.Ten, x.NhanViens.GioiTinh,
                        x.NhanViens.DiaChi, x.ChucVus.Ten, x.NhanViens.NgaySinh, x.NhanViens.TrangThai,
                        x.NhanViens.Email, x.NhanViens.Password, x.NhanViens.Sdt);
                }
            }
            if(cbb_loctrangthai.Text == "Bỏ lọc")
            {

                ResetForm();
                
                
            }
        }

        private void tbt_sodt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
