using Microsoft.EntityFrameworkCore;
using TeaProduction.Infrastructure.Entities;

namespace TeaProduction.Infrastructure.Data;

public class TeaProductionDbContext : DbContext
{
    public TeaProductionDbContext(DbContextOptions<TeaProductionDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<BlackTea> BlackTeas { get; set; }
    public DbSet<GreenTea> GreenTeas { get; set; }

    public DbSet<HerbalTea> HerbalTeas { get; set; }

}
