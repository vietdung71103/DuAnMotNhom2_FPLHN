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
    internal class KhachHangConfigurations : IEntityTypeConfiguration<KhachHang>
    {


        //public Guid Id { get; set; }
        //public string Ma { get; set; }
        //public string Ten { get; set; }
        //public string GioiTinh { get; set; }
        //public string DiaChi { get; set; }
        //public string Sdt { get; set; }
        //public DateTime NgaySinh { get; set; }
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHang");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Ma).HasColumnName("MaKhachHang").HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(c => c.GioiTinh).HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(c => c.DiaChi).HasColumnType("nvarchar(200)");
            builder.Property(c => c.Sdt).HasColumnType("varchar(12)").IsRequired();
            builder.Property(c => c.NgaySinh).HasColumnType("datetime").IsRequired();
         
        }
    }
}
