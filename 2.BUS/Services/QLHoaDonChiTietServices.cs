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
    public class QLHoaDonChiTietServices:IQLHoaDonChiTietServices
    {
        List<HoaDonChiTiet> _lsthdct;
        List<ViewHoaDonChiTiet> _lstvhdct;
        Db2Context _dbContext;
        IHoaDonChiTietRepositories _iql;
        public QLHoaDonChiTietServices()
        {
            _dbContext = new Db2Context();
            _lsthdct = new List<HoaDonChiTiet>();
            _lstvhdct = new List<ViewHoaDonChiTiet>();
            _iql = new HoaDonChiTietRepositories();
        }

        public string AddHDCT(HoaDonChiTiet obj)
        {
           _iql.Add(obj);
            return "Thêm thành công";
        }

        public string DeleteHDCT(HoaDonChiTiet obj)
        {
            _iql.Update(obj);
            return "Xoá thành công";
        }

        public List<HoaDonChiTiet> GetListHoaDonCT()
        {
         _lsthdct=   _iql.GetListHoaDonChiTiet();
            return _lsthdct;
        }
        //public Guid Id { get; set; }
        //public Guid IdHoaDon { get; set; }
        //public Guid IdSachChiTiet { get; set; }
        //public int SoLuong { get; set; }
        //public decimal GiaBan { get; set; }



        //public Guid Id { get; set; }
        //public Guid IdHoaDon { get; set; }
        //public Guid IdSachChiTiet { get; set; }
        //public string MaSach { get; set; }
        //public string TenSach { get; set; }
        //public int SoLuong { get; set; }
        //public decimal GiaBan { get; set; }
        public List<ViewHoaDonChiTiet> GetListViewHoaDonCT(Guid idHD)
        {
            var data = (from a in _dbContext.HoaDonChiTiets
                         join b in _dbContext.HoaDons on a.IdHoaDon equals b.Id
                      
                         join c in _dbContext.SachChiTiets on a.IdSachChiTiet equals c.Id
                         join d in _dbContext.Sachs on c.IdSach equals d.Id
                         select new ViewHoaDonChiTiet()
                         {
                             Id = a.Id,
                             IdHoaDon = b.Id, 
                             IdSachChiTiet = c.Id,
                             MaSach = c.Ma,
                             TenSach = d.Ten,
                             SoLuong = a.SoLuong,
                             GiaBan = a.GiaBan,
                         }).ToList();
            return data;
        }

        public string UpdateHDCT(HoaDonChiTiet obj)
        {
            _iql.Update(obj);
            return "Sửa thành công";
        }
    }
}
