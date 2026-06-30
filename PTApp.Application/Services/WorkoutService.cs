using PTApp.Application.Interfaces;
using PTApp.Application.Models;
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

    public async Task<Workout> CreateWorkoutAsync(string name, DateTime date, Guid userId, List<CreateExerciseLogRequest> exercises)
    {
        var workout = new Workout(name, date, userId); 

        foreach (var exerciseRequest in exercises)
        {
            var exerciseLog = new ExerciseLog(exerciseRequest.ExerciseName, workout.Id);
            
            foreach (var setRequest in exerciseRequest.Sets)
            {
                var set = new Set(setRequest.Reps, setRequest.Weight, exerciseLog.Id);
                exerciseLog.Sets.Add(set); 
            }

            workout.ExerciseLogs.Add(exerciseLog); 
        }
        await _workoutRepository.AddAsync(workout); 
        return workout;
    }

    public async Task<Workout> UpdateWorkoutAsync(Guid id, string name, DateTime date)
    {
        var workout = await _workoutRepository.GetByIdAsync(id);

        if (workout == null)
        {
            throw new Exception($"Workout with id {id} not found.");
        }

        workout.UpdateDetails(name, date);
        await _workoutRepository.UpdateAsync(workout); 

        return workout; 
    }

    public async Task<double> GetWorkoutVolumeAsync(Guid workoutId)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId); 

        if (workout == null)
        {
            throw new Exception($"Workout with id {workoutId} not found.");
        }

        double totalVolume = 0; 

        foreach (var exerciseLog in workout.ExerciseLogs)
        {
            foreach (var set in exerciseLog.Sets)
            {
                double totalSetVolume = set.Reps * set.Weight; 
                totalVolume += totalSetVolume; 
            }
        }
        return totalVolume;
    }

}