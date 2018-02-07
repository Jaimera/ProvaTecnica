using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IRepository
{
    public interface ITecnologiaRepository
    {
        Tecnologia ObterPorId(Guid id);
        List<Tecnologia> ObterTecnologias();
        Guid AdicionarTecnologia(string nome);
        Tecnologia AtualizarTecnologia(Guid id, string nome);
        bool RemoverTecnologia(Guid id);
    }
}
