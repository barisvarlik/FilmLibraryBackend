using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public ICollection<Film> FilmsStarred { get; set; }
        public ICollection<Film> FilmsDirected { get; set; }
        public ICollection<Studio> Associations { get; set; }
    }
}
