using Farmax.Data;
using Farmax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farmax.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly AppCont _appCont;

        public FornecedorController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allFornecedores = _appCont.fornecedores.ToList();
            return View(allFornecedores);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var fornecedor = await _appCont.fornecedores.FirstOrDefaultAsync(m => m.Id == id);

            if (fornecedor == null)
                return NotFound();

            return PartialView(fornecedor);
        }

        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, Fantasia, Cnpj, Telefone")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(fornecedor);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(fornecedor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var fornecedor = await _appCont.fornecedores.FindAsync(id);

            if (fornecedor == null)
                return NotFound();

            return PartialView(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome, Fantasia, Cnpj, Telefone")] Fornecedor fornecedor)
        {
            if (id == fornecedor.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(fornecedor);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var fornecedor = await _appCont.fornecedores.FirstOrDefaultAsync(m => m.Id == id);

            if (fornecedor == null)
                return NotFound();

            return PartialView(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _appCont.fornecedores.FindAsync(id);
            _appCont.fornecedores.Remove(fornecedor);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _appCont.fornecedores.Any(e => e.Id == id);
        }
    }
}
