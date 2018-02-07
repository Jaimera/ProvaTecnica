using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IService
{
    public interface IOcupacaoService
    {
        List<Ocupacao> ObterTodos();
        Ocupacao ObterPorId(Guid id);
        Guid Adicionar(string nome);
        Ocupacao Atualizar(Guid id, string nome);
        bool Remove(Guid id);
    }
}
