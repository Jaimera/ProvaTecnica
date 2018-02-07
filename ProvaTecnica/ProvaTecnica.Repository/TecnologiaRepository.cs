using ProvaTecnica.IRepository;
using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Repository
{
    public class TecnologiaRepository : ITecnologiaRepository
    {
        private List<Tecnologia> Tecnologias;

        public TecnologiaRepository() {
            Tecnologias = new List<Tecnologia>();
        }
        
        public Tecnologia ObterPorId(Guid id)
        {
            return Tecnologias.FirstOrDefault(w => w.Id == id);
        }

        public List<Tecnologia> ObterTecnologias()
        {
            return Tecnologias;
        }

        public Guid AdicionarTecnologia(string nome)
        {
            var tecnologia = new Tecnologia();
            tecnologia.Id = Guid.NewGuid();
            tecnologia.Nome = nome;
            
            Tecnologias.Add(tecnologia);

            return tecnologia.Id;
        }

        public Tecnologia AtualizarTecnologia(Guid id, string nome)
        {
            var tec = Tecnologias.First(w => w.Id == id);

            tec.Nome = nome;

            return tec;
        }

        public bool RemoverTecnologia(Guid id)
        {
            Tecnologias.RemoveAll(r => r.Id == id);
            return true;
        }
    }
}
