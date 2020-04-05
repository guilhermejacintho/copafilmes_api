using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Model
{
    public class MovieDTO
    {
        public string Titulo { get; set; }
        public string Id { get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
    }
}
