using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Services.DTOs.Photos
{
    public class PhotoListDto
    {
        public Guid PhotoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PhotographerName { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new();
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}