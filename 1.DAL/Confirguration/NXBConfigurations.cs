using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Confirguration
{
    internal class NXBConfigurations : IEntityTypeConfiguration<NXB>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NXB> builder)
        {
            builder.ToTable("NXB");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ma).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
