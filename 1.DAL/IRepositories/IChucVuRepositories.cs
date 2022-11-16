﻿using _1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IChucVuRepositories
    {
        bool Add(ChucVu obj);
        bool Update(ChucVu obj);
        bool Delete(ChucVu obj);
        List<ChucVu> GetListChucVu();
    }
}
