using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Produtor
    {

        public Int32 ProdutorID { get; set; }
        public String Nome { get; set; }
        public String CPF { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public Int32 Municipio { get; set; }
    }
}
