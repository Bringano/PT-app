using Microsoft.EntityFrameworkCore;
using PTApp.Application.Interfaces;
using PTApp.Domain.Entities;
using PTApp.Infrastructure.Data;

namespace PTApp.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly AppDbContext _appDbContext;

    public WorkoutRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext; 
    }
    public async Task AddAsync(Workout workout)
    {
        _appDbContext.Workouts.Add(workout);
        await _appDbContext.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(Guid id)
    {
        var workout = await GetByIdAsync(id);

        if (workout != null)
        {
        _appDbContext.Workouts.Remove(workout);
        await _appDbContext.SaveChangesAsync(); 
        }
    }

    public async Task UpdateAsync(Workout workout)
    {
        _appDbContext.Workouts.Update(workout);
        await _appDbContext.SaveChangesAsync();
    }
    public async Task<Workout?> GetByIdAsync(Guid id)
    {
        return await _appDbContext.Workouts
        .Include(w => w.ExerciseLogs)
        .ThenInclude(e => e.Sets) 
        .FirstOrDefaultAsync(w => w.Id == id);
    }

    public Task<List<Workout>> GetByUserIdAsync(Guid userId)
    {
        return _appDbContext.Workouts
        .Include(w => w.ExerciseLogs)
        .ThenInclude(e => e.Sets)
        .Where(w => w.UserId == userId)
        .ToListAsync(); 
    }

}