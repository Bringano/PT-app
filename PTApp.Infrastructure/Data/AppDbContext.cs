using Microsoft.EntityFrameworkCore;
using PTApp.Domain.Entities;

namespace PTApp.Infrastructure.Data; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

}