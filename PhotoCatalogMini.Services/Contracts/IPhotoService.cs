using PhotoCatalogMini.Data.Entities;
using PhotoCatalogMini.Services.DTOs.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Services.Contracts
{
    public interface IPhotoService
    {
        Task<List<PhotoListDto>> GetAll();
        Task CreateAsync(CreatePhotoDto dto);
    }
}
