using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.DTOs
{
    public class FilmWithCastDto : FilmDto
    {
        public ICollection<PersonDto> Cast { get; set; }
    }
}
