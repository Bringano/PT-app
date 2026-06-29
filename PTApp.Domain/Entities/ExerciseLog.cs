
namespace PTApp.Domain.Entities; 

public class ExerciseLog
{
    public Guid Id { get; private set; }
    public string ExerciseName { get; private set; }
    public Guid WorkoutId { get; private set; }

    public List<Set> Sets { get; private set; } = new();
    public ExerciseLog(string exerciseName, Guid workoutId) 
    {
        Id = Guid.NewGuid(); 
        ExerciseName = exerciseName; 
        WorkoutId = workoutId; 
    }
}