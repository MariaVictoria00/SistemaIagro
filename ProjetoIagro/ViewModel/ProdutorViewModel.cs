using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoIagro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.ViewModel
{
    public class ProdutorViewModel
    {
        [Key]
        public int ProdutorID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 40 letras.")]
        [RegularExpression("^[A-Za-zÀ-ú\\s]*$", ErrorMessage = "Adicione um nome válido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatorio")]
        [RegularExpression("[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}", ErrorMessage = "Adicione um CPF válido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatorio")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "O endereço deve ter entre 10 e 40 letras.")]
        public string Rua { get; set; }


        [Required(ErrorMessage = "O número da propriedade é obrigatorio")]
        [RegularExpression("[0-9]{1,6}", ErrorMessage = "Adicione até 6 números")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Selecione um município")]
        public int Municipio { get; set; }

        public SelectList Municipios { get; set; }
    }
}
