using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaTecnica.Model;
using ProvaTecnica.Repository;
using ProvaTecnica.Service;

namespace ProvaTecnica.Test
{
    [TestClass]
    public class UnitTestWebApi
    {
        private readonly TecnologiaRepository tecnologiaRepository;
        private readonly OcupacaoRepository ocupacaoRepository;
        private readonly SelecaoRepository selecaoRepository;
        private readonly CandidatoRepository candidatoRepository;

        private readonly TecnologiaService tecnologiaService;
        private readonly OcupacaoService ocupacaoService;
        private readonly SelecaoService selecaoService;
        private readonly CandidatoService candidatoService;


        public UnitTestWebApi()
        {
            tecnologiaRepository = new TecnologiaRepository();
            ocupacaoRepository = new OcupacaoRepository();
            selecaoRepository = new SelecaoRepository();
            candidatoRepository = new CandidatoRepository();

            tecnologiaService = new TecnologiaService(tecnologiaRepository, candidatoRepository, selecaoRepository);
            ocupacaoService = new OcupacaoService(ocupacaoRepository);
            selecaoService = new SelecaoService(selecaoRepository, candidatoRepository);
            candidatoService = new CandidatoService(candidatoRepository, tecnologiaRepository, ocupacaoRepository);
        }

        [TestMethod]
        public void TestService()
        {
            var guidOcupacao = ocupacaoService.Adicionar("c#");

            var guid = candidatoService.Adicionar("Jaime", guidOcupacao);
            var novoUsuario = candidatoService.ObterPorId(guid);

            Assert.AreEqual(guid, novoUsuario.Id);
        }

        [TestMethod]
        public void TestController()
        {
            var controller = new ProvaTecnica.WebApi.Controllers.TecnologiaController(tecnologiaService);

            var response = controller.Post("C#");

            var result = controller.Get() as OkNegotiatedContentResult<List<Tecnologia>>;
            Assert.IsNotNull(result);
            Assert.AreEqual("C#", result.Content[0].Nome);
        }

        [TestMethod]
        public void TestControllerIdNaoEncontrado()
        {
            var controller = new ProvaTecnica.WebApi.Controllers.TecnologiaController(tecnologiaService);

            var resultado = controller.Get(Guid.NewGuid());

            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestMelhorCandidato()
        {
            (Guid selecaoCSharp, Guid selecaoJava) = InsereMassaDeDados();
            
            var candidatos = selecaoService.ObterCandidatos(selecaoCSharp);

            Assert.AreEqual(candidatos.First().Nome, "Jaime");
        }

        [TestMethod]
        public void TestMelhorCandidatoJava()
        {
            (Guid selecaoCSharp, Guid selecaoJava) = InsereMassaDeDados();
            
            var candidatos = selecaoService.ObterCandidatos(selecaoJava);

            Assert.AreEqual(candidatos.First().Nome, "Predo");
        }

        [TestMethod]
        public void TestSegundoComMaisPontosCSharp()
        {
            (Guid selecaoCSharp, Guid selecaoJava) = InsereMassaDeDados();
            
            var candidatos = selecaoService.ObterCandidatos(selecaoCSharp);

            Assert.AreEqual(candidatos[1].Nome, "Joao");
        }

        [TestMethod]
        public void TestSomaPontosPiorCandidatoCSharp()
        {
            (Guid selecaoCSharp, Guid selecaoJava) = InsereMassaDeDados();
            
            var candidatos = selecaoService.ObterCandidatos(selecaoCSharp);

            Assert.AreEqual(candidatos.Last().SomaPeso, 11);
        }

        public (Guid, Guid) InsereMassaDeDados()
        {
            //tecnologias da empresa
            var guidTecCSharp = tecnologiaService.Adicionar("C#");
            var guidTecJava = tecnologiaService.Adicionar("Java");
            var guidTecJavaScript = tecnologiaService.Adicionar("JavaScript");
            var guidTecAngular = tecnologiaService.Adicionar("Angular");

            //vaga aberta
            var guidVaga = ocupacaoService.Adicionar("Desenvolvedor C#");
            var guidVaga2 = ocupacaoService.Adicionar("Desenvolvedor Java");

            //candidatos
            var guidCandidato1 = candidatoService.Adicionar("Joao", guidVaga);
            candidatoService.AdicionarTecnologias(guidCandidato1, new List<Guid> { guidTecJavaScript, guidTecAngular });

            var guidCandidato2 = candidatoService.Adicionar("Predo", guidVaga);
            candidatoService.AdicionarTecnologias(guidCandidato2, new List<Guid> { guidTecCSharp, guidTecJava });

            var guidCandidato3 = candidatoService.Adicionar("Jaime", guidVaga);
            candidatoService.AdicionarTecnologias(guidCandidato3, new List<Guid> { guidTecCSharp, guidTecAngular, guidTecJavaScript });

            //selecao c#
            var guidSelecao = selecaoService.Adicionar(guidVaga);
            selecaoService.AdicionarPeso(guidSelecao, guidTecCSharp, 10);
            selecaoService.AdicionarPeso(guidSelecao, guidTecAngular, 7);
            selecaoService.AdicionarPeso(guidSelecao, guidTecJava, 1);
            selecaoService.AdicionarPeso(guidSelecao, guidTecJavaScript, 8);

            //selecao Java
            var guidSelecao2 = selecaoService.Adicionar(guidVaga);
            selecaoService.AdicionarPeso(guidSelecao2, guidTecCSharp, 1);
            selecaoService.AdicionarPeso(guidSelecao2, guidTecAngular, 7);
            selecaoService.AdicionarPeso(guidSelecao2, guidTecJava, 16);
            selecaoService.AdicionarPeso(guidSelecao2, guidTecJavaScript, 8);

            return (guidSelecao, guidSelecao2);
        }
    }
}
