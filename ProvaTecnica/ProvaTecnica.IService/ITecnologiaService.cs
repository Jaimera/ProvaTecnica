using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IService
{
    public interface ITecnologiaService
    {
        List<Tecnologia> ObterTodos();
        Tecnologia ObterPorId(Guid id);
        Guid Adicionar(string nome);
        Tecnologia Atualizar(Guid id, string nome);
        bool Remove(Guid id);
    }
}
