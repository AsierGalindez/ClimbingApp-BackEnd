using System.Collections.Generic;

namespace ClimbingBack.Models
{
    public class ClimbingArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Photo { get; set; }
        public string Ubication { get; set; }
        public bool Wc { get; set; }
        public bool Water { get; set; }
        public bool Overnight { get; set; }
        public string RockType { get; set; }      
        public string Description { get; set; }
        public List<Crag> Crags { get; set; }
    }
}
