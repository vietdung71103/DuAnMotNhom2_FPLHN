using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Forms;
using ZXing;




namespace _3.PL.Views
{
    public partial class FrmQLBanHang : Form
    {
        IQLHoaDonChiTietServices _iqlHDCT;
        IQLHoaDonServices _iqlHD;
        IQLSanPhamServices _iqlSP;
        IQLNhanVienServices _iqlNV;
        IQLKhachHangServices _iqlKH;
        Guid _idSP;
        Guid _idKH;
        Guid _idNV;
        Guid _idHD;
        
        HoaDonChiTiet _giohang;
        public KhachHang _khachHang;
        List<ViewHoaDonChiTiet> _lstVHDCT;
        List<ViewHoaDon> _lstVHD;
        FilterInfoCollection _filterInfoCollection;
        VideoCaptureDevice _captureDevice;
        public FrmQLBanHang()
        {
            InitializeComponent();
            _iqlHDCT = new QLHoaDonChiTietServices();
            _iqlHD = new QLHoaDonServices();
            _iqlKH = new QLKhachHangServices();
            _iqlNV = new QLNhanVienServices();
            _iqlSP = new QLSanPhamServices();
            _khachHang = new KhachHang();
            _giohang = new HoaDonChiTiet();
            _lstVHD = new List<ViewHoaDon>();
          
            _lstVHDCT = new List<ViewHoaDonChiTiet>();
            var nv = _iqlNV.GetListNV().FirstOrDefault(c=>c.Email == Properties.Settings1.Default.userlogined);
            lb_mnv.Text = nv.Ma;
            lb_tennvbanhang.Text = nv.Ten;
            foreach (var x in _iqlKH.GetListKhachHang())
            {
                cbb_khachhang.Items.Add(x.Ma);
            }
            LoadSanPham();
            LoadHDCho();
          
        }
        //
        //public Guid Id { get; set; }
        //public Guid IdKhachHang { get; set; }
        //public Guid IdNhanVien { get; set; }
        //public string MaHoaDon { get; set; }
        //public DateTime NgayTao { get; set; }
        //public string TrangThai { get; set; }
        //public decimal DonGia { get; set; }
        private void btn_taohoadon_Click(object sender, EventArgs e)
        {
            int mahd = _iqlHD.GetListHoaDon().Count + 1;
            DialogResult result = MessageBox.Show("Bạn có muốn tạo hoá đơn ?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes){
                if(_lstVHDCT.Any())
                {
                    decimal tong = 0;
                    foreach (var x in _lstVHDCT)
                    {
                        tong += x.GiaBan * x.SoLuong;
                    }
                    _idNV = _iqlNV.GetListNV().FirstOrDefault(c => c.Email == Properties.Settings1.Default.userlogined).Id;
                    _khachHang = _iqlKH.GetListKhachHang().FirstOrDefault(c => c.Ma == cbb_khachhang.Text);
                    if(_khachHang != null)
                    {
                        HoaDon hd =new HoaDon();
                        //hd.Id = Guid.NewGuid();
                        hd.IdKhachHang = _khachHang.Id;
                        hd.IdNhanVien = _idNV;
                        hd.MaHoaDon = "HD0" + mahd;
                        hd.NgayTao = DateTime.Now;
                        hd.DonGia =tong;
                        hd.TrangThai = "Chưa thanh toán";
                        hd.GhiChu = "";
                        _iqlHD.Add(hd);
                        foreach (var x in _lstVHDCT)
                        {
                            HoaDonChiTiet hdct = new HoaDonChiTiet();
                          //  hdct.Id = Guid.NewGuid();
                            hdct.IdHoaDon = hd.Id;
                            hdct.IdSachChiTiet = x.IdSachChiTiet;
                            hdct.SoLuong = x.SoLuong;
                            hdct.GiaBan = x.GiaBan;
                            _iqlHDCT.AddHDCT(hdct);
                            var sp = _iqlSP.GetAll().Where(c=>c.SachChiTiets.Id == x.IdSachChiTiet);
                            foreach (var c in sp)
                            {
                                c.SachChiTiets.SoLuongTon -= x.SoLuong;
                                _iqlSP.Update(c.SachChiTiets);
                            }
                            
                        }
                        tbt_mahd.Text = hd.MaHoaDon.ToString();
                        lb_tongtien.Text = lb_total.Text;
                        cbb_khachhang.Text = "";
                        lb_total.Text = "";
                        MessageBox.Show("Tạo thành công hoá đơn: " + tbt_mahd.Text);
                        LoadSanPham();
                        LoadHDCho();
                        _lstVHDCT = new List<ViewHoaDonChiTiet>();
                        dtg_giohang.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Mời chọn khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa có sản phẩm trong giỏ hàng");
                }
            }
         
            //     public Guid Id { get; set; }
            //public Guid IdHoaDon { get; set; }
            //public Guid IdSachChiTiet { get; set; }
            //public int SoLuong { get; set; }
            //public decimal GiaBan { get; set; }
            //public virtual HoaDon? HoaDon { get; set; }
            //public virtual SachChiTiet? SachChiTiet { get; set; }
        }
        
        //
        // Lát copy lại sau
        void LoadSanPham()
            {
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn = new DataGridViewButtonColumn();
            //btn.Text = "Xem";
            //btn.Name = "Xem";
            //btn.HeaderText = "";

                dtg_sp.ColumnCount = 12;
                dtg_sp.Rows.Clear();
                int stt = 1;
                dtg_sp.Columns[0].Name = "ID";
               dtg_sp.Columns[0].Visible = false;
                dtg_sp.Columns[1].Name = "STT";
                dtg_sp.Columns[2].Name = "Mã";
                dtg_sp.Columns[3].Name = "Sách";
                dtg_sp.Columns[4].Name = "Tác giả";
                dtg_sp.Columns[5].Name = "Thể loại";
                dtg_sp.Columns[6].Name = "Nhà xuất bản";
                //dtg_show.Columns[6].Name = "Ảnh";
                dtg_sp.Columns[7].Name = "Mô tả";
                dtg_sp.Columns[8].Name = "Giá nhập";
                dtg_sp.Columns[8].Visible = false;
                dtg_sp.Columns[9].Name = "Giá bán";
                dtg_sp.Columns[10].Name = "Số lượng tồn";
                dtg_sp.Columns[11].Name = "Số trang";
                dtg_sp.Columns[11].Visible = false;
               //  dtg_sp.Columns.Add(btn);
                
            foreach (var x in _iqlSP.GetAll())
                {
                    dtg_sp.Rows.Add(x.SachChiTiets.Id, stt++, x.SachChiTiets.Ma, x.Sachs.Ten, x.TacGias.Ten,
                        x.TheLoais.Ten, x.NXBs.Ten/*, x.Anhs.Ten*/, x.SachChiTiets.MoTa,
                        x.SachChiTiets.GiaNhap, x.SachChiTiets.GiaBan,
                        x.SachChiTiets.SoLuongTon/*, x.SachChiTiets.SoTrang,btn.Text = ("Xem")*/);
                }
            }
            //         public Guid Id { get; set; }
            //public Guid IdHoaDon { get; set; }
            //public Guid IdSachChiTiet { get; set; }
            //public string MaSach { get; set; }
            //public string TenSach { get; set; }
            //public int SoLuong { get; set; }
            //public decimal GiaBan { get; set; }
            void LoadGioHang()
            {
                dtg_giohang.ColumnCount = 7;
                dtg_giohang.Columns[0].Name = "";
                int stt = 1;
                dtg_giohang.Rows.Clear();
                dtg_giohang.Columns[0].Visible = false;
                dtg_giohang.Columns[1].Name = "STT";
                dtg_giohang.Columns[2].Name = "Mã sách";
                dtg_giohang.Columns[3].Name = "Tên sách";
                dtg_giohang.Columns[4].Name = "Số lượng";
                dtg_giohang.Columns[5].Name = "Giá bán";
                dtg_giohang.Columns[6].Name = "IDSP";
                dtg_giohang.Columns[6].Visible = false;
                foreach (var x in _lstVHDCT)
                {
                    dtg_giohang.Rows.Add(x.Id, stt++, x.MaSach, x.TenSach, x.SoLuong, x.GiaBan,x.IdSachChiTiet);
                }
            TongGioHang();
        }
        //public Guid IdHoaDon { get; set; }
        //public Guid IdSachChiTiet { get; set; }
        //public string MaSach { get; set; }
        //public string TenSach { get; set; }
        //public int SoLuong { get; set; }
        //public decimal GiaBan { get; set; }
        public void ThemVaoGioHang(Guid idSP)
        {
            var sp = _iqlSP.GetAll().Where(c=>c.SachChiTiets.Id == idSP).FirstOrDefault();
            var data = _lstVHDCT.Where(c => c.IdSachChiTiet == sp.SachChiTiets.Id).FirstOrDefault();
            if (data == null)
            {
                ViewHoaDonChiTiet _hdct = new ViewHoaDonChiTiet();
                _hdct.Id = _giohang.Id;
                _hdct.IdSachChiTiet = idSP;
                _hdct.MaSach = sp.Sachs.Ma;
                _hdct.TenSach = sp.Sachs.Ten;
                _hdct.SoLuong = 1;
                _hdct.GiaBan = sp.SachChiTiets.GiaBan;
                _lstVHDCT.Add(_hdct);
            }
            else
            {
                if(data.SoLuong == sp.SachChiTiets.SoLuongTon)
                {
                    MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép");
                }
                else
                {
                    data.SoLuong++;
                }
            }
            LoadGioHang();
        }

        private void dtg_sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _iqlSP.GetListSachChiTiet().Count) return;
           
