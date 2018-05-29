using System;
using System.Collections.Generic;

namespace EFDBFirstDemo.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            City = new HashSet<City>();
        }

        public int TournamentId { get; set; }
        public string Title { get; set; }

        public ICollection<City> City { get; set; }
    }
}
