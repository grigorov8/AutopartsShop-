using AutoPartsShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Core.Contracts
{
    public interface ICarService
    {

        Task<CarModel> SearchCarByVin(string vin);


    }


}
