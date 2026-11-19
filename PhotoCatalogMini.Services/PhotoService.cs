using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoCatalogMini.Data;
using PhotoCatalogMini.Data.Entities;
using PhotoCatalogMini.Services.Contracts;

namespace PhotoCatalogMini.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly PhotoCatalogDbContext _context;

        public PhotoService(PhotoCatalogDbContext context)
        {
            _context = context;
        }

        public List<Photo> GetAll()
        {
            return _context.Photos.OrderBy(p => p.Title).ToList();
        }
    }
}
