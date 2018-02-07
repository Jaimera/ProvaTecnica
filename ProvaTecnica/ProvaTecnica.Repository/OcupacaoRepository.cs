using ProvaTecnica.IRepository;
using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Repository
{
    public class OcupacaoRepository : IOcupacaoRepository
    {
        private List<Ocupacao> Ocupacoes = new List<Ocupacao>();

        public Ocupacao ObterPorId(Guid id)
        {
            return Ocupacoes.FirstOrDefault(w => w.Id == id);
        }

        public List<Ocupacao> ObterTodos()
        {
            return Ocupacoes;
        }

        public Guid Adicionar(string nome)
        {
            var ocupacao = new Ocupacao();
            ocupacao.Id = Guid.NewGuid();
            ocupacao.Nome = nome;
            Ocupacoes.Add(ocupacao);

            return ocupacao.Id;
        }

        public Ocupacao Atualizar(Guid id, string nome)
        {
            var ocupacao = Ocupacoes.First(w => w.Id == id);

            ocupacao.Nome = nome;

            return ocupacao;
        }

        public bool Remover(Guid id)
        {
            Ocupacoes.RemoveAll(r => r.Id == id);
            return true;
        }
    }
}
