using System.Collections.Generic;

namespace ClimbingBack.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<Proyect> Proyects { get; set; }
        public List<Friend> Friends { get; set; }
    }
}
