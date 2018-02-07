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
    public class OcupacaoService : IOcupacaoService
    {
        private readonly IOcupacaoRepository ocupacaoRepository;

        public OcupacaoService(IOcupacaoRepository _ocupacaoRepository)
        {
            ocupacaoRepository = _ocupacaoRepository;
        }

        public Guid Adicionar(string nome)
        {
            return ocupacaoRepository.Adicionar(nome);
        }

        public Ocupacao Atualizar(Guid id, string nome)
        {
            return ocupacaoRepository.Atualizar(id, nome);
        }

        public Ocupacao ObterPorId(Guid id)
        {
            return ocupacaoRepository.ObterPorId(id);
        }

        public List<Ocupacao> ObterTodos()
        {
            return ocupacaoRepository.ObterTodos();
        }

        public bool Remove(Guid id)
        {
            return ocupacaoRepository.Remover(id);
        }
    }
}
