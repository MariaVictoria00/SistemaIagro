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
    public class PropriedadeController : Controller
    {
        private readonly Contexto contexto;
        private Contexto _contexto;

        public PropriedadeController(Contexto contexto)
        {

            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
           
            return View(await _contexto.Propriedade.ToListAsync());
        }


        [HttpGet]
        public ActionResult Incluir()
        {
            var municipios = _contexto.Municipio.ToList();
            var produtores = _contexto.Produtor.ToList();
            var propriedadeViewModel = new PropriedadeViewModel { Municipios = new SelectList(municipios, "MunicipioID", "Nome"), Produtores = new SelectList(produtores, "ProdutorID", "Nome") };
            return View(propriedadeViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> Incluir(PropriedadeViewModel propriedadeViewModel)
        {
            Validar(propriedadeViewModel);
            if (ModelState.IsValid)
            {
                var propriedade = new Propriedade
                {
                    Nome = propriedadeViewModel.Nome,
                    Municipio = propriedadeViewModel.Municipio,
                    Produtor = propriedadeViewModel.Produtor,
                };

                _contexto.Add(propriedade);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var municipios = _contexto.Municipio.ToList();
            var produtores = _contexto.Produtor.ToList();
            propriedadeViewModel.Municipios = new SelectList(municipios, "MunicipioID", "Nome");
            propriedadeViewModel.Produtores = new SelectList(produtores, "ProdutorID", "CPF");
            return View(propriedadeViewModel);

        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id != null)
            {
                var municipios = _contexto.Municipio.ToList();
                var produtores = _contexto.Produtor.ToList();
                var propriedade = _contexto.Propriedade.Find(id);
                var propriedadeViewModel = new PropriedadeViewModel
                {
                    Nome = propriedade.Nome,
                    Municipio = propriedade.Municipio,
                    Produtor = propriedade.Produtor,
                    Municipios = new SelectList(municipios, "MunicipioID", "Nome"),
                    Produtores = new SelectList(produtores, "ProdutorID", "CPF")
                };

                return View(propriedadeViewModel);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, PropriedadeViewModel propriedadefViewModel)
        {

            if (id != null)
            {
                var propriedade = _contexto.Propriedade.FirstOrDefault(x => x.NumeroInscricaoID == id);
                propriedade.Nome = propriedadefViewModel.Nome;
                propriedade.Municipio = propriedadefViewModel.Municipio;
                propriedade.Produtor = propriedadefViewModel.Produtor;


                _contexto.Update(propriedade);

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var municipios = _contexto.Municipio.ToList();
            var produtores = _contexto.Produtor.ToList();
            propriedadefViewModel.Municipios = new SelectList(municipios, "MunicipioID", "Nome");
            propriedadefViewModel.Produtores = new SelectList(produtores, "ProdutorID", "CPF");

            return View(propriedadefViewModel);

        }


        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id != null)
            {
                Propriedade propriedade = _contexto.Propriedade.Find(id);
                return View(propriedade);
            }

                return NotFound();
        }

        public void Validar(PropriedadeViewModel propriedadeViewModel)
        {

            //verificar se o cpf  ja existe no bd
            if (_contexto.Propriedade.Where(e => e.Nome.Equals(propriedadeViewModel.Nome)).Count() > 0)
            {
                ModelState.AddModelError("Nome", "Já existe uma propriedade com esse nome no sistema.");
            }
        }
    }
}
