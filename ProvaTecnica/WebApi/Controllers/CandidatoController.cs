using ProvaPratica.Dto;
using ProvaTecnica.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvaTecnica.WebApi.Controllers
{
    /// <summary>
    /// Listagem, criação, edição e exclusão de candidatos para entrevistas
    /// </summary>
    [RoutePrefix("v1/candidatos")]
    public class CandidatoController : ApiController
    {
        private readonly ICandidatoService candidatoService;

        public CandidatoController(ICandidatoService _candidatoService)
        {
            candidatoService = _candidatoService;
        }

        /// <summary>
        /// Obtem lista de candidatos
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok(candidatoService.ObterTodos());
        }

        /// <summary>
        /// Obter candidato pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(candidatoService.ObterPorId(id));
        }

        /// <summary>
        /// Insere uma nova candidato
        /// </summary>
        /// <param name="candidato">Nome e vaga do candidato</param>
        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody] DtoCandidato candidato)
        {
            if (candidato == null || string.IsNullOrEmpty(candidato.Nome))
                return BadRequest("Informe o nome da candidato");

            if (candidato.OcupacaoId == null)
                return BadRequest("Informe a vaga do candidato");

            return Ok(candidatoService.Adicionar(candidato.Nome, candidato.OcupacaoId));
        }

        /// <summary>
        /// Insere tecnologias do candidato
        /// </summary>
        /// <param name="id">Id do candidato</param>
        /// <param name="idsTecnologia">Lista de tecnologias de dominio</param>
        /// <returns>Id do candidato</returns>
        [HttpPost, Route("{id}/tecnologias")]
        public IHttpActionResult PostTecnologias(Guid id, [FromBody]List<Guid> idsTecnologia)
        {
            if (idsTecnologia == null || idsTecnologia.Count == 0)
                return BadRequest("Informe as tecnologias de dominio do candidato");

            return Ok(candidatoService.AdicionarTecnologias(id, idsTecnologia));
        }
    }
}
