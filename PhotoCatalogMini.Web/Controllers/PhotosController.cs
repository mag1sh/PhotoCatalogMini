using Microsoft.AspNetCore.Mvc;
using PhotoCatalogMini.Data;
using PhotoCatalogMini.Services.Contracts;
using PhotoCatalogMini.Services.DTOs.Photos;
using PhotoCatalogMini.Web.ViewModels.Photos;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Web.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PhotoIndexViewModel
            {
                Photos = await _photoService.GetAll()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePhotoViewModel model)
        {
            var categories = (model.Categories ?? string.Empty)
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if(categories.Count == 0)
            {
                ModelState.AddModelError(nameof(model.Categories), "Въведи поне една категория");
            }
            else if(categories.Any(c => c.Length > 50))
            {
                ModelState.AddModelError(nameof(model.Categories), "Категориите трябва да са между 3 и 20 символа");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new CreatePhotoDto
            {
                Title = model.Title.Trim(),
                PhotographerName = model.PhotographerName.Trim(),
                Categories = categories,
                Location = model.Location.Trim(),
                Description = model.Description.Trim()
            };

            await _photoService.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}