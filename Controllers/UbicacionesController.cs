using Microsoft.AspNetCore.Mvc;
using PokemonPC3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokemonPC3.Controllers
{
    public class UbicacionesController : Controller
    {
        private readonly PokemonContext _context;
        public UbicacionesController(PokemonContext context) {
            _context = context;
        }

        public IActionResult Regiones() {
            var regiones = _context.Regiones.Include(x => x.Pueblos).OrderBy(r => r.Nombre).ToList();
            return View(regiones);
        }

        public IActionResult Pueblos() {
            var pueblos = _context.Pueblos.Include(x => x.Region).OrderBy(r => r.Nombre).ToList();
            return View(pueblos);
        }

        public IActionResult Entrenadores() {
            var entrenadores = _context.Entrenadores.Include(x => x.Pueblo).OrderBy(r => r.Nombre).ToList();
            return View(entrenadores);
        }

        public IActionResult NuevoPueblo() {
            ViewBag.Regiones = _context.Regiones.ToList().Select(r => new SelectListItem(r.Nombre, r.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult NuevoPueblo(Pueblo r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevoPuebloConfirmacion");
            }
            return View(r);
        }

        public IActionResult NuevoPuebloConfirmacion() {
            return View();
        }

        public IActionResult NuevaRegion() {
            return View();
        }

        [HttpPost]
        public IActionResult NuevaRegion(Region r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevaRegionConfirmacion");
            }
            return View(r);
        }

        public IActionResult NuevaRegionConfirmacion() {
            return View();
        }

        [HttpPost]
        public IActionResult BorrarRegion(int id) {
            var region = _context.Regiones.Find(id);
            _context.Remove(region);
            _context.SaveChanges();

            return RedirectToAction("Regiones");
        }

        public IActionResult EditarRegion(int id) {
            var region = _context.Regiones.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult EditarRegion(Region r) {
            if (ModelState.IsValid) {
                var region = _context.Regiones.Find(r.Id);
                region.Nombre = r.Nombre;
                _context.SaveChanges();
                return RedirectToAction("EditarRegionConfirmacion");
            }
            return View(r);
        }

        public IActionResult EditarRegionConfirmacion() {
            return View();
        }


        public IActionResult NuevoEntrenador() {
            ViewBag.Pueblos = _context.Pueblos.ToList().Select(r => new SelectListItem(r.Nombre, r.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult NuevoEntrenador(Entrenador r) {
            if (ModelState.IsValid) {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevoEntrenadorConfirmacion");
            }
            return View(r);
        }

        public IActionResult NuevoEntrenadorConfirmacion() {
            return View();
        }
    }
}