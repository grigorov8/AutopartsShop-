using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ValidationConstants
{
    public static class CarValidationConstants
    {

        public const int MakeMinLength = 1;
        public const int MakeMaxLength = 100;


        public const int ModelMinLenght = 1;
        public const int ModelMaxLenght = 100;


        public const int MinYear = 1886;
        public const int MaxYear = 2024;


        public const int VinLenght = 17;

        public const double EngineCapacityMin = 0.6;
        public const double EngineCapacityMax = 9000;


    }


}
