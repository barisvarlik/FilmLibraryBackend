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
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        //Normally base entity will not get a config file, this is for template building.
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
