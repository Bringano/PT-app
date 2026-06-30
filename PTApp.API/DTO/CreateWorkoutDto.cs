namespace PTApp.API.DTO;

public class CreateWorkoutDto
{
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public List<CreateExerciseLogDto> Exercises { get; set; } = new(); 



}