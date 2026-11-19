using Microsoft.AspNetCore.Mvc;
using PhotoCatalogMini.Data;

namespace PhotoCatalogMini.Web.Controllers
{
    public class PhotosController : Controller
    {
        private readonly PhotoCatalogDbContext _dbContext;

        public PhotosController(PhotoCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var photos = _dbContext.Photos.OrderBy(p => p.Title).ToList();
            return View(photos);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
