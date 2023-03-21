using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Model
{
    public class Cont
    {
        public int ID_Cont { set; get; } 
        public string Numar { set; get; }

        public int ID_Abonament { set; get; }
        public int ID_Abonat { set; get; }

        public string DataContractare { set; get; }

        public int Balansa { set; get; }
        public string Locatie { set; get; }



    }
}
