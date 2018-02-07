using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.IRepository
{
    public interface ICandidatoRepository
    {
        Candidato ObterPorId(Guid id);
        List<Candidato> ObterTodos();
        Guid Adicionar(string nome, Ocupacao ocupacao);
        Guid AdicionarTecnologias(Guid id, List<Tecnologia> tecnologias);
        //Candidato Atualizar(Guid id, string nome);
        //bool Remover(Guid id);
    }
}
