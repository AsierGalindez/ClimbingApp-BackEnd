using System.Collections.Generic;

namespace ClimbingBack.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int RouteNumber { get; set; }
        public int CragId { get; set; }
        public string Name { get; set; }       
        public string Grade { get; set; }
        public int Height { get; set; }
        public string Condition { get; set; }

        public List<Favorite> Favorites { get; set; }
        public List<Proyect> Proyects { get; set; }

    }
}
