using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIagro.ViewModel
{
    public class RegistroVacinaViewModel
    {
        [Key]
        public int RegistroVacinaID { get; set; }
        public int Especie { get; set; }
        public int Propriedade { get; set; }
        public int Vacina { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVacina { get; set; }

        public SelectList Especies { get; set; }
        public SelectList Propriedades { get; set; }
        public SelectList Vacinas { get; set; }
    }
}
