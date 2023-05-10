using FilmLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Repoository.Configuration
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

            builder.HasMany(x => x.Associations).WithMany(x => x.Employees);
            builder.HasMany(x => x.FilmsStarred).WithMany(x => x.Cast);
            builder.HasMany(x => x.FilmsDirected).WithOne(x => x.Director);
        }
    }
}
