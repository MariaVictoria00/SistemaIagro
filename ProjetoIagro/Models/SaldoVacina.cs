using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class SaldoVacina
    {
        [Key]
        public int SaldoVacinaID { get; set; }
        public int Propriedade { get; set; }
        public int Especie { get; set; }
        public int TipoVacina { get; set; }
        public int Quantidade { get; set; }

    }
}
