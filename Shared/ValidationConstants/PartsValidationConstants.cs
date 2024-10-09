

namespace Shared.ValidationConstants
{
    public static class PartsValidationConstants
    {

        public const int NameMinLength = 2;
        public const int NameMaxLength = 100;

        public const int DescriptionMaxLength = 500;

        public const int PartNumberMinLength = 2;
        public const int PartNumberMaxLength = 30;

        public const int MinQuantity = 1;
        public const int MaxQuantity = 1000;

        public const decimal MinPrice = 0.01m;
        public const decimal MaxPrice = 100000m;

        public const int ManufacturerMaxLength = 100;


    }


}
