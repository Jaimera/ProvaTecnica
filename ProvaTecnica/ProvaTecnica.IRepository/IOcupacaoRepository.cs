using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IRepository
{
    public interface IOcupacaoRepository
    {
        Ocupacao ObterPorId(Guid id);
        List<Ocupacao> ObterTodos();
        Guid Adicionar(string nome);
        Ocupacao Atualizar(Guid id, string nome);
        bool Remover(Guid id);
    }
}
