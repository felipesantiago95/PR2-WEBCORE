using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Controllers
{
    public class EstablecimientoController : Controller
    {
        private readonly IEstablecimientoService _establecimientoService;

        public EstablecimientoController(IEstablecimientoService establecimientoService)
        {
            _establecimientoService = establecimientoService;
        }

        // GET: Establecimiento
        public async Task<IActionResult> Index()
        {
            var establecimientos = await _establecimientoService.GetAllEstablecimientos();
            return View(establecimientos);
        }

        // GET: Establecimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establecimiento = await _establecimientoService.GetEstablecimientoById(id.Value);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // GET: Establecimiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Establecimiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ruc,Direccion,Telefono,RazonSocial,RepresentanteLegal,Ciudad,Pais")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                await _establecimientoService.CreateEstablecimiento(establecimiento);
                return RedirectToAction(nameof(Index));
            }
            return View(establecimiento);
        }

        // GET: Establecimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establecimiento = await _establecimientoService.GetEstablecimientoById(id.Value);
            if (establecimiento == null)
            {
                return NotFound();
            }
            return View(establecimiento);
        }

        // POST: Establecimiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstablecimiento,Ruc,Direccion,Telefono,RazonSocial,RepresentanteLegal,Ciudad,Pais")] Establecimiento establecimiento)
        {
            if (id != establecimiento.IdEstablecimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _establecimientoService.UpdateEstablecimiento(establecimiento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _establecimientoService.EstablecimientoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(establecimiento);
        }

        // GET: Establecimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establecimiento = await _establecimientoService.GetEstablecimientoById(id.Value);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // POST: Establecimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _establecimientoService.DeleteEstablecimiento(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
