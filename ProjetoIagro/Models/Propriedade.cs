using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Propriedade
    {
        [Key]
        public int NumeroInscricaoID { get; set; }
        public string Nome { get; set; }
        public int Municipio { get; set; }
        public int Produtor { get; set; }
    }
}
