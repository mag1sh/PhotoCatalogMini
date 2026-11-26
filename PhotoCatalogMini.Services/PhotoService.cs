using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoCatalogMini.Data;
using PhotoCatalogMini.Data.Entities;
using PhotoCatalogMini.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using PhotoCatalogMini.Services.DTOs.Photos;

namespace PhotoCatalogMini.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly PhotoCatalogDbContext _context;

        public PhotoService(PhotoCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhotoListDto>> GetAll()    
        {
            return await _context.Photos
                .OrderBy(p => p.Title)
                .Select(p => new PhotoListDto
                {
                    PhotoId = p.PhotoId,
                    Title = p.Title,
                    PhotographerName = p.Photographer.Name,
                    Categories = p.PhotoCategories.Select(pc => pc.Category.Name).ToList(),
                    Location = p.Location,
                    Description = p.Description
                })
                .ToListAsync();
        }
    }
}