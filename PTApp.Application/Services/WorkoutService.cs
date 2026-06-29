using PTApp.Application.Interfaces;
using PTApp.Domain.Entities;

namespace PTApp.Application.Services;

public class WorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository; 
    }

    public async Task<Workout> GetWorkoutByIdAsync(Guid id)
    {
        var workout = await _workoutRepository.GetByIdAsync(id); 

        if (workout == null)
        {
            throw new Exception($"Workout with id {id} not found."); 
        }

        return workout; 
    }

    public async Task<List<Workout>> GetWorkoutByUserIdAsync(Guid userId)
    {
        var workout = await _workoutRepository.GetByUserIdAsync(userId); 

        return workout; 
    }


    public async Task DeleteWorkoutAsync(Guid id)
    {
        await _workoutRepository.DeleteAsync(id); 
    }

    public async Task<Workout> CreateWorkoutAsync(string name, DateTime date, Guid userId)
    {
        var workout = new Workout(name, date, userId); 
        await _workoutRepository.AddAsync(workout); 
        return workout;
    }

}