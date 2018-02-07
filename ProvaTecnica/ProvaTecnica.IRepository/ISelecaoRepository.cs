using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IRepository
{
    public interface ISelecaoRepository
    {
        Guid Adicionar(Guid ocupacaoId);
        Guid AdicionarPeso(Guid id, Guid tecnologiaId, int peso);
        Selecao ObterPorId(Guid id);

    }
}
