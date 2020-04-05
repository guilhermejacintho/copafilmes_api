using CopaFilmesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Logic
{
    public class CopaFilmes : ICopaFilmes
    {
        public RetornoDTO<MovieDTO> GeraCopa(List<MovieDTO> filmesSelecionados)
        {
            RetornoDTO<MovieDTO> validacao = ValidaEntrada(filmesSelecionados);
            if (!validacao.Success) return validacao;

            //Ordena os titulos em ordem alfabetica
            filmesSelecionados = filmesSelecionados.OrderBy(c => c.Titulo).ToList();

            int ultimoArray = filmesSelecionados.Count - 1;

            List<MovieDTO> quartasDeFinal = new List<MovieDTO>();

            for (int i = 0; i <= ((filmesSelecionados.Count / 2) - 1); i++)
            {
                quartasDeFinal.Add(this.ComparaFilme(filmesSelecionados[i], filmesSelecionados[ultimoArray - i]));
            }

            while (quartasDeFinal.Count > 2)
            {
                List<MovieDTO> campeoes = new List<MovieDTO>();
                for (int i = 0; i <= ((quartasDeFinal.Count / 2)); i += 2)
                {
                    campeoes.Add(ComparaFilme(quartasDeFinal[i], quartasDeFinal[i + 1]));
                }
                quartasDeFinal = campeoes;
            }

            quartasDeFinal = quartasDeFinal.OrderByDescending(c => c.Nota).ThenBy(v => v.Titulo).ToList();

            return new RetornoDTO<MovieDTO>() {
                DataList = quartasDeFinal
            };

        }

        private MovieDTO ComparaFilme(MovieDTO filme1, MovieDTO filme2)
        {
            if (filme1.Nota > filme2.Nota)
            {
                return filme1;
            }
            else if (filme1.Nota < filme2.Nota)
            {
                return filme2;
            }
            else
            {
                //Se forem iguais, retorna o primeiro título
                int comp = string.Compare(filme1.Titulo, filme2.Titulo);

                return comp <= 0 ? filme1 : filme2;
            }

        }

        private RetornoDTO<MovieDTO> ValidaEntrada(List<MovieDTO> filmesSelecionados)
        {
            if (filmesSelecionados == null) return new RetornoDTO<MovieDTO>() { MainException = new Exception("Lista de Filmes recebida é nula") };

            if (filmesSelecionados.Count != 8) return new RetornoDTO<MovieDTO>() { MainException = new Exception("Lista de Filmes possui um valor diferente de 8.") };

            if (filmesSelecionados.Where(c => c.Titulo == null).Count() > 0) return new RetornoDTO<MovieDTO>() { MainException = new Exception("Existem títulos vazios na lista de filmes.") };

            return new RetornoDTO<MovieDTO>();

        }

    }
}
