using ProvaTecnica.Dto;
using ProvaTecnica.Model;
using System;
using System.Collections.Generic;

namespace ProvaTecnica.IService
{
    public interface ISelecaoService
    {
        List<Selecao> ObterTodos();
        Selecao ObterPorId(Guid id);
        Guid Adicionar(Guid ocupacaoId);
        Guid AdicionarPeso(Guid id, Guid tecnologiaId, int peso);
        List<DtoCandidatoPeso> ObterCandidatos(Guid id);
    }
}
