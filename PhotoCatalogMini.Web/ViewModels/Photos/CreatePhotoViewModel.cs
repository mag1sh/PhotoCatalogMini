using System.ComponentModel.DataAnnotations;

namespace PhotoCatalogMini.Web.ViewModels.Photos
{
    public class CreatePhotoViewModel
    {
        [Display(Name = "Заглавие на снимката")]
        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(100, ErrorMessage = "Заглавието може да е до 100 символа.")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Фотограф")]
        [Required(ErrorMessage = "Фотографът е задължителен.")]
        [StringLength(100, ErrorMessage = "Фотографът може да е до 100 символа.")]
        public string PhotographerName { get; set; } = string.Empty;

        [Display(Name = "Категория (разделени със запетая")]
        [Required(ErrorMessage = "Въведи поне една категория.")]
        public string Categories { get; set; } = string.Empty;

        [Display(Name = "Място на заснемане")]
        [Required(ErrorMessage = "Мястото е задължително.")]
        [StringLength(100, ErrorMessage = "Мястото може да е до 100 символа.")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(500, ErrorMessage = "Описанието може да е до 500 символа.")]
        public string Description { get; set; } = string.Empty;
    }
}
