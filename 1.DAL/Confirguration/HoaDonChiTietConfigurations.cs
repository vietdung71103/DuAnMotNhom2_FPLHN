using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Confirguration
{
    public class HoaDonChiTietConfigurations : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdHoaDon).IsRequired();
            builder.Property(c => c.IdSachChiTiet).IsRequired();
            builder.Property(c => c.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(c => c.GiaBan).HasColumnType("decimal").IsRequired();

            builder.HasOne(c => c.HoaDon).WithMany().HasForeignKey(c => c.IdHoaDon);
            builder.HasOne(c => c.SachChiTiet).WithMany().HasForeignKey(c => c.IdSachChiTiet);
        }
        //public Guid IdHoaDon { get; set; }
        //public Guid IdSachChiTiet { get; set; }
        //public int SoLuong { get; set; }
        //public decimal GiaBan { get; set; }
        //public virtual HoaDon? HoaDon { get; set; }
        //public virtual SachChiTiet? SachChiTiet { get; set; }
    }
}
