using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIagro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIagro.Controllers
{
    public class ProdutorController : Controller
    {
     
        private readonly Contexto contexto;
        private Contexto _contexto;
        public ProdutorController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Produtor.ToListAsync());
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(Produtor produtor)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(produtor);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            else
            {
                return View(produtor);
            }
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id != null)
            {
                Produtor produtor = _contexto.Produtor.Find(id);
                return View(produtor);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, Produtor produtor)
        {
            if (id != null)
            {
                _contexto.Update(produtor);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(produtor);
            }
        }


        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id != null)
            {
                Produtor produtor = _contexto.Produtor.Find(id);
                return View(produtor);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
