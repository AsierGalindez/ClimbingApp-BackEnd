using System.Collections.Generic;

namespace ClimbingBack.Models
{
    public class Crag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClimbingAreaId { get; set; }
        public string Aprox { get; set; }
        public string Ubication { get; set; }
        public int NumberOfRoutes { get; set; }
        public string Orientation { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Dificulty { get; set; }
        public string MaxHeight { get; set; }
        public List<Route> Routes { get; set; }
       
    }
}
