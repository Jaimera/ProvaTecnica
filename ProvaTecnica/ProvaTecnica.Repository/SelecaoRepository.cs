using ProvaTecnica.Model;
using ProvaTecnica.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Repository
{
    public class SelecaoRepository : ISelecaoRepository
    {
        private List<Selecao> Selecoes;

        public SelecaoRepository()
        {
            Selecoes = new List<Selecao>();
        }

        public Guid Adicionar(Guid ocupacaoId)
        {
            var selecao = new Selecao();
            selecao.Id = Guid.NewGuid();
            selecao.OcupacaoId = ocupacaoId;
            selecao.TecnologiaPesos = new List<TecnologiaPeso>();
            Selecoes.Add(selecao);

            return selecao.Id;
        }

        public Selecao ObterPorId(Guid id)
        {
            return Selecoes.First(f => f.Id == id);
        }

        public Guid AdicionarPeso(Guid id, Guid tecnologiaId, int peso)
        {
            var selecao = Selecoes.First(f => f.Id == id);
            var tecnologiaPeso = new TecnologiaPeso();

            tecnologiaPeso.Id = Guid.NewGuid();
            tecnologiaPeso.TecnologiaId = tecnologiaId;
            tecnologiaPeso.Peso = peso;

            lock (selecao.TecnologiaPesos)
            {
                selecao.TecnologiaPesos.Add(tecnologiaPeso);
            }

            return tecnologiaPeso.Id;
        }
    }
}
