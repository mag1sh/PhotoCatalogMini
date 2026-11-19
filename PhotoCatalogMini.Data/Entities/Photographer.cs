using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Data.Entities
{
    public class Photographer
    {
        public Guid PhotographerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
