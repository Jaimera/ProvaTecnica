using ProvaPratica.Dto;
using ProvaTecnica.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// Listagem de seleção de melhor candidato e cadastro de peso
    /// </summary>
    [RoutePrefix("v1/selecoes")]
    public class SelecaoController : ApiController
    {
        private readonly ISelecaoService selecaoService;

        public SelecaoController(ISelecaoService _selecaoService)
        {
            selecaoService = _selecaoService;
        }

        /// <summary>
        /// Obtem lista de candidatos para a seleção ordenado pelo peso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/candidatos")]
        public IHttpActionResult GetCandidatos(Guid id)
        {
            return Ok(selecaoService.ObterCandidatos(id));
        }

        /// <summary>
        /// Adiciona uma nova seleção apartir de uma ocupação
        /// </summary>
        /// <param name="ocupacaoId">Id da ocupação</param>
        /// <returns>Id da seleção</returns>
        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody] Guid ocupacaoId)
        {
            return Ok(selecaoService.Adicionar(ocupacaoId));
        }

        /// <summary>
        /// Adiciona peso para a tecnologia da seleção
        /// </summary>
        /// <param name="id">Id da seleção</param>
        /// <param name="peso">Id da tecnologia e seu peso</param>
        /// <returns>Id do peso</returns>
        [HttpPost, Route("{id}/peso")]
        public IHttpActionResult PostPeso(Guid id, [FromBody] DtoTecnologiaPeso peso)
        {
            return Ok(selecaoService.AdicionarPeso(id, peso.TecnologiaId, peso.Peso));
        }
    }
}