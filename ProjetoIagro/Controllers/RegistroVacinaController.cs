using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIagro.Models;
using ProjetoIagro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Controllers
{
    public class RegistroVacinaController : Controller
    {
        private readonly Contexto contexto;
        private Contexto _contexto;
        public RegistroVacinaController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.RegistroVacina.ToListAsync());
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var vacinas = _contexto.Vacina.ToList();
            var registroVacinaViewModel = new RegistroVacinaViewModel { Especies = new SelectList(especies, "EspecieID", "Descricao"), 
                Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome"), Vacinas = new SelectList(vacinas, "VacinaID", "Nome") };
            return View(registroVacinaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(RegistroVacinaViewModel registroVacinaViewModel)
        {

            if (ModelState.IsValid)
            {
                
                var registroVacina = new RegistroVacina
                {
                    Especie = registroVacinaViewModel.Especie,
                    Propriedade = registroVacinaViewModel.Propriedade,
                    Vacina = registroVacinaViewModel.Vacina,
                    Quantidade = registroVacinaViewModel.Quantidade,
                    DataVacina = registroVacinaViewModel.DataVacina
                };

                _contexto.Add(registroVacina);
                //encontra o saldo da vacina da especie da vacina
                var saldoVacina = _contexto.SaldoVacina.Where(x => x.Propriedade == registroVacinaViewModel.Propriedade && x.TipoVacina == registroVacinaViewModel.Vacina
                && x.Especie == registroVacinaViewModel.Especie).FirstOrDefault();

                if(saldoVacina == null)
                {
                    saldoVacina = new SaldoVacina
                    {
                        Especie = registroVacinaViewModel.Especie,
                        Propriedade = registroVacinaViewModel.Propriedade,
                        TipoVacina = registroVacinaViewModel.Vacina,
                        Quantidade = registroVacinaViewModel.Quantidade,
                    };

                    _contexto.Add(saldoVacina);
                }
                else
                {
                    saldoVacina.Quantidade += registroVacinaViewModel.Quantidade;
                }

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var vacinas = _contexto.Vacina.ToList();
            registroVacinaViewModel.Especies = new SelectList(especies, "EspecieID", "Descricao");
            registroVacinaViewModel.Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome");
            registroVacinaViewModel.Vacinas = new SelectList(vacinas, "VacinaID", "Nome");
            return View(registroVacinaViewModel);

        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id != null)
            {
                var especies = _contexto.Especie.ToList();
                var propriedades = _contexto.Propriedade.ToList();
                var vacinas = _contexto.Vacina.ToList();
                var registroVacina = _contexto.RegistroVacina.Find(id);
                var registroVacinaViewModel = new RegistroVacinaViewModel
                {
                    Especie = registroVacina.Especie,
                    Propriedade = registroVacina.Propriedade,
                    Vacina = registroVacina.Vacina,
                    Quantidade = registroVacina.Quantidade,
                    DataVacina = registroVacina.DataVacina,

                    Especies = new SelectList(especies, "EspecieID", "Descricao"),
                    Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome"),
                    Vacinas = new SelectList(vacinas, "VacinaID", "Nome")
                };

                return View(registroVacinaViewModel);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, RegistroVacinaViewModel registroVacinaViewModel)
        {

            if (id != null)
            {
                var registroVacina = _contexto.RegistroVacina.FirstOrDefault(x => x.RegistroVacinaID == id);
                registroVacina.Especie = registroVacinaViewModel.Especie;
                registroVacina.Propriedade = registroVacinaViewModel.Propriedade;
                registroVacina.Vacina = registroVacinaViewModel.Vacina;

                _contexto.Update(registroVacina);

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var vacinas = _contexto.Vacina.ToList();
            registroVacinaViewModel.Especies = new SelectList(especies, "EspecieID", "Descricao");
            registroVacinaViewModel.Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome");
            registroVacinaViewModel.Vacinas = new SelectList(vacinas, "VacinaID", "Nome");
            return View(registroVacinaViewModel);

        }


        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id != null)
            {
                RegistroVacina registroVacina = _contexto.RegistroVacina.Find(id);
                return View(registroVacina);
            }

                return NotFound();
        }

    }
}
