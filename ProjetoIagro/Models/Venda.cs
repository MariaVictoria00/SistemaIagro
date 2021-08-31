using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Venda
    {
        [Key]
        public int VendaID { get; set; }
        public int PropriedadeOrigem { get; set; }
        public int PropriedadeDestino { get; set; }
        public int Especie { get; set; }
        public int FinalidadeVenda { get; set; }
        public int Quantidade { get; set; }
    }
}
