using _1.DAL.Context;
using _1.DAL.IRepositories;
using _1.DAL.Models;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLSanPhamServices:IQLSanPhamServices
    {
        ISachChiTietRepositories _rps;
        ITheLoaiRepositories _rpstl;
        ITacGiaRepositories _rpstg;
        ISachRepositories _rpssach;
        INXBRepositories _rpsnxb;
        IAnhRepositories _anh;
        List<SachChiTiet> _lstsct;
        List<SanPhamView> _lstsp;
        Db2Context _dbContext;
        public QLSanPhamServices()
        {
            _dbContext = new Db2Context();
            _rps = new SachChiTietRepositories();
            _rpstl = new TheLoaiRepositories();
            _rpssach = new SachRepositories();
            _rpsnxb = new NXBRepositories();
            _rpstg = new TacGiaRepositories();
            _anh = new AnhRepositories();
           _lstsp = new  List<SanPhamView>();
            GetListSachChiTiet();
            GetAll();
        }

        public string Add(SachChiTiet obj)
        {
          _rps.Add(obj);
            return "Thêm thành công";
        }

        public string Delete(SachChiTiet obj)
        {
            _rps.Delete(obj);
            return "Xoá thành công";
        }

        public List<SanPhamView> GetAll()
        {
            _lstsp = (from a in _rps.GetListSachChiTiet()
                      join b in _rpsnxb.GetListNXB() on a.IdNXB equals b.Id
                      join c in _rpssach.GetListSach() on a.IdSach equals c.Id
                      join d in _rpstg.GetListTacGia() on a.IdTacGia equals d.Id
                      join e in _rpstl.GetListTheLoai() on a.IdTheLoai equals e.Id
                      //join f in _anh.GetListAnh() on a.IdAnh equals f.Id
                      select new SanPhamView()
                      {
                          SachChiTiets = a,
                          NXBs = b,
                          TacGias = d,
                          Sachs = c,
                          TheLoais = e
                          //Anhs = f,

                      }).ToList();
            return _lstsp;
            //_lstsp = (from a in _dbContext.NXBs.ToList()
            //          join b in _dbContext.SachChiTiets.ToList() on a.Id equals b.IdNXB
            //          join c in _dbContext.Sachs.ToList() on b.IdSach equals c.Id
            //          join d in _dbContext.TacGias.ToList() on b.IdTacGia equals d.Id
            //          join e in _dbContext.TheLoais.ToList() on b.IdTheLoai equals e.Id
            //          select new SanPhamView()
            //          {
            //              NXBs = a,
            //              //SachChiTiets = b,
            //              Sachs = c,
            //              TacGias = d,
            //              TheLoais = e
            //          }).ToList();
            //return _lstsp;
        }

        public List<SachChiTiet> GetListSachChiTiet()
        {
          _lstsct =  _rps.GetListSachChiTiet();
            return _lstsct;
        }

        public string Update(SachChiTiet obj)
        {
            _rps.Update(obj);
            return "Sửa thành công";
        }
    }
}
