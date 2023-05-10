using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.DTOs
{
    public class FilmDto : BaseDto
    {
        public DateTime Year { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int StudioId { get; set; }
    }
}
