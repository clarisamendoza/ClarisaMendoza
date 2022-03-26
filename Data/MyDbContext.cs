using ClarisaMendoza.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClarisaMendoza.Data
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Pagos> Pagos { get; set; }

    }
}
 