﻿using Farmax.Data;
using Farmax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farmax.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppCont _appCont;

        public UsuarioController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allUsuarios = _appCont.usuarios.ToList();
            return View(allUsuarios);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = await _appCont.usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
                return NotFound();

            return PartialView(usuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome, Login, Senha, Nivel")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(usuario);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = await _appCont.usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            return PartialView(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, Login, Senha, Nivel")] Usuario usuario)
        {
            if (id == usuario.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(usuario);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = await _appCont.usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
                return NotFound();

            return PartialView(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _appCont.usuarios.FindAsync(id);
            _appCont.usuarios.Remove(usuario);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _appCont.usuarios.Any(e => e.Id == id);
        }
    }
}
