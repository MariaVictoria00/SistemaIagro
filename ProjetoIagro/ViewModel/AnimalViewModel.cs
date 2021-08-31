
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoIagro.Models;

namespace ProjetoIagro.ViewModel
{
    public class AnimalViewModel
    {
        [Key]
        public int AnimalID { get; set; }

        [Required(ErrorMessage = "Adicione uma quantidade")]
        public int Quantidade { get; set; }
        public int Especie { get; set; }
        public int Propriedade { get; set; }

        public SelectList Especies { get; set; }

        public SelectList Propriedades { get; set; }
    }
}
