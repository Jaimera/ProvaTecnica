using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Model
{
    public class TecnologiaPeso
    {
        public Guid Id { get; set; }
        public Guid TecnologiaId { get; set; }
        public int Peso { get; set; }
    }
}
