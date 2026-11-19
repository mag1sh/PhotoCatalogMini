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

            var photo = new Photo
            {
                PhotoId = Guid.NewGuid(),
                Title = "Утро над езерото",
                Photographer = "Иван Петров",
                Category = "Пейзаж",
                Location = "Рила",
                Description = "Мъгла над планинско езеро призори."
            };

            db.Photos.Add(photo);
            db.SaveChanges();
        }
    }
}
