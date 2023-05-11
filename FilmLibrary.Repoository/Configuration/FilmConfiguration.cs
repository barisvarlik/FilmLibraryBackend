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
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Length).IsRequired();

            builder.HasOne(x => x.Genre).WithMany(x => x.Films).HasForeignKey(x => x.GenreId);
            builder.HasOne(x => x.Studio).WithMany(x => x.FilmsProduced).HasForeignKey(x => x.StudioId);
            builder.HasOne(x => x.Director).WithMany(x => x.FilmsDirected).HasForeignKey(x => x.DirectorId);
            builder.HasMany(x => x.Cast).WithMany(x => x.FilmsStarred).UsingEntity(
                "FilmCast",
                l => l.HasOne(typeof(Person)).WithMany().HasForeignKey("PersonsId").HasPrincipalKey(nameof(Person.Id)).OnDelete(DeleteBehavior.Restrict),
                r => r.HasOne(typeof(Film)).WithMany().HasForeignKey("FilmsId").HasPrincipalKey(nameof(Film.Id)).OnDelete(DeleteBehavior.Restrict),
                j => j.HasKey("FilmsId", "PersonsId"));
        }
    }
}
