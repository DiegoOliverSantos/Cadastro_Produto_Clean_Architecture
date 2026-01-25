using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(bool? desativado)
        {
            var categories = await _categoryService.GetCategories();

            if (desativado.HasValue)
            {
                categories = categories.Where(c => c.Disable == desativado.Value);

                if (desativado.Value)
                    TempData["disable"] = "active";
                else
                    TempData["active"] = "active";
            }
            else
            {
                TempData["all"] = "active";
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                TempData["Error"] = string.Join("|", errors);

                return View(categoryDTO);
            }

            await _categoryService.Add(categoryDTO);
            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == Guid.Empty)
            {
                TempData["Error"] = "Categoria não encontrada";
                return RedirectToAction(nameof(Index));
            }
            try
            {

                await _categoryService.Disable(id);
                TempData["Success"] = "Categoria Desativada com sucesso!";
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Active(Guid id)
        {

            if (id == Guid.Empty)
            {
                TempData["Error"] = "Categoria não encontrada";
                return RedirectToAction(nameof(Index));
            }
            try
            {

                await _categoryService.Active(id);
                TempData["Success"] = "Categoria Ativada com sucesso!";
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["Error"] = "Categoria não encontrada";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var category = await _categoryService.GetCategoryById(id);
                return View(category);

            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }



        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                TempData["Error"] = string.Join("|", errors);

                return View(categoryDTO);
            }
            try
            {
                await _categoryService.Update(categoryDTO);
                TempData["Success"] = "Categoria Editada com sucesso!";
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["Error"] = "Categoria não encontrada";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var category = await _categoryService.GetCategoryById(id);
                return View(category);

            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }

}
