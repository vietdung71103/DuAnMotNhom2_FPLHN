using _1.DAL.Models;
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

namespace _3.PL.Views
{
    public partial class FrmQLThongKe : Form
    {
        IQLHoaDonServices _iqlHD;
        IQLTheLoaiServices _iqlTL;
        IQLHoaDonChiTietServices _iqlHDChiTiet;
        IQLKhachHangServices _iqlKH;
        IQLSanPhamServices _iqlSP;
        List<HoaDon> _lstHD;
        List<HoaDonChiTiet> _lstHDCT;
        List<KhachHang> _lstKH;

        public FrmQLThongKe()
        {
            InitializeComponent();
            _iqlHD = new QLHoaDonServices();
            _iqlHDChiTiet = new QLHoaDonChiTietServices();
            _iqlKH = new QLKhachHangServices();
            _iqlSP = new QLSanPhamServices();
            _lstHD = _iqlHD.GetListHoaDon();
            _iqlTL = new QLTheLoaiServices();
            _lstHDCT = new List<HoaDonChiTiet>();
            _lstKH = new List<KhachHang>();
            LoadNgayThang();
            LoadData();
            LoadCBB();
        }
        void LoadCBB()
        {
            foreach (var x in _iqlTL.GetListTheLoai())
            {
                cbb_tl.Items.Add(x.Ten);
            }
            foreach (var x in _iqlKH.GetListKhachHang())
            {
                cbb_kh.Items.Add(x.Ten);
            }
        }
        void LoadNgayThang()
        {
            for (int i = 1; i < 13; i++)
            {
                cbb_month.Items.Add(i);
            }
            var x = Convert.ToInt32(_iqlHD.GetListHoaDon().First().NgayTao.ToString("yyyy"));
            var y = Convert.ToInt32(_iqlHD.GetListHoaDon().Last().NgayTao.ToString("yyyy"));
            for (int i = x; i <= y; i++)
            {
                cbb_year.Items.Add(i);
            }
        }
        void LoadData()
        {
            dtg_show.Rows.Clear();
            var ac = (from a in _lstHD
                     join b in _iqlKH.GetListKhachHang() on a.IdKhachHang equals b.Id
                     join c in _iqlHDChiTiet.GetListHoaDonCT() on a.Id equals c.IdHoaDon
                     join d in _iqlSP.GetAll() on c.IdSachChiTiet equals d.SachChiTiets.Id
                     join e in _iqlTL.GetListTheLoai() on d.SachChiTiets.IdTheLoai equals e.Id
                     where b.Ten.Contains(cbb_kh.Text) && d.Sachs.Ten.ToLower().Contains(tbt_timkiemsp.Text.ToLower())
                      where e.Ten.Contains(cbb_tl.Text)
                     // where b.Ten.ToLower().Contains(cbb_kh.Text.ToLower())
                     select new
                     {
                         a,
                         b,
                         c,
                         d,
                         e
                     });
            string tt = "Chưa thanh toán";
            dtg_show.ColumnCount = 7;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[1].Name = "Tên sản phẩm";
            dtg_show.Columns[2].Name = "Thể loại";
            dtg_show.Columns[3].Name = "Số lượng";
            dtg_show.Columns[4].Name = "Giá bán";
            dtg_show.Columns[5].Name = "Tổng tiền";
            dtg_show.Columns[6].Name = "Tên khách hàng";
            foreach (var x in ac)
            {
                dtg_show.Rows.Add(x.a.Id, x.d.Sachs.Ten,x.e.Ten, x.c.SoLuong, x.c.GiaBan, x.a.DonGia, x.b.Ten);
            }
            lb_doanhthu.Text = ac.Select(c => c.a).Distinct().Sum(c => c.DonGia).ToString();
            lb_sohd.Text = ac.GroupBy(c => c.a).Count().ToString();
            lb_sohdchuatt.Text = ac.Select(c=>c.a).Distinct().Where(c=> c.TrangThai.ToString() == "Chưa thanh toán").Count().ToString();
            lb_tongkhchuatt.Text = ac.GroupBy(c => c.b).Count().ToString();    
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbb_year.Text != "")
            {
                _lstHD = _iqlHD.GetListHoaDon().Where(c => (c.NgayTao.Month.ToString() == cbb_month.Text && c.NgayTao.Year.ToString() == cbb_year.Text)).ToList();
                LoadData();
            }
        }
       
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (cbb_month.Text != "")
            {
                _lstHD = _iqlHD.GetListHoaDon().Where(c => (c.NgayTao.Month.ToString() == cbb_month.Text && c.NgayTao.Year.ToString() == cbb_year.Text)).ToList();
                LoadData();
            }
            else
            {
                _lstHD = _iqlHD.GetListHoaDon().Where(c => c.NgayTao.Year.ToString() == cbb_year.Text).ToList();
                LoadData();
            }
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbb_tl_TextChanged(object sender, EventArgs e)
        {

            if(cbb_tl.Text != "")
            {
                LoadData();
            }


        }

        private void cbb_kh_TextChanged(object sender, EventArgs e)
        {
            if(cbb_kh.Text != "")
            {
                LoadData();
            }


        }
    }
}
