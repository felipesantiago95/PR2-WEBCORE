using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Controllers
{
    public class AforoController : Controller
    {
        private readonly IAforoService _aforoService;

        public AforoController(IAforoService aforoService)
        {
            _aforoService = aforoService;
        }

        // GET: Aforo
        public async Task<IActionResult> Index()
        {
            var aforos = await _aforoService.GetAllAforos();
            return View(aforos);
        }

        // GET: Aforo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aforo = await _aforoService.GetAforoById(id.Value);
            if (aforo == null)
            {
                return NotFound();
            }

            return View(aforo);
        }

        // GET: Aforo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aforo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion,Porcentaje")] Aforo aforo)
        {
            if (ModelState.IsValid)
            {
                await _aforoService.CreateAforo(aforo);
                return RedirectToAction(nameof(Index));
            }
            return View(aforo);
        }

        // GET: Aforo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aforo = await _aforoService.GetAforoById(id.Value);
            if (aforo == null)
            {
                return NotFound();
            }
            return View(aforo);
        }

        // POST: Aforo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAforo,Descripcion,Porcentaje")] Aforo aforo)
        {
            if (id != aforo.IdAforo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _aforoService.UpdateAforo(aforo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _aforoService.AforoExists(id))
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
            return View(aforo);
        }

        // GET: Aforo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aforo = await _aforoService.GetAforoById(id.Value);
            if (aforo == null)
            {
                return NotFound();
            }

            return View(aforo);
        }

        // POST: Aforo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _aforoService.DeleteAforo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
