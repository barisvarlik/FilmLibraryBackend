using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
