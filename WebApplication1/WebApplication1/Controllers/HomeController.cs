using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly PersistenceUsers _persistenUsers;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _persistenUsers = new PersistenceUsers();
        }

        public IActionResult Index() => View();

        public IActionResult Puntos() => View();

        [HttpPost]
        public ActionResult Save(ModelUsers usuarios)
        {
            _persistenUsers.Guardar(usuarios);
            return RedirectToAction("UsuariosRegistrados", "Home");
        }

        public IActionResult UsuariosRegistrados()
        {
            return View(_persistenUsers.Cargar());
        }

        public IActionResult putPuntos(int identificacion, int puntos)
        {
            _persistenUsers.putPuntosIdentificacion(identificacion, puntos);
            return RedirectToAction("UsuariosRegistrados", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
