using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set;}
        public int Quantidade { get; set;}
        public int Especie { get; set;}
        public int Propriedade { get; set; }

    }
}
