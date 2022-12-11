using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLHoaDonServices:IQLHoaDonServices
    {
        Db2Context _dbContext;
        IHoaDonChiTietRepositories _rpsHDCT;
        IHoaDonRepositories _rpsHD;
        List<HoaDon> _lst;
        public QLHoaDonServices()
        {
            _lst = new List<HoaDon>();
            _dbContext = new Db2Context();
            _rpsHD = new HoaDonRepositories();
            _rpsHDCT = new HoaDonChiTietRepositories();
        }

        public string Add(HoaDon obj)
        {
            _rpsHD.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(HoaDon obj)
        {
            _rpsHD.Delete(obj);
            return "Xoá thành công";
        }

        public List<ViewHD> GetHD()
        {
            var x = (from a in _dbContext.HoaDons.ToList()
                     join b in _dbContext.KhachHangs.ToList() on a.IdKhachHang equals b.Id
                     join c in _dbContext.NhanViens.ToList() on a.IdNhanVien equals c.Id
                     select new ViewHD()
                     {
                         HoaDons = a,
                         KhachHangs = b,
                         NhanViens = c
                     }).ToList();
            return x;
        }

        public List<HoaDon> GetListHoaDon()
        {
           _lst = _rpsHD.GetListHoaDon();
            return _lst;
        }

        public List<ViewHoaDon> GetListViewHoaDon()
        {
            //    public Guid Id { get; set; }
            //public Guid IdKhachHang { get; set; }
            //public string TenKhachHang { get; set; }
            //public Guid IdNhanVien { get; set; }
            //public string TenNhanVien { get; set; }
            //public string MaHoaDon { get; set; }
            //public DateTime NgayTao { get; set; }
            //public string TrangThai { get; set; }
            //public decimal DonGia { get; set; }
            //public decimal TongTien { get; set; }
            var data = (from a in _dbContext.HoaDons
                        join b in _dbContext.KhachHangs on a.IdKhachHang equals b.Id
                        join c in _dbContext.NhanViens on a.IdNhanVien equals c.Id
                        join d in _dbContext.HoaDonChiTiets on a.Id equals d.IdHoaDon
                        select new ViewHoaDon()
                        {
                            Id = a.Id,
                            IdKhachHang = b.Id,
                            TenKhachHang = b.Ten,
                            IdNhanVien = c.Id,
                            TenNhanVien = c.Ten,
                            MaHoaDon = a.MaHoaDon,
                            NgayTao = a.NgayTao,
                            TrangThai = a.TrangThai,
                            GhiChu = a.GhiChu,
                            TongTien = a.DonGia,
                 
                        }).ToList();
            return data;
        }

        public string Update(HoaDon obj)
        {
            _rpsHD.Update(obj);
            return "Sửa thành công";
        }
    }
}
