using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Models.Enuns
{
    public class Armas
    {
    
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public int Dano { get; set; }
        public ClasseEnumArmas Classe { get; internal set; }
    }
}