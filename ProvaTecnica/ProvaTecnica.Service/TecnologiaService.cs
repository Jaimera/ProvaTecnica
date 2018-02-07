using ProvaTecnica.Model;
using ProvaTecnica.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaTecnica.IRepository;

namespace ProvaTecnica.Service
{
    public class TecnologiaService : ITecnologiaService
    {
        private readonly ITecnologiaRepository tecnologiaRepository;
        private readonly ICandidatoRepository candidatoRepository;
        private readonly ISelecaoRepository selecaoRepository;

        public TecnologiaService(ITecnologiaRepository _tecnologiaRepository,
                                 ICandidatoRepository _candidatoRepository,
                                 ISelecaoRepository _selecaoRepository)
        {
            tecnologiaRepository = _tecnologiaRepository;
            candidatoRepository = _candidatoRepository;
            selecaoRepository = _selecaoRepository;
        }

        public Guid Adicionar(string nome)
        {
            var tecnologia = tecnologiaRepository.AdicionarTecnologia(nome);
            return tecnologia;
        }

        public Tecnologia Atualizar(Guid id, string nome)
        {
            var tecnologia = tecnologiaRepository.AtualizarTecnologia(id, nome);
            return tecnologia;
        }

        public Tecnologia ObterPorId(Guid id)
        {
            var tecnologia = tecnologiaRepository.ObterPorId(id);
            return tecnologia;
        }

        public List<Tecnologia> ObterTodos()
        {
            var lista = tecnologiaRepository.ObterTecnologias();
            return lista;
        }

        public bool Remove(Guid id)
        {
            var candidatoComTecnologia = candidatoRepository.ObterTodos().Any(w => w.Tecnologias.Any(a => a.Id == id));

            if (candidatoComTecnologia)
                return false;
            
            return tecnologiaRepository.RemoverTecnologia(id);
        }
    }
}
