using ProvaTecnica.IService;
using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvaTecnica.WebApi.Controllers
{
    /// <summary>
    /// Listagem, criação, edição e exclusão de tecnologias que a empresa trabalha
    /// </summary>
    [RoutePrefix("v1/tecnologias")]
    public class TecnologiaController : ApiController
    {
        private readonly ITecnologiaService tecnologiaService;

        public TecnologiaController(ITecnologiaService _tecnologiaService)
        {
            tecnologiaService = _tecnologiaService;
        }

        /// <summary>
        /// Obtem lista de tecnologias
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Ok(tecnologiaService.ObterTodos());
        }

        /// <summary>
        /// Obter tecnologia pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            var result = tecnologiaService.ObterPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Insere uma nova tecnologia
        /// </summary>
        /// <param name="nome">Nome da tecnologia</param>
        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody]string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return BadRequest("Informe o nome da tecnologia");

            return Ok(tecnologiaService.Adicionar(nome));
        }

        /// <summary>
        /// Atualiza uma tecnologia
        /// </summary>
        /// <param name="id">Guid da tecnologioa</param>
        /// <param name="nome">Nome da tecnologia</param>
        [HttpPut, Route("{id}")]
        public IHttpActionResult Put(Guid id, [FromBody]string nome)
        {
            return Ok(tecnologiaService.Atualizar(id, nome));
        }

        /// <summary>
        /// Deleta uma tecnologia
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var foiRemovido = tecnologiaService.Remove(id);

            if (!foiRemovido)
                return Conflict();

            return Ok(true);
        }
    }
}