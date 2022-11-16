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
    public class GioHangConfigurations : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdKhachHang).IsRequired();
            builder.Property(c => c.MaGioHang).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("nvarchar(100)").IsRequired();

            builder.HasOne(c => c.KhachHang).WithMany().HasForeignKey(c => c.IdKhachHang);

        }
        //public Guid Id { get; set; }
        //public Guid IdKhachHang { get; set; }
        //public string MaGioHang { get; set; }
        //public string TrangThai { get; set; }
    }
}
