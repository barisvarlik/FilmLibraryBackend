﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.DTOs
{
    public class FilmsOfStudioDto : StudioDto
    {
        public ICollection<FilmDto> FilmsProduced { get; set; }
    }
}
