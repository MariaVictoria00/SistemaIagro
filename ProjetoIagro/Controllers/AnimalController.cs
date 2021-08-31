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
    public class AnimalController : Controller
    {
        private readonly Contexto contexto;
        private Contexto _contexto;
        public AnimalController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Animal.ToListAsync());
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var animalViewModel = new AnimalViewModel { Especies = new SelectList(especies, "EspecieID", "Descricao"), Propriedades = new SelectList(propriedades,"NumeroInscricaoID", "Nome") };
            return View(animalViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(AnimalViewModel animalViewModel)
        {
 
            if (ModelState.IsValid)
            {
                var animal = new Animal
                {
                    Quantidade = animalViewModel.Quantidade,
                    Especie = animalViewModel.Especie,
                    Propriedade = animalViewModel.Propriedade,
                };

                _contexto.Add(animal);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            animalViewModel.Especies = new SelectList(especies, "EspecieID", "Descricao");
            animalViewModel.Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome");
            return View(animalViewModel);

        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id != null)
            {
                var especies = _contexto.Especie.ToList();
                var propriedades = _contexto.Propriedade.ToList();
                var animal = _contexto.Animal.Find(id);
                var animalViewModel = new AnimalViewModel
                {
                    Quantidade = animal.Quantidade,
                    Especie = animal.Especie,
                    Propriedade = animal.Propriedade,

                    Especies = new SelectList(especies, "EspecieID", "Descricao"),
                    Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome")
                };

                return View(animalViewModel);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, AnimalViewModel animalViewModel)
        {

            if (id != null)
            {
                var animal = _contexto.Animal.FirstOrDefault(x => x.AnimalID == id);
                animal.Quantidade = animalViewModel.Quantidade;
                animal.Especie = animalViewModel.Especie;
                animal.Propriedade = animalViewModel.Propriedade;
             
                _contexto.Update(animal);

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            animalViewModel.Especies = new SelectList(especies, "EspecieID", "Descricao");
            animalViewModel.Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome");
            return View(animalViewModel);

        }


        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id != null)
            {
                Animal animal = _contexto.Animal.Find(id);
                return View(animal);
            }
                return NotFound();
        }
    }
}
