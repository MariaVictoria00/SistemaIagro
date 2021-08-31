using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoIagro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.ViewModel
{
    public class PropriedadeViewModel
    {
        [Key]
        public int NumeroInscricaoID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 40 letras.")]
        [RegularExpression("^[A-Za-zÀ-ú\\s]*$", ErrorMessage = "Adicione um nome válido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione um município")]
        public int Municipio { get; set; }

        [Required(ErrorMessage = "Selecione um produtor")]
        public int Produtor { get; set; }

        public SelectList Municipios { get; set; }
        public SelectList Produtores { get; set; }
    }
}
