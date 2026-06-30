using PTApp.Domain.Entities;

namespace PTApp.Application.Interfaces;

public interface IWorkoutRepository
{
    Task<Workout?> GetByIdAsync(Guid id); 

    Task<List<Workout>> GetByUserIdAsync(Guid userId);

    Task AddAsync(Workout workout); 

    Task DeleteAsync(Guid id); 

    Task UpdateAsync(Workout workout);
}