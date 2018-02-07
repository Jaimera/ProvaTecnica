using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Dto
{
    public class DtoCandidatoPeso
    {
        public Guid IdCandidato { get; set; }
        public string Nome { get; set; }
        public int SomaPeso { get; set; }
    }
}
