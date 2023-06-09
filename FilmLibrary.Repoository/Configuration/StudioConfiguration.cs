﻿using FilmLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Repository.Configuration
{
    public class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.FilmsProduced).WithOne(x => x.Studio);

            builder.HasMany(x => x.Employees).WithMany(x => x.Associations).UsingEntity(
                "StudioEmployee",
                l => l.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonsId").HasPrincipalKey(nameof(Person.Id)),
                r => r.HasOne(typeof(Studio)).WithMany().HasForeignKey("StudiosId").HasPrincipalKey(nameof(Studio.Id)),
                j => j.HasKey("PersonsId", "StudiosId"));
        }
    }
}
