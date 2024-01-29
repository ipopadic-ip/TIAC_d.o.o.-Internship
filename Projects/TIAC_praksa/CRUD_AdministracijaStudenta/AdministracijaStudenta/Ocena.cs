using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracijaStudenta
{
    class Ocena
    {
        public int IDPredmeta { get; set; }
        public int IDStudenta { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public int Ocena1 { get; set; }
    }
}
