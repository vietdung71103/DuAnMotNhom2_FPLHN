using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.DAL.Models;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;

namespace _2.BUS.Services
{
    public class KhuyenMai_service : IKhuyenMai_Service
    {
        Ikhuyenmai_repo _rps;
        public KhuyenMai_service()
        {
            _rps = new KhuyenMai_repos();
        }
        //string IKhuyenMai_Service.Add(KhuyenMai obj)
        //{
        //    _rps.Add(obj);
        //    return "Thêm thành công";
        //}

        //string IKhuyenMai_Service.Delete(KhuyenMai obj)
        //{
        //    _rps.Delete(obj);
        //    return "Xoá thành công";
        //}

        //List<KhuyenMai> IKhuyenMai_Service.GetListChucVu()
        //{
        //    return _rps.GetList();
        //}

        //string IKhuyenMai_Service.Update(KhuyenMai obj)
        //{
        //    _rps.Update(obj);
        //    return "Sửa thành công";
        //}
    }
}
