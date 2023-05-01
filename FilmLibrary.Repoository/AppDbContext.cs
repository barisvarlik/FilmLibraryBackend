using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Repoository
{
    public class AppDbContext : DbContext
    {
        //public DbSet<TEntity> EntityName { get; set; } //use this format for every entity

        AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
