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
    internal class NhanVienConfigurations : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.IdChucVu).IsRequired();
            builder.Property(c => c.Ma).HasColumnName("MaNV").HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(c => c.GioiTinh).HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(c => c.DiaChi).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(c => c.IdGuiBC);
            builder.Property(c => c.Sdt).HasColumnType("nvarchar(12)").IsRequired();
            builder.Property(c => c.NgaySinh).HasColumnType("datetime").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("nvarchar(100)").IsRequired();

            builder.HasOne(c => c.ChucVu).WithMany().HasForeignKey(c => c.IdChucVu);
        }
        //public Guid Id { get; set; }
        //public Guid IdChucVu { get; set; }
        //public string Ma { get; set; }
        //public string Ten { get; set; }
        //public string GioiTinh { get; set; }
        //public string DiaChi { get; set; }
        //public Guid IdGuiBC { get; set; }
        //public string Sdt { get; set; }

        //public DateTime NgaySinh { get; set; }
        //public string TrangThai { get; set; }
        //public virtual ChucVu? ChucVu { get; set; }
    }
}
