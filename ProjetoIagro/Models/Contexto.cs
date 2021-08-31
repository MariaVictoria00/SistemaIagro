using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Models
{
    public class Contexto: DbContext
    {
      
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Produtor> Produtor { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Propriedade> Propriedade { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<RegistroVacina> RegistroVacina { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<FinalidadeVenda> FinalidadeVenda { get; set; }
        public DbSet<Saldo> Saldo { get; set; }
        public DbSet<SaldoVacina> SaldoVacina { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {


        }
    }
}
