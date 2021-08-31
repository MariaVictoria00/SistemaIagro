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
    public class VendaController : Controller
    {

        private readonly Contexto contexto;
        private Contexto _contexto;

        public VendaController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Venda.ToListAsync());
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var finalidadeVenda = _contexto.FinalidadeVenda.ToList();
            var vendaViewModel = new VendaViewModel
            {
                Especies = new SelectList(especies, "EspecieID", "Descricao"),
                Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome"),
                FinalidadesVendas = new SelectList(finalidadeVenda, "FinalidadeVendaID", "Descricao")
            };
            return View(vendaViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Incluir(VendaViewModel vendaViewModel)
        {

            if (ModelState.IsValid)
            {
                var venda = new Venda
                {
                    Especie = vendaViewModel.Especie,
                    PropriedadeOrigem = vendaViewModel.PropriedadeOrigem,
                    PropriedadeDestino = vendaViewModel.PropriedadeDestino,
                    FinalidadeVenda = vendaViewModel.FinalidadeVenda,
                    Quantidade = vendaViewModel.Quantidade,
                   
                };

                _contexto.Add(venda);
                var saldoOrigem = _contexto.Saldo.Where(x => x.Propriedade == vendaViewModel.PropriedadeOrigem &&
                x.Especie == vendaViewModel.Especie).FirstOrDefault();

                if (saldoOrigem == null)
                {
                    saldoOrigem = new Saldo
                    {
                        Propriedade = vendaViewModel.PropriedadeOrigem,
                        Especie = vendaViewModel.Especie,
                        Quantidade = vendaViewModel.Quantidade
                    };

                    _contexto.Add(saldoOrigem);
                }
                else
                {
                    saldoOrigem.Quantidade += vendaViewModel.Quantidade;
                }

                var saldoDestino = _contexto.Saldo.Where(x => x.Propriedade == vendaViewModel.PropriedadeDestino &&
                x.Especie == vendaViewModel.Especie).FirstOrDefault();

                if (saldoDestino == null)
                {
                    saldoDestino = new Saldo
                    {
                        Propriedade = vendaViewModel.PropriedadeDestino,
                        Especie = vendaViewModel.Especie,
                        Quantidade = vendaViewModel.Quantidade
                    };

                    _contexto.Add(saldoDestino);
                }
                else
                {
                    saldoDestino.Quantidade += vendaViewModel.Quantidade;
                }



                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var finalidadeVendas = _contexto.FinalidadeVenda.ToList();
            vendaViewModel.Especies = new SelectList(especies, "EspecieID", "Descricao");
            vendaViewModel.Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome");
            vendaViewModel.FinalidadesVendas = new SelectList(finalidadeVendas, "FinalidadeVendaID", "Descricao");
            return View(vendaViewModel);

        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id != null)
            {
                var especies = _contexto.Especie.ToList();
                var propriedades = _contexto.Propriedade.ToList();
                var finalidadeVendas = _contexto.FinalidadeVenda.ToList();
                var venda = _contexto.Venda.Find(id);
                var vendaViewModel = new VendaViewModel
                {
                    Especie = venda.Especie,
                    PropriedadeOrigem = venda.PropriedadeOrigem,
                    PropriedadeDestino = venda.PropriedadeDestino,
                    FinalidadeVenda = venda.FinalidadeVenda,
                    Quantidade = venda.Quantidade,
                   

                    Especies = new SelectList(especies, "EspecieID", "Descricao"),
                    Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome"),
                    FinalidadesVendas = new SelectList(finalidadeVendas, "FinalidadeVendaID", "Descricao")
                };

                return View(vendaViewModel);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, VendaViewModel vendaViewModel)
        {

            if (id != null)
            {
                var venda = _contexto.Venda.FirstOrDefault(x => x.VendaID == id);
                venda.Especie = vendaViewModel.Especie;
                venda.PropriedadeOrigem= vendaViewModel.PropriedadeOrigem;
              
                venda.FinalidadeVenda = vendaViewModel.FinalidadeVenda;

                _contexto.Update(venda);

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var especies = _contexto.Especie.ToList();
            var propriedades = _contexto.Propriedade.ToList();
            var finalidadeVendas = _contexto.FinalidadeVenda.ToList();
            vendaViewModel.Especies = new SelectList(especies, "EspecieID", "Descricao");
            vendaViewModel.Propriedades = new SelectList(propriedades, "NumeroInscricaoID", "Nome");
            vendaViewModel.FinalidadesVendas = new SelectList(finalidadeVendas, "FinalidadeVendaID", "Descricao");
            return View(vendaViewModel);

        }

        [HttpGet]
        public IActionResult Detalhe(int? id)
        {
            if (id != null)
            {
                Venda venda = _contexto.Venda.Find(id);
                return View(venda);
            }

            return NotFound();
        }
    }
}
