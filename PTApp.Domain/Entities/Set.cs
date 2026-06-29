namespace PTApp.Domain.Entities; 

public class Set
{
    public Guid Id { get; private set; }
    public int Reps { get; private set; }

    public double Weight { get; private set; }

    public Guid ExerciseLogId { get; private set; }
    public Set(int reps, double weight, Guid exerciseLogId)
    {
        Id = Guid.NewGuid();
        Reps = reps; 
        Weight = weight; 
        ExerciseLogId = exerciseLogId; 
    }

    public void UpdateSet(int reps, double weight)
{
    if (reps <= 0) throw new Exception("Reps måste vara större än 0");
    if (weight < 0) throw new Exception("Vikt kan inte vara negativ");
    
    Reps = reps;
    Weight = weight;
}
}