using Farmax.Data;
using Farmax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farmax.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppCont _appCont;

        public ProdutoController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allProdutos = _appCont.produtos.ToList();
            return View(allProdutos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _appCont.produtos.FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
                return NotFound();

            return PartialView(produto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao, Quantidade, Preco, Fornecedor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(produto);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _appCont.produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            return PartialView(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao, Quantidade, Preco, Fornecedor")] Produto produto)
        {
            if (id == produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(produto);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _appCont.produtos.FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
                return NotFound();

            return PartialView(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _appCont.produtos.FindAsync(id);
            _appCont.produtos.Remove(produto);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _appCont.produtos.Any(e => e.Id == id);
        }
    }
}
