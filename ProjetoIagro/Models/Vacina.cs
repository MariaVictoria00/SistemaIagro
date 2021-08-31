using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Vacina
    {
        [Key]
        public int VacinaID { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
