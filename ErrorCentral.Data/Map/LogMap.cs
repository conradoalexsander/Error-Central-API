﻿using ErrorCentral.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorCentral.Data.Map
{
    internal class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

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

            builder.Property(x => x.IdOrganization);

            builder.HasOne(x => x.Organization)
                .WithMany(t => t.Logs)
                .HasForeignKey(org => org.IdOrganization);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("nvarchar(50)")

                .IsRequired();

            builder.Property(x => x.UpdatedAt)
              .HasColumnType("nvarchar(50)");
        }
    }
}