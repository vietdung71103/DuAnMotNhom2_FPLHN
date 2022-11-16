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
    internal class SachChiTietConfigurations : IEntityTypeConfiguration<SachChiTiet>
    {
        public void Configure(EntityTypeBuilder<SachChiTiet> builder)
        {
            builder.ToTable("SachChiTiet");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdSach).IsRequired();
            builder.Property(c => c.IdTacGia).IsRequired();
            builder.Property(c => c.IdTheLoai).IsRequired();
            builder.Property(c => c.IdNXB).IsRequired();
            builder.Property(c => c.MoTa).HasColumnType("nvarchar(200)");
            
            builder.Property(c => c.GiaBan).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.GiaNhap).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.SoLuongTon).HasColumnType("int").IsRequired();

            builder.HasOne(c => c.Sach).WithMany().HasForeignKey(c => c.IdSach).IsRequired();
            builder.HasOne(c => c.TacGia).WithMany().HasForeignKey(c => c.IdTacGia).IsRequired();
            builder.HasOne(c => c.TheLoai).WithMany().HasForeignKey(c => c.IdTheLoai).IsRequired();
            builder.HasOne(c => c.NXB).WithMany().HasForeignKey(c => c.IdNXB).IsRequired();


        }
        //public Guid Id { get; set; }
        //public Guid IdSach { get; set; }
        //public Guid IdTacGia { get; set; }
        //public Guid IdTheLoai { get; set; }
        //public Guid IdNXB { get; set; }
        //public string MoTa { get; set; }
        //public int SoLuong { get; set; }
        //public decimal GiaNhap { get; set; }
        //public decimal GiaBan { get; set; }
        //public int SoLuongTon { get; set; }
        //public int SoTrang { get; set; }
    }
}
