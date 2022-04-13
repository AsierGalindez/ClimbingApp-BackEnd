using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClimbingBack.Models;

namespace ClimbingBack.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClimbingBack.Models.ClimbingArea> ClimbingArea { get; set; }

        public DbSet<ClimbingBack.Models.Crag> Crag { get; set; }

        public DbSet<ClimbingBack.Models.Route> Route { get; set; }

        public DbSet<ClimbingBack.Models.User> User { get; set; }

        public DbSet<ClimbingBack.Models.Favorite> Favorite { get; set; }

        public DbSet<ClimbingBack.Models.Proyect> Proyect { get; set; }

        public DbSet<ClimbingBack.Models.Friend> Friend { get; set; }
    }
}
