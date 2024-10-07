namespace WorkoutCoachApp.Models;

public class ActualWorkout
{
    public int Id { get; set; }
    public int? PlannedId { get; set; }
    public DateTime Date { get; set; }
    public string WorkoutType { get; set; }
    public string ExerciseName { get; set; }
    public int SetNumber { get; set; }
    public float? Weight { get; set; }
    public int? Reps { get; set; }
    public string Notes { get; set; }
}