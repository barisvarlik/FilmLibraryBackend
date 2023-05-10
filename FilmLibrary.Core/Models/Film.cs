using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Models
{
    public class Film : BaseEntity
    {
        public DateTime Year { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int StudioId { get; set; }
        public Genre Genre { get; set; }
        public Person Director { get; set; }
        public ICollection<Person> Cast { get; set; }
        public Studio Studio { get; set; }
    }
}
