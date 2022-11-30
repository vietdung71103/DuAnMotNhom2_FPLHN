using _2.BUS.IServices;
using _2.BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.ViewModels;
using _1.DAL.Models;
using System.IO;

namespace _3.PL.Views
{
    public partial class FrmQLSanPham : Form
    {
        FrmMain frm;
        IQLSachServices _iQLSach;
        IQLNXBServices _iQLNXB;
        Guid _getID;
        IQLSanPhamServices _iqSP;
        IQLTheLoaiServices _iQLTL;
        IQLTacGiaServices _iQLTG;
        SachChiTiet _sachChitiet;
        string AnhURL = "";
        public FrmQLSanPham()
        {
            InitializeComponent();
            frm = new FrmMain();
            _iQLTL = new QLTheLoaiServices();
            _iQLSach = new QLSachServices();
            _iQLNXB = new QLNXBServices();
            _iQLTG = new QLTacGiaServices();
            _iqSP = new QLSanPhamServices();
            LoadCBB();
            LoadData();
        }
        void LoadData() {
            dtg_show.ColumnCount = 12;
            dtg_show.Rows.Clear();
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã";
            dtg_show.Columns[3].Name = "Sách";
            dtg_show.Columns[4].Name = "Tác giả";
            dtg_show.Columns[5].Name = "Thể loại";
            dtg_show.Columns[6].Name = "Nhà xuất bản";
            //dtg_show.Columns[6].Name = "Ảnh";
            dtg_show.Columns[7].Name = "Mô tả";
            dtg_show.Columns[8].Name = "Giá nhập";
            dtg_show.Columns[9].Name = "Giá bán";
            dtg_show.Columns[10].Name = "Số lượng tồn";
            dtg_show.Columns[11].Name = "Số trang";
            foreach (var x in _iqSP.GetAll())
            {
                dtg_show.Rows.Add(x.SachChiTiets.Id, stt++, x.SachChiTiets.Ma, x.Sachs.Ten, x.TacGias.Ten,
                    x.TheLoais.Ten, x.NXBs.Ten/*, x.Anhs.Ten*/, x.SachChiTiets.MoTa,
                    x.SachChiTiets.GiaNhap, x.SachChiTiets.GiaBan,
                    x.SachChiTiets.SoLuongTon, x.SachChiTiets.SoTrang);
            }
        }
        void LoadCBB()
        {
            foreach (var c in _iQLSach.GetListSach())
            {
                cbb_sach.Items.Add(c.Ten);
            }
            foreach (var x in _iQLNXB.GetListNXB())
            {
                cbb_nxb.Items.Add(x.Ten);
            }
            foreach (var x in _iQLTG.GetListTacGia())
            {
                cbb_tacgia.Items.Add(x.Ten);
            }
            foreach (var x in _iQLTL.GetListTheLoai())
            {
                cbb_theloai.Items.Add(x.Ten);
            }
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
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();



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
        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLNXB(), sender);
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLTheLoai(), sender);
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLSach(), sender);
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLTacGia(), sender);
        }
        //private string VietHoaChuDau(string text)
        //{
        //    var temp = text.ToLower();
        //    return temp.Substring(0, 1).ToUpper() + temp.Substring(1, temp.Length - 1);
        //}
        //private string MaSanPham(string ten)
        //{
        //    string[] arrTen = ten.Split(' ');
        //    string ma = "SP_"; //VietHoaChuDau(arrTen[arrTen.Length - 1]);
        //    for (int i = 0; i < arrTen.Length; i++)
        //    {
        //        ma += VietHoaChuDau(arrTen[i]).Substring(0, 1);
        //    }
        //    Random rand = new Random();
        //    int z = rand.Next(1000, 9999);
        //    var so = z.ToString();
        //    return ma + so;
        //}
       
        
        /* Failed
        void MaTuSinh(string ten)
        {
            string ma = "SP";
            Random rand = new Random();
            int z = rand.Next(1000, 9999);
            var so = z.ToString();
            return ten = ma + so;
        }
        */

        //public string MoTa { get; set; }
        //public decimal GiaNhap { get; set; }
        //public decimal GiaBan { get; set; }
        //public int SoLuongTon { get; set; }
        //public int SoTrang { get; set; }
        private void btn_them_Click(object sender, EventArgs e)
        {
            //dtg_show.Columns[0].Name = "ID";
            //dtg_show.Columns[0].Visible = false;
            //dtg_show.Columns[1].Name = "STT";
            //dtg_show.Columns[2].Name = "Mã";
            //dtg_show.Columns[3].Name = "Sách";
            //dtg_show.Columns[4].Name = "Tác giả";
            //dtg_show.Columns[5].Name = "Thể loại";
            //dtg_show.Columns[6].Name = "Nhà xuất bản";
            ////dtg_show.Columns[6].Name = "Ảnh";
            //dtg_show.Columns[7].Name = "Mô tả";
            //dtg_show.Columns[8].Name = "Giá nhập";
            //dtg_show.Columns[9].Name = "Giá bán";
            //dtg_show.Columns[10].Name = "Số lượng tồn";
            //dtg_show.Columns[11].Name = "Số trang";
            var checkma = _iqSP.GetAll().Where(c => c.SachChiTiets.Ma == tbt_ma.Text);
            if (checkma != null)
            {
                MessageBox.Show("Mã không được phép trùng");
                return;
            }
            if (cbb_sach.Text == "")
            {
                MessageBox.Show("Chưa chọn sách");
                return;
            }
            if (cbb_theloai.Text == "")
            {
                MessageBox.Show("Chưa chọn thể loại");
                return;
            }
            if (cbb_nxb.Text == "")
            {
                MessageBox.Show("Chưa chọn nxb");
                return;
            }
            if (tbt_gianhap.Text == "")
            {
                MessageBox.Show("Chưa có giá nhập");
                return;
            }
            if (tbt_giaban.Text == "")
            {
                MessageBox.Show("Chưa có giá bán");
                return;
            }
            if (Convert.ToDecimal(tbt_giaban.Text) <= 0)
            {
                MessageBox.Show("Giá bán không được nhỏ hơn hoặc bằng 0");
                return;
            }
            if (Convert.ToDecimal(tbt_gianhap.Text) <= 0)
            {
                MessageBox.Show("Giá nhập không được nhỏ hơn hoặc bằng 0");
                return;
            }
            if ( Convert.ToDecimal(tbt_giaban.Text) < Convert.ToDecimal(tbt_gianhap.Text))
            {
                MessageBox.Show("Giá bán không được nhỏ hơn giá nhập");
                return;
            }
            if (tbt_sotrang.Text == "")
            {
                MessageBox.Show("Chưa nhập số trang ");
                return;
            }
            if (Convert.ToDecimal(tbt_sotrang.Text) <= 0)
            {
                MessageBox.Show("Số trang không được nhỏ hơn hoặc bằng 0");
                return;
            }
            if (tbt_slt.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng tồn ");
                return;
            }
            if (Convert.ToDecimal(tbt_slt.Text) <= 0)
            {
                MessageBox.Show("Số lượng tồn không được nhỏ hơn hoặc bằng 0");
                return;
            }
            if(pcb_avt.Image == null)
            {
                MessageBox.Show("Chưa có ảnh cho sản phẩm");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string ma = "SP";
                Random rand = new Random();
                int z = rand.Next(1000, 9999);
                var so = z.ToString(); 


                SachChiTiet sct = new SachChiTiet();
                sct.Ma = ma + so;
                sct.IdTacGia = _iQLTG.GetListTacGia().Where(c => c.Ten == cbb_tacgia.Text).Select(c => c.Id).FirstOrDefault();
                sct.IdNXB = _iQLNXB.GetListNXB().Where(c => c.Ten == cbb_nxb.Text).Select(c => c.Id).FirstOrDefault();
                sct.IdTheLoai = _iQLTL.GetListTheLoai().Where(c => c.Ten == cbb_theloai.Text).Select(c => c.Id).FirstOrDefault();
                sct.IdSach = _iQLSach.GetListSach().Where(c => c.Ten == cbb_sach.Text).Select(c => c.Id).FirstOrDefault();
                sct.MoTa = tbt_mota.Text;
                sct.GiaBan = Convert.ToDecimal(tbt_giaban.Text);
                sct.GiaNhap = Convert.ToDecimal(tbt_gianhap.Text);
                sct.SoLuongTon = Convert.ToInt32(tbt_slt.Text);
                sct.SoTrang = Convert.ToInt32(tbt_sotrang.Text);
                sct.Anh = AnhURL;
                MessageBox.Show(_iqSP.Add(sct));
                ResetForm();

                ////    MessageBox.Show(_iqSP.Add(new SachChiTiet()
                ////{
                ////    IdSach = _iQLSach.GetListSach().Where(c => c.Ten == cbb_sach.Text).Select(c => c.Id).FirstOrDefault(),
                ////    IdNXB = _iQLNXB.GetListNXB().Where(c => c.Ten == cbb_nxb.Text).Select(c => c.Id).FirstOrDefault(),
                ////    IdTacGia = _iQLTG.GetListTacGia().Where(c => c.Ten == cbb_tacgia.Text).Select(c => c.Id).FirstOrDefault(),
                ////    IdTheLoai = _iQLSach.GetListSach().Where(c => c.Ten == cbb_theloai.Text).Select(c => c.Id).FirstOrDefault(),
                ////    MoTa = tbt_mota.Text,
                ////    GiaNhap = Convert.ToDecimal(tbt_gianhap.Text),
                ////    GiaBan = Convert.ToDecimal(tbt_giaban.Text),
                ////    SoLuongTon = Convert.ToInt32(tbt_slt.Text),
                ////    SoTrang = Convert.ToInt32(tbt_sotrang.Text)
                //}));
                //}
            }
            else
            {
                return;
            }
        }
        void ResetForm()
        {
            LoadData();
            tbt_ma.Text = "";
            cbb_tacgia.Text = "";
            cbb_theloai.Text = "";
            cbb_nxb.Text = "";
            tbt_mota.Text = "";
            tbt_gianhap.Text = "";
            tbt_giaban.Text = "";
            tbt_slt.Text = "";
            tbt_sotrang.Text = "";
            pcb_avt.Image = null;
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_iqSP.GetListSachChiTiet().Any(c => c.Id == _getID) == false) MessageBox.Show("Không tìm thấy");
                
                else
                {
                    
                    foreach (var x in _iqSP.GetListSachChiTiet().Where(c=>c.Id == _getID))
                    {
                        if (AnhURL != _sachChitiet.Anh)
                        {
                            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                            File.Copy(AnhURL, Path.Combine(projectDirectory, "Image", "SanPham", Path.GetFileName(AnhURL)), true);
                            AnhURL = Path.Combine(projectDirectory, "Image", "SanPham", Path.GetFileName(AnhURL));
                        }
                        x.IdTacGia = _iQLTG.GetListTacGia().Where(c => c.Ten == cbb_tacgia.Text).Select(c => c.Id).FirstOrDefault();
                        x.IdNXB = _iQLNXB.GetListNXB().Where(c => c.Ten == cbb_nxb.Text).Select(c => c.Id).FirstOrDefault();
                        x.IdTheLoai = _iQLTL.GetListTheLoai().Where(c => c.Ten == cbb_theloai.Text).Select(c => c.Id).FirstOrDefault();
                        x.IdSach = _iQLSach.GetListSach().Where(c => c.Ten == cbb_sach.Text).Select(c => c.Id).FirstOrDefault();
                        x.MoTa = tbt_mota.Text;
                        x.GiaBan = Convert.ToDecimal(tbt_giaban.Text);
                        x.GiaNhap = Convert.ToDecimal(tbt_gianhap.Text);
                        x.SoLuongTon = Convert.ToInt32(tbt_slt.Text);
                        x.SoTrang = Convert.ToInt32(tbt_sotrang.Text);
                        x.Anh = AnhURL;
                        MessageBox.Show(_iqSP.Update(x));
                        ResetForm();
                    }
                    //foreach (var x in _iqSP.GetAll().Where(c => c.SachChiTiets.Id == _getID))
                    //{
                    //    x.SachChiTiets.IdTacGia = _iQLTG.GetListTacGia().Where(c => c.Ten == cbb_tacgia.Text).Select(c => c.Id).FirstOrDefault();
                    //    x.SachChiTiets.IdNXB = _iQLNXB.GetListNXB().Where(c => c.Ten == cbb_nxb.Text).Select(c => c.Id).FirstOrDefault();
                    //    x.SachChiTiets.IdTheLoai = _iQLTL.GetListTheLoai().Where(c => c.Ten == cbb_theloai.Text).Select(c => c.Id).FirstOrDefault();
                    //    x.SachChiTiets.IdSach = _iQLSach.GetListSach().Where(c => c.Ten == cbb_sach.Text).Select(c => c.Id).FirstOrDefault();
                    //    x.SachChiTiets.MoTa = tbt_mota.Text;
                    //    x.SachChiTiets.GiaBan = Convert.ToDecimal(tbt_giaban.Text);
                    //    x.SachChiTiets.GiaNhap = Convert.ToDecimal(tbt_gianhap.Text);
                    //    x.SachChiTiets.SoLuongTon = Convert.ToInt32(tbt_slt.Text);
                    //    x.SachChiTiets.SoTrang = Convert.ToInt32(tbt_sotrang.Text);
                    //    x.SachChiTiets.Anh = AnhURL;
                    //    MessageBox.Show(_iqSP.Update(x.SachChiTiets));
                    //}
                }
            }
            else
            {
                return;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var xoa = _iqSP.GetListSachChiTiet().Where(c => c.Id == _getID).FirstOrDefault();
                 DialogResult result = MessageBox.Show("Bạn có muốn xoá?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                if(_iqSP.GetListSachChiTiet().Any(c=>c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm");
                }
                else
                {
                    foreach (var x in _iqSP.GetListSachChiTiet().Where(c=>c.Id == _getID))
                    {
                        MessageBox.Show(_iqSP.Delete(xoa));
                    }
                    ResetForm();
                }
            }
            }
        //dtg_show.Columns[1].Name = "STT";
        //    dtg_show.Columns[2].Name = "Sách";
        //    dtg_show.Columns[3].Name = "Tác giả";
        //    dtg_show.Columns[4].Name = "Thể loại";
        //    dtg_show.Columns[5].Name = "Nhà xuất bản";
        //    //dtg_show.Columns[6].Name = "Ảnh";
        //    dtg_show.Columns[6].Name = "Mô tả";
        //    dtg_show.Columns[7].Name = "Giá nhập";
        //    dtg_show.Columns[8].Name = "Giá bán";
        //    dtg_show.Columns[9].Name = "Số lượng tồn";
        //    dtg_show.Columns[10].Name = "Số trang";
        //dtg_show.Columns[0].Name = "ID";
        //    dtg_show.Columns[0].Visible = false;
        //    dtg_show.Columns[1].Name = "STT";
        //    dtg_show.Columns[2].Name = "Mã";
        //    dtg_show.Columns[3].Name = "Sách";
        //    dtg_show.Columns[4].Name = "Tác giả";
        //    dtg_show.Columns[5].Name = "Thể loại";
        //    dtg_show.Columns[6].Name = "Nhà xuất bản";
        //    //dtg_show.Columns[6].Name = "Ảnh";
        //    dtg_show.Columns[7].Name = "Mô tả";
        //    dtg_show.Columns[8].Name = "Giá nhập";
        //    dtg_show.Columns[9].Name = "Giá bán";
        //    dtg_show.Columns[10].Name = "Số lượng tồn";
        //    dtg_show.Columns[11].Name = "Số trang";
        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            _sachChitiet = _iqSP.GetListSachChiTiet().FirstOrDefault(c => c.Id == Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value)));
            if (rd ==-1 || rd>= _iqSP.GetListSachChiTiet().Count) return;
            _getID = _sachChitiet.Id;
            tbt_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            cbb_sach.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            cbb_tacgia.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
            cbb_theloai.Text = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value);
            cbb_nxb.Text = Convert.ToString(dtg_show.Rows[rd].Cells[6].Value);
            tbt_mota.Text = Convert.ToString(dtg_show.Rows[rd].Cells[7].Value);
            tbt_gianhap.Text = Convert.ToString(dtg_show.Rows[rd].Cells[8].Value);
            tbt_giaban.Text = Convert.ToString(dtg_show.Rows[rd].Cells[9].Value);
            tbt_slt.Text = Convert.ToString(dtg_show.Rows[rd].Cells[10].Value);
            tbt_sotrang.Text = Convert.ToString(dtg_show.Rows[rd].Cells[11].Value);
            AnhURL = _sachChitiet.Anh;
            if (AnhURL != null && File.Exists(AnhURL))
            {
                pcb_avt.Image = Image.FromFile(AnhURL);
                pcb_avt.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pcb_avt.Image = null;
            }

        }


        private void tbt_timkiem_TextChanged(object sender, EventArgs e)
        {
            dtg_show.ColumnCount = 12;
            dtg_show.Rows.Clear();
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã";
            dtg_show.Columns[3].Name = "Sách";
            dtg_show.Columns[4].Name = "Tác giả";
            dtg_show.Columns[5].Name = "Thể loại";
            dtg_show.Columns[6].Name = "Nhà xuất bản";
            //dtg_show.Columns[6].Name = "Ảnh";
            dtg_show.Columns[7].Name = "Mô tả";
            dtg_show.Columns[8].Name = "Giá nhập";
            dtg_show.Columns[9].Name = "Giá bán";
            dtg_show.Columns[10].Name = "Số lượng tồn";
            dtg_show.Columns[11].Name = "Số trang";
            foreach (var x in _iqSP.GetAll().Where(c=>c.SachChiTiets.Ma.ToLower().Contains(tbt_timkiem.Text)))
            {
                dtg_show.Rows.Add(x.SachChiTiets.Id, stt++, x.SachChiTiets.Ma, x.Sachs.Ten, x.TacGias.Ten,
                    x.TheLoais.Ten, x.NXBs.Ten/*, x.Anhs.Ten*/, x.SachChiTiets.MoTa,
                    x.SachChiTiets.GiaNhap, x.SachChiTiets.GiaBan,
                    x.SachChiTiets.SoLuongTon, x.SachChiTiets.SoTrang);
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

        private void tbt_slt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_sotrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_gianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_giaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbt_giaban_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbb_locnxb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_loctl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_loctg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_loc_Click(object sender, EventArgs e)
        {

        }


        //private SanPhamView AddSanPham()
        //{
        //    SanPhamView spv = new SanPhamView();
        //    spv.ChiTietSp = new ChiTietSp()
        //    {

        //        IdSp = _qlSPPServices.GetListSanPham().Where(c => c.SanPham.Ten == cbb_sp.Text).Select(c => c.SanPham.Id).FirstOrDefault(),
        //        IdDongSp = _qlDSPServices.GetListDSP().Where(c => c.DongSP.Ten == cbb_dsp.Text).Select(c => c.DongSP.Id).FirstOrDefault(),
        //        IdMauSac = _qlMSServices.GetListMauSac().Where(c => c.MauSac.Ten == cbb_ms.Text).Select(c => c.MauSac.Id).FirstOrDefault(),
        //        IdNsx = _qlNSXServices.GetListNSX().Where(c => c.NSX.Ten == cbb_nsx.Text).Select(c => c.NSX.Id).FirstOrDefault(),

        //        NamBh = Convert.ToInt32(tbt_nambh.Text),
        //        MoTa = tbt_mota.Text,
        //        SoLuongTon = Convert.ToInt32(tbt_slt.Text),
        //        GiaBan = Convert.ToDecimal(tbt_giaban.Text),
        //        GiaNhap = Convert.ToDecimal(tbt_gianhap.Text)
        //    };//Gán các control từ giao diện vào chỗ này

        //    //spv.MauSac = đối tượng mầu sắc trên control mà tìm được
        //    return spv;
        //}

    }
}
