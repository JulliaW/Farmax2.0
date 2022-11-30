using Farmax.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
