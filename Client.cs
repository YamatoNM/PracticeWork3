using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Model
{
    public class Client
    {
        public int Id_A { get; set; }
        public int Id_C { get; set; }
        public string nume { get; set; }
        public string adresa { get; set; }
        public string IDNP { get; set; }
        public int  tipClient{get; set;}
        public int numar{get; set;}

        public int abanament { get; set;}

        public int balansa { get; set; }
        public string locatie { get; set; }
    }
}
