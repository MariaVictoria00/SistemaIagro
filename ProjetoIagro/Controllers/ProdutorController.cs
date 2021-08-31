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
            var municipios = _contexto.Municipio.ToList();
            var produtorViewModel = new ProdutorViewModel { Municipios = new SelectList(municipios, "MunicipioID", "Nome") };
            return View(produtorViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(ProdutorViewModel produtorViewModel)
        {
            Validar(produtorViewModel);
            if (ModelState.IsValid)
            {
                var produtor = new Produtor {
                    Nome = produtorViewModel.Nome,
                    CPF = produtorViewModel.CPF,
                    Rua = produtorViewModel.Rua,
                    Numero = produtorViewModel.Numero,
                    Municipio = produtorViewModel.Municipio,
                };

                _contexto.Add(produtor);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            var municipios = _contexto.Municipio.ToList();
            produtorViewModel.Municipios = new SelectList(municipios, "MunicipioID", "Nome");
            return View(produtorViewModel);

        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id != null)
            {
                var municipios = _contexto.Municipio.ToList();
                var produtor = _contexto.Produtor.Find(id);
                var produtorViewModel = new ProdutorViewModel
                {
                    Nome = produtor.Nome,
                    CPF = produtor.CPF,
                    Rua = produtor.Rua,
                    Numero = produtor.Numero,
                    Municipio = produtor.Municipio,
                    Municipios = new SelectList(municipios, "MunicipioID", "Nome")
            };

                return View(produtorViewModel);
            }
           
                return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, ProdutorViewModel produtorViewModel)
        {

            if (id != null)
            {
                var produtor = _contexto.Produtor.FirstOrDefault(x => x.ProdutorID== id);
                produtor.Nome = produtorViewModel.Nome;
                produtor.CPF = produtorViewModel.CPF;
                produtor.Rua = produtorViewModel.Rua;
                produtor.Numero = produtorViewModel.Numero;
                produtor.Municipio = produtorViewModel.Municipio;
                
                _contexto.Update(produtor);

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                var municipios = _contexto.Municipio.ToList();
                produtorViewModel.Municipios = new SelectList(municipios, "MunicipioID", "Nome");
            return View(produtorViewModel);
  
        }


        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id != null)
            {
                Produtor produtor = _contexto.Produtor.Find(id);
                return View(produtor);
            }

              return NotFound();
           
        }

        public void Validar(ProdutorViewModel novoProdutor)
        {

            //verificar se o cpf  ja existe no bd
            if (_contexto.Produtor.Where(e => e.CPF.Equals(novoProdutor.CPF)).Count() > 0)
            {
                ModelState.AddModelError("cpf", "O CPF já existe no sistema.");
            }
        }


    }
}
