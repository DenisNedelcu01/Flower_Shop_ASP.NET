using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;
using System.Net.Sockets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.Models
{
    public class FlowersContext : IdentityDbContext<IdentityUser>
	{
        public FlowersContext(DbContextOptions<FlowersContext> options)
            : base(options)
        {

        }

        public DbSet<Magazin>? Magazine { get; set; }
        public DbSet<Produs>? Produse { get; set; }
        public DbSet<Galerie>? Galerii { get; set; }
        public DbSet<Comanda>? Comenzi { get; set; }
        public DbSet<Articol>? Articole { get; set; }
    }
}
