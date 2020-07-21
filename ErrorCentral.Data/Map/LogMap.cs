using ErrorCentral.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Data.Map
{
    internal class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.organization)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(x => x.title)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.level)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.description)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.origin)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.collectedBy)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.createdAt)
                .HasColumnType("smalldatetime")
                .IsRequired();
        }
    }
}