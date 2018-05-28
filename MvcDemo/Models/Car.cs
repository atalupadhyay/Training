using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DisplayName("Marken Name")]
        [Required]
        public string BrandName { get; set; }

        //[FromQuery]
        [DisplayName("Model Name")]
        [Required]
        [MaxLength(10)]
        public string ModelName { get; set; }

        //[BindNever]
        [DisplayName("Baujahr")]
        [Range(1900, 2018)]
        public int YearOfConstruction { get; set; }
    }
}