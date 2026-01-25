using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IProductService productService, 
                                 ICategoryService categoryService, 
                                 IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _environment = environment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategories();
            categories = categories.Where(c => c.Disable == false);
            ViewData["Categories"] = new SelectList(categories,
                                                    "Id",
                                                    "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                                        .ToList();


                TempData["Error"] = string.Join("<br />", erros);

                var categories = await _categoryService.GetCategories();

                ViewData["Categories"] = new SelectList(categories,
                                                        "Id",
                                                        "Name");

                return View(productDTO);
            }

            try
            {
                await _productService.Add(productDTO);
                TempData["Success"] = "Produto cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productService.GetById(id);

            if (product is null)
            {
                ViewData["Error"] = "Não Produto Não Encontrado.";
                return View();
            }

            var categories = await _categoryService.GetCategories();

            ViewData["Categories"] = new SelectList(categories,
                                                    "Id",
                                                    "Name");

            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            var categories = await _categoryService.GetCategories();
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.Update(productDTO);
                    ViewData["Success"] = "Produto atualizado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {


                    ViewData["Categories"] = new SelectList(categories,
                                                            "Id",
                                                            "Name");
                    ViewData["Error"] = ex.Message;
                    return View(productDTO);
                }
            }
            else
            {
                ViewData["Categories"] = new SelectList(categories,
                                        "Id",
                                        "Name");

                var errors = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                ViewData["Error"] = string.Join("<br /> ", errors);
                return View(productDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                ViewData["Error"] = "Não localizado Produto com o id informado";
                return RedirectToAction(nameof(Index));
            }

            var productDto = await _productService.GetById(id);

            var wwwRoot = _environment.WebRootPath;
            var image = Path.Combine(wwwRoot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                ViewData["Error"] = "Id não informada";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await _productService.Delete(id);
                ViewData["Success"] = "Produto removido com sucesso";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
