using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Model
{
    public class Candidato
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid OcupacaoId { get; set; }
        public Ocupacao Ocupacao { get; set; }
        public List<Tecnologia> Tecnologias { get; set; }
    }
}
