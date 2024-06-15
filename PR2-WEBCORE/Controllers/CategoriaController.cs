using Microsoft.AspNetCore.Mvc;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categorium categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.SaveCategoriaAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categorium categoria)
        {
            if (id != categoria.IdCagegoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaService.UpdateCategoriaAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaService.DeleteCategoriaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
