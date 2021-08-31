using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProjetoIagro.Models
{
    public class RegistroVacina
    {
        [Key]
        public int RegistroVacinaID { get; set; }
        public int Especie { get; set; }
        public int Propriedade { get; set; }
        public int Vacina { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVacina { get; set; }
    }
}
