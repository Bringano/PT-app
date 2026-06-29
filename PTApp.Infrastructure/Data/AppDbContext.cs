using Microsoft.EntityFrameworkCore;
using PTApp.Domain.Entities;

namespace PTApp.Infrastructure.Data; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<ExerciseLog> ExerciseLogs { get; set; }
    public DbSet<Set> Sets { get; set; }

}