using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Saldo
    {
       [Key]
       public int SaldoId { get; set; }
       public int Propriedade { get; set; }
       public int Especie { get; set; }
       public int Quantidade { get; set; }

    }
}
