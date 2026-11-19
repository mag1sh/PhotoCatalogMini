using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Data.Entities
{
    public class Photo
    {
        public Guid PhotoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Photographer { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
