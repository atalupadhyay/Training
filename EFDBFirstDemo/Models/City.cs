using System;
using System.Collections.Generic;

namespace EFDBFirstDemo.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Tournament Tournament { get; set; }
    }
}
