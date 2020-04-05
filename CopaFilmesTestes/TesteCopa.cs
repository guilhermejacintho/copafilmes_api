using CopaFilmesAPI.Logic;
using CopaFilmesAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaFilmesTestes
{
    public class TesteCopa
    {
        List<MovieDTO> listaCheia = new List<MovieDTO>();

        public TesteCopa()
        {
            listaCheia.Add(new MovieDTO() { Titulo = "Os Incríveis 2", Ano = 2018, Id = "tt3606756", Nota = 8.5m });
            listaCheia.Add(new MovieDTO() { Titulo = "Jurassic World: Reino Ameaçado", Ano = 2018, Id = "tt4881806", Nota = 6.7m });
            listaCheia.Add(new MovieDTO() { Titulo = "Oito Mulheres e um Segredo", Ano = 2018, Id = "tt5164214", Nota = 6.3m });
            listaCheia.Add(new MovieDTO() { Titulo = "Hereditário", Ano = 2018, Id = "tt7784604", Nota = 7.8m });
            listaCheia.Add(new MovieDTO() { Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Id = "tt4154756", Nota = 8.8m });
            listaCheia.Add(new MovieDTO() { Titulo = "Deadpool 2", Ano = 2018, Id = "tt5463162", Nota = 8.1m });
            listaCheia.Add(new MovieDTO() { Titulo = "Han Solo: Uma História Star Wars", Ano = 2018, Id = "tt3778644", Nota = 7.2m });
            listaCheia.Add(new MovieDTO() { Titulo = "Thor: Ragnarok", Ano = 2017, Id = "tt3501632", Nota = 7.9m });
        }

        [Fact]
        public void Testes_GeraCopaVazia()
        {
            CopaFilmes copa = new CopaFilmes();
            var resultado = copa.GeraCopa(null);
            var resultadoEsperado = new RetornoDTO<MovieDTO>() { MainException = new Exception("Lista de Filmes recebida é nula") };
            Assert.Equal(JsonConvert.SerializeObject(resultadoEsperado), JsonConvert.SerializeObject(resultado));
        }

        [Fact]
        public void Testes_GeraCopaImpropria()
        {
            CopaFilmes copa = new CopaFilmes();
            var resultado = copa.GeraCopa(listaCheia.GetRange(0,7));
            var resultadoEsperado = new RetornoDTO<MovieDTO>() { MainException = new Exception("Lista de Filmes possui um valor diferente de 8.") };
            Assert.Equal(JsonConvert.SerializeObject(resultadoEsperado), JsonConvert.SerializeObject(resultado));
        }

        [Fact]
        public void Testes_OK()
        {
            CopaFilmes copa = new CopaFilmes();
            var resultado = copa.GeraCopa(listaCheia);

            var listaResult = new List<MovieDTO>();
            listaResult.Add(new MovieDTO() { Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Id = "tt4154756", Nota = 8.8m });
            listaResult.Add(new MovieDTO() { Titulo = "Os Incríveis 2", Ano = 2018, Id = "tt3606756", Nota = 8.5m });

            var resultadoEsperado = new RetornoDTO<MovieDTO>() { DataList = listaResult };
            Assert.Equal(JsonConvert.SerializeObject(resultadoEsperado), JsonConvert.SerializeObject(resultado));
        }
    }
}
