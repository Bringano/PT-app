namespace PTApp.Application.Models; 

public class CreateExerciseLogRequest
{
    public required string ExerciseName { get; set; }
    public required List<CreateSetRequest> Sets { get; set; } 

}