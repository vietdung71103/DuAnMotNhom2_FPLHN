﻿using _1.DAL.Models;
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
    internal class TheLoaiConfigurations : IEntityTypeConfiguration<TheLoai>
    {
        public void Configure(EntityTypeBuilder<TheLoai> builder)
        {
            builder.ToTable("TheLoai");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Ma).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}