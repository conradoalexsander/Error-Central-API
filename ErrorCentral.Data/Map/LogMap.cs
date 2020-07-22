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

            builder.Property(x => x.Organization)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Level)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Origin)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.CollectedBy)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("smalldatetime")
                .IsRequired();
        }
    }
}