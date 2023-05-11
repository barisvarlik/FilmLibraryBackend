using FilmLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Repository.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Nationality).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.Associations).WithMany(x => x.Employees).UsingEntity(
                "StudioEmployee",
                l => l.HasOne(typeof(Studio)).WithMany().HasForeignKey("StudiosId").HasPrincipalKey(nameof(Studio.Id)),
                r => r.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonsId").HasPrincipalKey(nameof(Person.Id)),
                j => j.HasKey("PersonsId", "StudiosId"));

            builder.HasMany(x => x.FilmsStarred).WithMany(x => x.Cast).UsingEntity(
                "FilmCast",
                l => l.HasOne(typeof(Film)).WithMany().HasForeignKey("FilmsId").HasPrincipalKey(nameof(Film.Id)).OnDelete(DeleteBehavior.Restrict),
                r => r.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonsId").HasPrincipalKey(nameof(Person.Id)).OnDelete(DeleteBehavior.Restrict),
                j => j.HasKey("FilmsId", "PersonsId"));

            builder.HasMany(x => x.FilmsDirected).WithOne(x => x.Director);
        }
    }
}
