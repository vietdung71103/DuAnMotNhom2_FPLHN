using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
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
    public partial class FrmHoaDon : Form
    {
        IQLHoaDonServices _iqlHD;
        IQLHoaDonChiTietServices _iqHDCT;
        IQLSanPhamServices _iqlSP;
        Guid _idHD;
        KhachHang _kh;
        NhanVien _nv;
        IQLNhanVienServices _iqlNV;
        IQLKhachHangServices _iqlKH;
        List<ViewHoaDon> lstVHD;
        List<ViewHoaDonChiTiet> lstVHDCT;
        public FrmHoaDon()
        {
            InitializeComponent();
            _iqHDCT = new QLHoaDonChiTietServices();
            _iqlHD = new QLHoaDonServices();
            _iqlSP = new QLSanPhamServices();
            LoadHoaDon();
            _iqlNV = new QLNhanVienServices();
            _iqlKH = new QLKhachHangServices();
            _kh = new KhachHang();
            _nv = new NhanVien();
            lstVHD = new List<ViewHoaDon>();
            lstVHDCT = new List<ViewHoaDonChiTiet>();
            cbb_loc.Items.Add("Đã thanh toán");
            cbb_loc.Items.Add("Chưa thanh toán");
        }
        //public Guid Id { get; set; }
        //public Guid IdKhachHang { get; set; }
        //public Guid IdNhanVien { get; set; }
        //public string MaHoaDon { get; set; }
        //public DateTime NgayTao { get; set; }
        //public string TrangThai { get; set; }
        //public string GhiChu { get; set; }
        //public decimal DonGia { get; set; }
        void LoadHoaDon()
        {
            dtg_hd.ColumnCount = 9;
            int stt = 1;
            dtg_hd.Rows.Clear();
            dtg_hdct.Rows.Clear();
            dtg_hd.Columns[0].Name = "";
            dtg_hd.Columns[0].Visible = false;
            dtg_hd.Columns[1].Name = "STT";
            dtg_hd.Columns[2].Name =  "Mã hoá đơn";
            dtg_hd.Columns[3].Name = "Nhân viên bán hàng";
            dtg_hd.Columns[4].Name = "Khách hàng";
            dtg_hd.Columns[5].Name = "Ngày tạo";
            dtg_hd.Columns[6].Name = "Ghi chú";
            dtg_hd.Columns[7].Name = "Tổng tiền";
            dtg_hd.Columns[8].Name = "Trạng thái";
           // lstVHD = _iqlHD.GetListViewHoaDon();
            foreach (var x in _iqlHD.GetHD()/*.Where(c=>c.Id == _idHD)*/)
            {
               
                dtg_hd.Rows.Add(x.HoaDons.Id, stt++, x.HoaDons.MaHoaDon, x.NhanViens.Ten,x.KhachHangs.Ten, x.HoaDons.NgayTao, x.HoaDons.GhiChu,x.HoaDons.DonGia, x.HoaDons.TrangThai);
            }
        }
        //public Guid Id { get; set; }
        //public Guid IdHoaDon { get; set; }
        //public Guid IdSachChiTiet { get; set; }
        //public string MaSach { get; set; }
        //public string TenSach { get; set; }
        //public int SoLuong { get; set; }
        //public decimal GiaBan { get; set; }
        void LoadHDCT(Guid _IDHD)
        {
            _idHD = _IDHD;
            dtg_hdct.ColumnCount = 8;
            int stt = 1;
            dtg_hdct.Columns[0].Name = "";
            dtg_hdct.Columns[0].Visible = false;
            dtg_hdct.Columns[1].Name = "STT";
            dtg_hdct.Columns[1].Visible = false;
            dtg_hdct.Columns[2].Name = "IDHD";
            dtg_hdct.Columns[2].Visible = false;
            dtg_hdct.Columns[3].Name = "IDSach";
            dtg_hdct.Columns[3].Visible = false;
            dtg_hdct.Columns[4].Name = "Mã sách";
            dtg_hdct.Columns[5].Name = "Tên sách";
            dtg_hdct.Columns[6].Name = "Số lượng";
            dtg_hdct.Columns[7].Name = "Đơn giá";
            dtg_hdct.Rows.Clear();
            foreach (var x in _iqHDCT.GetListViewHoaDonCT(_IDHD).Where(c=>c.IdHoaDon == _idHD))
            {
                dtg_hdct.Rows.Add(x.Id,stt++,x.IdHoaDon,x.IdSachChiTiet,x.MaSach,x.TenSach,x.SoLuong,x.GiaBan);
            }
           
        }
        //dtg_hdct.Columns[0].Name = "";
        //    dtg_hdct.Columns[0].Visible = false;
        //    dtg_hdct.Columns[1].Name = "STT";
        //    dtg_hdct.Columns[1].Visible = false;
        //    dtg_hdct.Columns[2].Name = "IDHD";
        //    dtg_hdct.Columns[2].Visible = false;
        //    dtg_hdct.Rows.Clear();
        //    dtg_hdct.Columns[3].Name = "IDSach";
        //    dtg_hdct.Columns[4].Name = "Mã sách";
        //    dtg_hdct.Columns[5].Name = "Tên sách";
        //    dtg_hdct.Columns[6].Name = "Số lượng";
        //    dtg_hdct.Columns[7].Name = "Đơn giá";
        private void dtg_hdct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _iqHDCT.GetListHoaDonCT().Count) return;

            tbt_sl.Text = Convert.ToString(dtg_hdct.Rows[rd].Cells[6].Value);
                tbt_dongia.Text = Convert.ToString(dtg_hdct.Rows[rd].Cells[7].Value);

            if(dtg_hdct.Rows[rd].Cells[0].Value  != null)
            {
                lb_total.Text = (Convert.ToDecimal(tbt_dongia.Text) * Convert.ToInt32(tbt_sl.Text)).ToString();
            }
            else
            {
                lb_total.Text = "0";
                MessageBox.Show("Không có hoá đơn chi tiết");return;
               
            }
        }

        private void dtg_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dtg_hd.Columns[1].Name = "STT";
            //dtg_hd.Columns[2].Name = "Mã hoá đơn";
            //dtg_hd.Columns[3].Name = "Nhân viên bán hàng";
            //dtg_hd.Columns[4].Name = "Khách hàng";
            //dtg_hd.Columns[5].Name = "Ngày tạo";
            //dtg_hd.Columns[6].Name = "Ghi chú";
            //dtg_hd.Columns[7].Name = "Đơn giá";
            //dtg_hd.Columns[8].Name = "Trạng thái";
            //int rd = e.RowIndex;
            //if (rd == -1 || rd >= _iqlHD.GetListHoaDon().Count) return;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_hd.Rows[e.RowIndex];
                if(r.Cells[0].Value != null )
                {
                    _idHD = Guid.Parse(Convert.ToString(r.Cells[0].Value));
                }
                else
                {
                    MessageBox.Show("Hoá đơn trống", "Thông báo");
                    return;
                }
                LoadHDCT(_idHD);
                tbt_mahd.Text = Convert.ToString(r.Cells[2].Value);
                tbt_nv.Text = Convert.ToString(r.Cells[3].Value);
                tbt_kh.Text = Convert.ToString(r.Cells[4].Value);
                dtp_ngaytao.Text = Convert.ToString(r.Cells[5].Value);  
                tbt_ghichu.Text = Convert.ToString(r.Cells[6].Value);
                lb_tongtien.Text = Convert.ToString(r.Cells[7].Value);
                cbb_trangthai.Text = Convert.ToString(r.Cells[8].Value);
            }
           
            }
        

        private void tbt_timkiem_TextChanged(object sender, EventArgs e)
        {
            dtg_hd.ColumnCount = 9;
            int stt = 1;
            dtg_hd.Rows.Clear();
            dtg_hdct.Rows.Clear();
            dtg_hd.Columns[0].Name = "";
            dtg_hd.Columns[0].Visible = false;
            dtg_hd.Columns[1].Name = "STT";
            dtg_hd.Columns[2].Name = "Mã hoá đơn";
            dtg_hd.Columns[3].Name = "Nhân viên bán hàng";
            dtg_hd.Columns[4].Name = "Khách hàng";
            dtg_hd.Columns[5].Name = "Ngày tạo";
            dtg_hd.Columns[6].Name = "Ghi chú";
            dtg_hd.Columns[7].Name = "Tổng tiền";
            dtg_hd.Columns[8].Name = "Trạng thái";
            // lstVHD = _iqlHD.GetListViewHoaDon();
            foreach (var x in _iqlHD.GetListHoaDon().Where(c=>c.MaHoaDon.ToLower().Contains(tbt_timkiem.Text.ToLower()))/*.Where(c=>c.Id == _idHD)*/)
            {
                _nv = _iqlNV.GetListNV().Find(c => c.Id == x.IdNhanVien);
                _kh = _iqlKH.GetListKhachHang().Find(c => c.Id == x.IdKhachHang);
                dtg_hd.Rows.Add(x.Id, stt++, x.MaHoaDon, _nv.Ten, _kh.Ten, x.NgayTao, x.GhiChu, x.DonGia, x.TrangThai);
            }
        }

        private void cbb_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_loc.Text != "")
            {
                dtg_hd.ColumnCount = 9;
                int stt = 1;
                dtg_hd.Rows.Clear();
                dtg_hdct.Rows.Clear();
                dtg_hd.Columns[0].Name = "";
                dtg_hd.Columns[0].Visible = false;
                dtg_hd.Columns[1].Name = "STT";
                dtg_hd.Columns[2].Name = "Mã hoá đơn";
                dtg_hd.Columns[3].Name = "Nhân viên bán hàng";
                dtg_hd.Columns[4].Name = "Khách hàng";
                dtg_hd.Columns[5].Name = "Ngày tạo";
                dtg_hd.Columns[6].Name = "Ghi chú";
                dtg_hd.Columns[7].Name = "Tổng tiền";
                dtg_hd.Columns[8].Name = "Trạng thái";
                // lstVHD = _iqlHD.GetListViewHoaDon();
                foreach (var x in _iqlHD.GetHD().Where(c=>c.HoaDons.TrangThai.Contains(cbb_loc.Text))/*.Where(c=>c.Id == _idHD)*/)
                {

                    dtg_hd.Rows.Add(x.HoaDons.Id, stt++, x.HoaDons.MaHoaDon, x.NhanViens.Ten, x.KhachHangs.Ten, x.HoaDons.NgayTao, x.HoaDons.GhiChu, x.HoaDons.DonGia, x.HoaDons.TrangThai);
                }
            }
            
        }

        private void tbt_xoahd_Click(object sender, EventArgs e)
        {
            var xoa = _iqlHD.GetListHoaDon().FirstOrDefault(c => c.Id == _idHD);
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                if(xoa.TrangThai == "Đã thanh toán")
                {
                    MessageBox.Show("Hoá đơn đã thanh toán, không thể xoá");
                    return;
                }
                else
                {
                    _iqlHD.Delete(xoa);
                    MessageBox.Show("Xoá thành công", "Thông báo");
                    LoadHoaDon();
                }
            }
            if(result != DialogResult.Yes)
            {
                MessageBox.Show("Xoá hoá đơn thất bại", "Thông báo");
                return;
            }
        }
    }
}
