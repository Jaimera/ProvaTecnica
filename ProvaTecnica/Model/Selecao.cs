using ProvaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Model
{
    public class Selecao
    {
        public Guid Id { get; set; }
        public Guid OcupacaoId { get; set; }
        public List<TecnologiaPeso> TecnologiaPesos { get; set; }
    }
}
