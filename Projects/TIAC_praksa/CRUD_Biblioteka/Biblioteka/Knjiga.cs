using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Knjiga : Generalizacija
    {
        public string Autor { get; set; }
        public int ISBN { get; set; }
        public int Godina { get; set; }
        public string Izdavac { get; set; }
        public Knjiga() { }

        public override string ToString()
        {
            //return "Knjiga [Autor =" + Autor;
            return base.ToString();
        }
    }
}
