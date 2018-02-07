using ProvaTecnica.IRepository;
using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Repository
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private List<Candidato> Candidatos;

        public CandidatoRepository()
        {
            Candidatos = new List<Candidato>();
        }

        public Guid Adicionar(string nome, Ocupacao ocupacao)
        {
            var candidato = new Candidato();
            candidato.Id = Guid.NewGuid();
            candidato.Nome = nome;
            candidato.OcupacaoId = ocupacao.Id;
            candidato.Ocupacao = ocupacao;
            Candidatos.Add(candidato);

            return candidato.Id;
        }

        public Guid AdicionarTecnologias(Guid id, List<Tecnologia> tecnologias)
        {
            var candidato = Candidatos.First(f => f.Id == id);
            candidato.Tecnologias = new List<Tecnologia>(tecnologias);

            return candidato.Id;
        }

        public Candidato ObterPorId(Guid id)
        {
            var candidato = Candidatos.First(f => f.Id == id);

            return candidato;
        }

        public List<Candidato> ObterTodos()
        {
            return Candidatos;
        }
    }
}
