using ProvaTecnica.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProvaTecnica.WebApi.Controllers
{
    /// <summary>
    /// Listagem, criação, edição e exclusão de vagas abertas na empresa
    /// </summary>
    [RoutePrefix("v1/vagas")]
    public class OcupacaoController : ApiController
    {
        private readonly IOcupacaoService ocupacaoService;

        public OcupacaoController(IOcupacaoService _ocupacaoService)
        {
            ocupacaoService = _ocupacaoService;
        }

        /// <summary>
        /// Obtem lista de vagas
        /// </summary>
        /// <returns>Array de vagas</returns>
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok(ocupacaoService.ObterTodos());
        }

        /// <summary>
        /// Obter vaga pelo id
        /// </summary>
        /// <param name="id">Id da vaga</param>
        /// <returns>Vaga</returns>
        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(ocupacaoService.ObterPorId(id));
        }

        /// <summary>
        /// Insere uma nova vaga
        /// </summary>
        /// <param name="nome">Nome da vaga</param>
        /// <returns>Vaga</returns>
        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return BadRequest("Informe o nome da vaga");

            return Ok(ocupacaoService.Adicionar(nome));
        }

        /// <summary>
        /// Atualiza uma vaga
        /// </summary>
        /// <param name="id">Guid da tecnologioa</param>
        /// <param name="nome">Nome da vaga</param>
        /// <returns>Vaga</returns>
        [HttpPut, Route("{id}")]
        public IHttpActionResult Put(Guid id, [FromBody]string nome)
        {
            return Ok(ocupacaoService.Atualizar(id, nome));
        }

        /// <summary>
        /// Deleta uma vaga
        /// </summary>
        /// <param name="id">Id da vaga para exclusão</param>
        /// <returns>Confirmação de vaga deletada</returns>
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            return Ok(ocupacaoService.Remove(id));
        }
    }
}