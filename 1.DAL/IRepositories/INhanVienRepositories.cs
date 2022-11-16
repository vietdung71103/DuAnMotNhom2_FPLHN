﻿using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface INhanVienRepositories
    {
        bool Add(NhanVien obj);
        bool Delete(NhanVien obj);
        bool Update(NhanVien obj);
        List<NhanVien> GetListNhanVien();
    }
}
