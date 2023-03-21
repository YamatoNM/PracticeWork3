using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Model
{
    public class Apeluri
    {
        public int ID_Apel { get; set; }
        public int ID_Abonat1 { get; set; }
        public int ID_Abonat2 { get; set; }

        public int Durata { get; set; }

        public string DataApel { get; set; }


    }
}
