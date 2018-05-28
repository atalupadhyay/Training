using System;

namespace APIDemo.Models
{
    public class Car
    {
        public int Id { get; set; }

        public BrandNames BrandName { get; set; }

        public string ModelName { get; set; }

        public int YearOfConstruction { get; set; }

        public Guid IdentificationNumber { get; set; }
    }
}
