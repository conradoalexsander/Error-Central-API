using ErrorCentral.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Data.Map
{
    internal class OrganizationMap : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .HasColumnType("varchar(200)")
              .IsRequired();
        }
    }
}