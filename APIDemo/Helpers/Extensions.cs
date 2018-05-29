using System;

namespace APIDemo.Helpers
{
    public static class Extensions
    {
        public static int CalculateYearsOfService(this int yearOfConstruction)
        {
            return DateTime.UtcNow.Year - yearOfConstruction;
        }
    }
}
