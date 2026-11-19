using Microsoft.AspNetCore.Mvc;
using PhotoCatalogMini.Data;
using PhotoCatalogMini.Services.Contracts;

namespace PhotoCatalogMini.Web.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            var photos = _photoService.GetAll();
            return View(photos);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
