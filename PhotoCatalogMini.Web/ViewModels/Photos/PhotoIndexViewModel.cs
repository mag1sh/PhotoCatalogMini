using PhotoCatalogMini.Services.DTOs.Photos;

namespace PhotoCatalogMini.Web.ViewModels.Photos
{
    public class PhotoIndexViewModel
    {
        public List<PhotoListDto> Photos { get; set; } = new();
    }
}
