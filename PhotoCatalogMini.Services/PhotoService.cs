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

        public async Task CreateAsync(CreatePhotoDto dto)
        {
            var photographer = await _context.Photographers
                .FirstOrDefaultAsync(p => p.Name == dto.PhotographerName);
            if (photographer is null)
            {
                photographer = new Photographer
                {
                    PhotographerId = Guid.NewGuid(),
                    Name = dto.PhotographerName
                };
                _context.Photographers.Add(photographer);
            }

            var photo = new Photo
            {
                PhotoId = Guid.NewGuid(),
                Title = dto.Title,
                Location = dto.Location,
                Description = dto.Description,
                PhotographerId = photographer.PhotographerId,
                Photographer = photographer
            };

            foreach (var name in dto.Categories)
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Name == name);
                if (category is null)
                {
                    category = new Category
                    {
                        CategoryId = Guid.NewGuid(),
                        Name = name
                    };
                    _context.Categories.Add(category);
                }
                photo.PhotoCategories.Add(new PhotoCategory
                {
                    PhotoId = photo.PhotoId,
                    CategoryId = category.CategoryId,
                    Category = category
                });
            }
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }
    }
}