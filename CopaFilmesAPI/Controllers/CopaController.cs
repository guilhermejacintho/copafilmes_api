using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmesAPI.Logic;
using CopaFilmesAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopaController : ControllerBase
    {
        private readonly ICopaFilmes _copaFilmes;

        public CopaController(ICopaFilmes cFilmes)
        {
            _copaFilmes = cFilmes;
        }

        [HttpPost]
        public ActionResult Post([FromBody] List<MovieDTO> filmes)
        {
            RetornoDTO<MovieDTO> retorno = _copaFilmes.GeraCopa(filmes);

            if (retorno.Success)
                return Ok(retorno.DataList);
            else
                return BadRequest(retorno.MainException.Message);
        }
    }
}