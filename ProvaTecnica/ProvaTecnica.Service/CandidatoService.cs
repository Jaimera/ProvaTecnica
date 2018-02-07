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
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository repository;
        private readonly ITecnologiaRepository tecnologiaRepository;
        private readonly IOcupacaoRepository ocupacaoRepository;

        public CandidatoService(ICandidatoRepository _repository, 
                                ITecnologiaRepository _tecnologiaRepository,
                                IOcupacaoRepository _ocupacaoRepository)
        {
            repository = _repository;
            tecnologiaRepository = _tecnologiaRepository;
            ocupacaoRepository = _ocupacaoRepository;
        }

        public Guid Adicionar(string nome, Guid ocupacaoId)
        {
            var ocupacao = ocupacaoRepository.ObterPorId(ocupacaoId);

            return repository.Adicionar(nome, ocupacao);
        }

        public Guid AdicionarTecnologias(Guid id, List<Guid> idsTecnologia)
        {
            var tecnologias = tecnologiaRepository.ObterTecnologias().Where(w => idsTecnologia.Contains(w.Id)).ToList();

            return repository.AdicionarTecnologias(id, tecnologias);
        }

        public Candidato Atualizar(Guid id, string nome)
        {
            throw new NotImplementedException();
        }

        public Candidato ObterPorId(Guid id)
        {
            return repository.ObterPorId(id);
        }

        public List<Candidato> ObterTodos()
        {
            return repository.ObterTodos();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
