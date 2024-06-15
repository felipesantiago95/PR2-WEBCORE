using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Controllers
{
    public class ClaseController : Controller
    {
        private readonly IngwebCoreContext _context;

        public ClaseController(IngwebCoreContext context)
        {
            _context = context;
        }

        // GET: Clase
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clases.ToListAsync());
        }

        // GET: Clase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .FirstOrDefaultAsync(m => m.IdClase == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClase,Descripcion,Porcentaje")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clase);
        }

        // GET: Clase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            return View(clase);
        }

        // POST: Clase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClase,Descripcion,Porcentaje")] Clase clase)
        {
            if (id != clase.IdClase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseExists(clase.IdClase))
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
            return View(clase);
        }

        // GET: Clase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .FirstOrDefaultAsync(m => m.IdClase == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // POST: Clase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.IdClase == id);
        }
    }
}
