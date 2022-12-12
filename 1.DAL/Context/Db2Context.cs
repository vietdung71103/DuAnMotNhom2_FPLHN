using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Context
{
    public class Db2Context : DbContext
    {
        public Db2Context()
        {
        }
        public Db2Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<Anh> Anhs { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NXB> NXBs { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<SachChiTiet> SachChiTiets { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        //public DbSet<KhuyenMai> khuyenmai { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Thực hiện các ràng buộc kết nối
        //    base.OnConfiguring(optionsBuilder.
        //        UseSqlServer("Data Source=LAPTOP-CUA-DUYY\\SQLEXPRESS;Initial Catalog=DbDuAn1_Nhom6_FPLHN;" +
        //        "Persist Security Info=True;User ID=duan1;Password=123"));
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Apply cac config cho cac model
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //    // Phương thức này sẽ áp dụng tất cả các config hiện có
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           optionsBuilder.UseSqlServer("Data Source=LAPTOP-CUA-DUYY\\SQLEXPRESS;Initial Catalog=DatabaseDuAn1_Nhom6_FPLHN;" + "Persist Security Info=True;User ID=duan1;Password=123");
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply cac config cho cac model
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Phương thức này sẽ áp dụng tất cả các config hiện có
        }
    }
}
