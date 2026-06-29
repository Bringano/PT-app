namespace PTApp.API.DTO; 

public class CreateWorkoutDto
{
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }


}