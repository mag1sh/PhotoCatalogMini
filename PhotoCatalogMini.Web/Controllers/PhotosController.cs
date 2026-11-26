using Microsoft.AspNetCore.Mvc;
using PhotoCatalogMini.Data;
using PhotoCatalogMini.Services.Contracts;
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

        public IActionResult Create()
        {
            return View();
        }
    }
}