using PhotoCatalogMini.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Data
{
    public class DemoData
    {
        public static void Seed(PhotoCatalogDbContext db)
        {
            if (db.Photos.Any())
            {
                return;
            }

            var photographer = db.Photographers.FirstOrDefault(p => p.Name == "Иван Петров");
            if (photographer is null)
            {
                photographer = new Photographer
                {
                    PhotographerId = Guid.NewGuid(),
                    Name = "Иван Петров"
                };
                db.Photographers.Add(photographer);
            }

            var category = db.Categories.FirstOrDefault(c => c.Name == "Пейзаж");
            if (category is null)
            {
                category = new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = "Пейзаж"
                };
                db.Categories.Add(category);
            }

            var photo = new Photo
            {
                PhotoId = Guid.NewGuid(),
                Title = "Утро над езерото",
                Location = "Рила",
                Description = "Мъгла над планинско езеро призори.",
                PhotographerId = photographer.PhotographerId,
                Photographer = photographer,
            };

            photo.PhotoCategories.Add(new PhotoCategory
            {
                PhotoId = photo.PhotoId,
                CategoryId = category.CategoryId,
                Category = category
            });

            db.Photos.Add(photo);
            db.SaveChanges();
        }
    }
}
