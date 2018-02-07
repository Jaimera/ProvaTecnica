using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IService
{
    public interface ICandidatoService
    {
        List<Candidato> ObterTodos();
        Candidato ObterPorId(Guid id);
        Guid Adicionar(string nome, Guid ocupacaoId);
        Guid AdicionarTecnologias(Guid id, List<Guid> idsTecnologia);
        Candidato Atualizar(Guid id, string nome);
        bool Remove(Guid id);
    }
}
