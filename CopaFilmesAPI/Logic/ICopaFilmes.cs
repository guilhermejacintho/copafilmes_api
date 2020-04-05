using CopaFilmesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Logic
{
    public interface ICopaFilmes
    {
        public RetornoDTO<MovieDTO> GeraCopa(List<MovieDTO> filmesSelecionados);
    }
}
