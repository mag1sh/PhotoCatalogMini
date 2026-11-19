using PhotoCatalogMini.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCatalogMini.Services.Contracts
{
    public interface IPhotoService
    {
        List<Photo> GetAll();
    }
}