                if (Guid.Parse(dtg_sp.Rows[rd].Cells[0].Value.ToString()) == null)
                {
                    MessageBox.Show("Không tồn tại sản phẩm");
                    return;
                }
                else
                {
                    _idSP = _iqlSP.GetAll().FirstOrDefault(c => c.SachChiTiets.Id == Guid.Parse(dtg_sp.Rows[rd].Cells[0].Value.ToString())).SachChiTiets.Id;
                    ThemVaoGioHang(_idSP);
                }
              
              
            
        }
        public void TongGioHang()
        {
            if(_lstVHDCT != null)
            {
                decimal total = 0;
                foreach (var x in _lstVHDCT)
                {
                    total += Convert.ToDecimal(x.GiaBan) * Convert.ToDecimal (x.SoLuong);
                }
                lb_total.Text = total.ToString();
             
            }
        }
        private void dtg_giohang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_giohang.Rows[e.RowIndex];
                if (int.TryParse(dtg_giohang.Rows[r.Index].Cells[4].Value.ToString(), out int x))
                {
                    if (dtg_giohang.Rows[r.Index].Cells[4].Value != _lstVHDCT[r.Index].SoLuong.ToString())
                    {
                        if (Convert.ToInt32(dtg_giohang.Rows[r.Index].Cells[4].Value) <= 0)
                        {
                            MessageBox.Show("Nhập sai số lượng");
                            dtg_giohang.Rows[r.Index].Cells[4].Value = _lstVHDCT[r.Index].SoLuong;
                        }
                        else
                        {
                            var p = _iqlSP.GetListSachChiTiet().FirstOrDefault(x => x.Id == _lstVHDCT[r.Index].IdSachChiTiet);
                            if (p.SoLuongTon < Convert.ToInt32(dtg_giohang.Rows[r.Index].Cells[4].Value))
                            {
                                MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép");
                                dtg_giohang.Rows[r.Index].Cells[4].Value = _lstVHDCT[r.Index].SoLuong;
                            }
                            else
                            {
                                _lstVHDCT[r.Index].SoLuong = Convert.ToInt32(dtg_giohang.Rows[r.Index].Cells[4].Value);
                                TongGioHang();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai số lượng");
                    dtg_giohang.Rows[r.Index].Cells[3].Value = _lstVHDCT[r.Index].SoLuong;
                }
            }
        }

        private void dtg_giohang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_giohang.Rows[e.RowIndex];
                _idSP = Guid.Parse(r.Cells[6].Value.ToString());


            }
        }
        public void LoadTienThua()
        {
            if(!(tbt_tienkhachdua.Text == ""))
            {
                lb_tienthua.Text = (Convert.ToDecimal(tbt_tienkhachdua.Text) - Convert.ToDecimal(lb_total.Text)).ToString();
            }
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if(tbt_mahd.Text != "" )
            {
                HoaDon hd = _iqlHD.GetListHoaDon().FirstOrDefault(c => c.MaHoaDon == tbt_mahd.Text && c.TrangThai == "Chưa thanh toán");
                if(hd == null)
                {
                    MessageBox.Show("Đơn hàng không tồn tại hoặc đã thanh toán");
                    lb_tongtien.Text = "0";
                }
                else
                {
                    if(tbt_tienkhachdua.Text == "" )
                    {
                        MessageBox.Show("Nhập tiền khách đưa");
                        return;
                    }
                   
                    if ( Convert.ToDecimal(tbt_tienkhachdua.Text) < Convert.ToDecimal(lb_total.Text))
                    {
                        MessageBox.Show("Khách đưa không đủ tiền");
                        return;
                    }
                   
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thanh toán không?", "Thanh toán", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (var x in _iqlHD.GetListHoaDon().Where(c => c.Id == _idHD && c.MaHoaDon == tbt_mahd.Text && c.TrangThai == "Chưa thanh toán"))
                        {
                            x.TrangThai = "Đã thanh toán";
                            x.GhiChu = tbt_ghichu.Text;
                            _iqlHD.Update(x);
                            MessageBox.Show("Thanh toán thành công");
                            LoadHDCho();
                            LoadSanPham();
                            LoadGioHang();
                            
                        }
                        tbt_mahd.Text = "";
                        tbt_tienkhachdua.Text = "";
                        lb_tongtien.Text = "0";
                        lb_tienthua.Text = "0";
                        tbt_ghichu.Text = "";

                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời nhập mã hoá đơn");
            }
        }

        private void tbt_tienkhachdua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbb_khachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kh = _iqlKH.GetListKhachHang().Where(c => c.Ma == cbb_khachhang.Text).FirstOrDefault();
            foreach (var x in _iqlKH.GetListKhachHang().Where(c=>c.Ma == cbb_khachhang.Text))
            {
                lb_tenkh.Text = kh.Ten;
                lb_sdt.Text = kh.Sdt;
                
            }
        }

        private void tbt_xoasp_Click(object sender, EventArgs e)
        {
            if(_lstVHDCT.Any())
            {
                var x = _lstVHDCT.Where(c => c.IdSachChiTiet == _idSP).FirstOrDefault();
                _lstVHDCT.Remove(x);
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }
        
        private void tbt_xoagiohang_Click(object sender, EventArgs e)
        {
            if (_lstVHDCT.Any())
            {
                _lstVHDCT = new List<ViewHoaDonChiTiet>();
                LoadGioHang();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }

        private void dtg_donhangcho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_donhangcho.Rows[e.RowIndex];
                _idHD = Guid.Parse(Convert.ToString(r.Cells[0].Value));

                tbt_mahd.Text = Convert.ToString(r.Cells[2].Value);
                var hdct = _iqlHDCT.GetListHoaDonCT().Where(c => c.IdHoaDon == _idHD);
                var hd = _iqlHD.GetListHoaDon().FirstOrDefault(c => c.Id == _idHD).IdKhachHang;
                var kh = _iqlKH.GetListKhachHang().FirstOrDefault(c => c.Id == hd);
                cbb_khachhang.Text = kh.Ma;
                _lstVHDCT = new List<ViewHoaDonChiTiet>();
                foreach (var x in hdct)
                {
                    var sp = _iqlSP.GetAll().FirstOrDefault(c => c.SachChiTiets.Id == x.IdSachChiTiet);
                    
                    ViewHoaDonChiTiet vhdct = new ViewHoaDonChiTiet();
                    vhdct.IdHoaDon = x.IdHoaDon;
                    vhdct.IdSachChiTiet = sp.SachChiTiets.Id;
                    vhdct.MaSach = sp.SachChiTiets.Ma;
                    vhdct.TenSach = sp.Sachs.Ten;
                    vhdct.SoLuong = hdct.FirstOrDefault(c => c.IdSachChiTiet == sp.SachChiTiets.Id).SoLuong;
                    vhdct.GiaBan = sp.SachChiTiets.GiaBan;
                    _lstVHDCT.Add(vhdct);
                    LoadGioHang();
                }
                lb_tongtien.Text = lb_total.Text;
              
            }
            //     public Guid Id { get; set; }
            //public Guid IdHoaDon { get; set; }
            //public Guid IdSachChiTiet { get; set; }
            //public string MaSach { get; set; }
            //public string TenSach { get; set; }
            //public int SoLuong { get; set; }
            //public decimal GiaBan { get; set; }
        
    
}
        
        void LoadHDCho()
        {
            dtg_donhangcho.Rows.Clear();
            var hdcho = (from an in _iqlHD.GetListHoaDon()
                         join b in _iqlKH.GetListKhachHang() on an.IdKhachHang equals b.Id
                         join c in _iqlNV.GetListNV() on an.IdNhanVien equals c.Id
                         select new { an, b, c });
            dtg_donhangcho.ColumnCount = 4;
            int stt = 1;
            dtg_donhangcho.Columns[0].Name = "";
            dtg_donhangcho.Columns[1].Name = "STT";
            dtg_donhangcho.Columns[2].Name = "Mã hoá đơn";
            dtg_donhangcho.Columns[3].Name = "Tên khách hàng";
            dtg_donhangcho.Columns[0].Visible = false;
            foreach (var x in hdcho.Where(c=>c.an.TrangThai.Contains("Chưa thanh toán")))
            {
                dtg_donhangcho.Rows.Add(x.an.Id, stt++, x.an.MaHoaDon, x.b.Ten);
            }
        }

        private void tbt_tienkhachdua_TextChanged(object sender, EventArgs e)
        {
            LoadTienThua();

        }

        private void tbt_timkiemsp_TextChanged(object sender, EventArgs e)
        {
            dtg_sp.ColumnCount = 12;
            dtg_sp.Rows.Clear();
            int stt = 1;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Oke";
            btn.Name = "Xem";
            btn.HeaderText = "Xem chi tiết sản phẩm";
            dtg_sp.Columns[0].Name = "ID";
            dtg_sp.Columns[0].Visible = false;
            dtg_sp.Columns[1].Name = "STT";
            dtg_sp.Columns[2].Name = "Mã";
            dtg_sp.Columns[3].Name = "Sách";
            dtg_sp.Columns[4].Name = "Tác giả";
            dtg_sp.Columns[5].Name = "Thể loại";
            dtg_sp.Columns[6].Name = "Nhà xuất bản";
            //dtg_show.Columns[6].Name = "Ảnh";
            dtg_sp.Columns[7].Name = "Mô tả";
            dtg_sp.Columns[8].Name = "Giá nhập";
            dtg_sp.Columns[8].Visible = false;
            dtg_sp.Columns[9].Name = "Giá bán";
            dtg_sp.Columns[10].Name = "Số lượng tồn";
            dtg_sp.Columns[11].Name = "Số trang";
            dtg_sp.Columns[11].Visible = false;
            dtg_sp.Columns.Add(btn);
            foreach (var x in _iqlSP.GetAll().Where(c=>c.SachChiTiets.Ma.Contains(tbt_timkiemsp.Text)))
            {
                dtg_sp.Rows.Add(x.SachChiTiets.Id, stt++, x.SachChiTiets.Ma, x.Sachs.Ten, x.TacGias.Ten,
                    x.TheLoais.Ten, x.NXBs.Ten/*, x.Anhs.Ten*/, x.SachChiTiets.MoTa,
                    x.SachChiTiets.GiaNhap, x.SachChiTiets.GiaBan,
                    x.SachChiTiets.SoLuongTon, x.SachChiTiets.SoTrang);
            }
        }

        private void FrmQLBanHang_Load(object sender, EventArgs e)
        {
            _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in _filterInfoCollection)
            {
                cbb_camera.Items.Add(filterInfo.Name);
                cbb_camera.SelectedIndex = 0;
            }
        }

        private void btn_quetma_Click(object sender, EventArgs e)
        {
            _captureDevice = new VideoCaptureDevice(_filterInfoCollection[cbb_camera.SelectedIndex].MonikerString);
            _captureDevice.NewFrame += CaptureDevice_NewFrame;
            _captureDevice.Start();
            timer1.Start();

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pcb_qr.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void FrmQLBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {

            //if (_captureDevice.IsRunning)
            //{
            // // _captureDevice.Stop();
               
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pcb_qr.Image != null)
            {
                BarcodeReader barcodeReader = new ZXing.BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pcb_qr.Image);
                if (result !=null)
                {
                    tbt_qr.Text = result.ToString();
                    if (_captureDevice.IsRunning)
                    {
                      //  _captureDevice.Stop();
                    }
                }
            }
        }
        
        private void tbt_qr_TextChanged(object sender, EventArgs e)
        {
            var sp = _iqlSP.GetAll().FirstOrDefault(c => Convert.ToString(c.SachChiTiets.Id) ==tbt_qr.Text);
            if(sp == null)
            {
                //MessageBox.Show("QR không tồn tại");
            }
            else
            {
                var data = _lstVHDCT.FirstOrDefault(c => c.IdSachChiTiet == sp.SachChiTiets.Id);
                if(data == null)
                {
                    ViewHoaDonChiTiet _hdct = new ViewHoaDonChiTiet();
                    _hdct.Id = _giohang.Id;
                    _hdct.IdSachChiTiet = sp.SachChiTiets.Id;
                    _hdct.MaSach = sp.Sachs.Ma;
                    _hdct.TenSach = sp.Sachs.Ten;
                    _hdct.SoLuong = 1;
                    _hdct.GiaBan = sp.SachChiTiets.GiaBan;
                    _lstVHDCT.Add(_hdct);
                }
                
                 else
                {
                    if (data.SoLuong == sp.SachChiTiets.SoLuongTon)
                    {
                        MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép");
                    }
                    else
                    {
                        data.SoLuong++;
                    }
                }
                LoadGioHang();
                tbt_qr.Text = "";
            }
        }
    }


}
