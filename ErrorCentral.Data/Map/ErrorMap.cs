using ErrorCentral.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Data.Map
{
    internal class ErrorMap : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("Error");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("error_id");

            builder.Property(x => x.Type)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(x => x.Message)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(x => x.StackTrace)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
        }
    }
}