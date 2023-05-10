using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Models
{
    public class Studio : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Film> FilmsProduced { get; set; }
        public ICollection<Person> Employees { get; set; }
    }
}
