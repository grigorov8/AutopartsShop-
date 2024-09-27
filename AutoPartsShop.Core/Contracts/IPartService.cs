using AutoPartsShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Services
{
    public interface IPartService
    {

         Task<List<PartModel>> SearchPartsAsync(string partNumber);


    }


}
