using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Confirguration
{
    public class HoaDonConfigurations : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.IdKhachHang).IsRequired();
            builder.Property(t => t.IdNhanVien).IsRequired();
            builder.Property(t => t.MaHoaDon).HasColumnType("varchar(20)").IsRequired();
            builder.Property(t => t.NgayTao).HasColumnType("Datetime").IsRequired();
            builder.Property(t => t.TrangThai).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(t => t.GhiChu).HasColumnType("nvarchar(500)");
            builder.Property(t => t.DonGia).HasColumnType("decimal").IsRequired();


            builder.HasOne(c => c.NhanVien).WithMany().HasForeignKey(c => c.IdNhanVien);
            builder.HasOne(c => c.KhachHang).WithMany().HasForeignKey(c => c.IdKhachHang);
        }


        //public Guid Id { get; set; }
        //public Guid IdKhachHang { get; set; }
        //public Guid IdNhanVien { get; set; }
        //public string MaHoaDon { get; set; }
        //public DateTime NgayTao { get; set; }
        //public string TrangThai { get; set; }
        //public decimal DonGia { get; set; }
    }
}
