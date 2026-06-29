namespace PTApp.Domain.Entities;

public class Workout
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public DateTime Date { get; private set; }

    public Guid UserId { get; private set; }

    public List<ExerciseLog> ExerciseLogs { get; private set; } = new();

    public Workout(string name, DateTime date, Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Date = date;
        UserId = userId;
    }
}