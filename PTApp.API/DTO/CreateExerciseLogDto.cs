namespace PTApp.API.DTO; 

public class CreateExerciseLogDto
{
    public required string ExerciseName { get; set; }
    public required List<CreateSetDto> Sets { get; set; }
}