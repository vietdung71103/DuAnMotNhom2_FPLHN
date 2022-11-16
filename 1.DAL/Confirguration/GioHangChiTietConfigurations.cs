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
    internal class GioHangChiTietConfigurations:IEntityTypeConfiguration<GioHangChiTiet>
    {

        //public Guid Id { get; set; }
        //public Guid IdGioHang { get; set; }
        //public Guid IdSachChiTiet { get; set; }
        //public int SoLuong { get; set; }
        //public decimal DonGia { get; set; }

        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("GioHangChiTiet");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdGioHang).IsRequired();
            builder.Property(c => c.IdSachChiTiet).IsRequired();
            builder.Property(c => c.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(c => c.DonGia).HasColumnType("decimal").IsRequired();

            builder.HasOne(c => c.GioHang).WithMany().HasForeignKey(c => c.IdGioHang);
            builder.HasOne(c => c.SachChiTiet).WithMany().HasForeignKey(c => c.IdSachChiTiet);
        }
    }
}
