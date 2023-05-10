using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.DTOs
{
    public class DirectorWithFilmsDto : PersonDto
    {
        public ICollection<FilmDto> FilmsDirected { get; set; }
    }
}
