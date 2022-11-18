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
    internal class AnhConfigurations : IEntityTypeConfiguration<Anh>
    {
        public void Configure(EntityTypeBuilder<Anh> builder)
        {
            builder.ToTable("Anh");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ma).HasColumnType("varchar(20)"); 
            builder.Property(c => c.Ten).HasColumnType("nvarchar(100)"); 
            builder.Property(c => c.DuongDan).HasColumnType("nvarchar(200)"); 
        }
    }
}
