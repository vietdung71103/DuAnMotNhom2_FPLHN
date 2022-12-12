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
    internal class Khuyenmais_ : IEntityTypeConfiguration<KhuyenMais>
    {
        void IEntityTypeConfiguration<KhuyenMais>.Configure(EntityTypeBuilder<KhuyenMais> builder)
        {
            builder.ToTable("KhuyenMais");
            //builder.HasKey(c => c.Id);
            //builder.Property(c => c.TenKhuyenMai).HasColumnType("nvarchar(200)");
            //builder.Property(c => c.PhanTram).HasColumnType("int");
            //builder.Property(c => c.ChiTiet).HasColumnType("nvarchar(200)");
            //builder.Property(c => c.NgayBatDau).HasColumnName("NgayBatDau").HasColumnType("DateTime").IsRequired();
            //builder.Property(c => c.NgayKetThuc).HasColumnName("NgayKetThuc").HasColumnType("DateTime").IsRequired();
        }
    }
}
