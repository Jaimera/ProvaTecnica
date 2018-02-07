using ProvaTecnica.Dto;
using ProvaTecnica.IRepository;
using ProvaTecnica.IService;
using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Service
{
    public class SelecaoService : ISelecaoService
    {
        private readonly ISelecaoRepository repository;
        private readonly ICandidatoRepository candidatoRepository;

        public SelecaoService(ISelecaoRepository _repository, ICandidatoRepository _candidatoRepository)
        {
            repository = _repository;
            candidatoRepository = _candidatoRepository;
        }

        public Guid Adicionar(Guid ocupacaoId)
        {
            return repository.Adicionar(ocupacaoId);
        }

        public Guid AdicionarPeso(Guid id, Guid tecnologiaId, int peso)
        {
            return repository.AdicionarPeso(id, tecnologiaId, peso);
        }

        public List<DtoCandidatoPeso> ObterCandidatos(Guid id)
        {
            var listaCandidatoPeso = new List<DtoCandidatoPeso>();
            Selecao selecao = repository.ObterPorId(id);
            List<Candidato> candidatosParaVaga = candidatoRepository.ObterTodos().Where(w => w.OcupacaoId == selecao.OcupacaoId).ToList();

            foreach(var candidato in candidatosParaVaga)
            {
                var candidatoPeso = new DtoCandidatoPeso();
                candidatoPeso.IdCandidato = candidato.Id;
                candidatoPeso.Nome = candidato.Nome;

                var peso = 0;

                var prova = selecao.TecnologiaPesos.Where(w => candidato.Tecnologias.Any(a => a.Id == w.TecnologiaId)).Sum(s => s.Peso);

                foreach (var tecnologiaPeso in selecao.TecnologiaPesos)
                {
                    if (candidato.Tecnologias.Any(a => a.Id == tecnologiaPeso.TecnologiaId))
                        peso += tecnologiaPeso.Peso;
                }

                candidatoPeso.SomaPeso = peso;

                listaCandidatoPeso.Add(candidatoPeso);
            }

            return listaCandidatoPeso.OrderByDescending(o => o.SomaPeso).ToList();
        }

        public Selecao ObterPorId(Guid id)
        {
            return repository.ObterPorId(id);
        }

        public List<Selecao> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
