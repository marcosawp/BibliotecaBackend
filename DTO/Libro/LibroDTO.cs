﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Libro
{
    public class LibroDTO
    {
        public int? ID_Libro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int AnioPublicacion { get; set; }
    }
}
