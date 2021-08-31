using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Produtor
    {
        [Key]
        public int ProdutorID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public int Municipio { get; set; }
    }
}
