namespace WorkoutCoachApp.Models;
public class PlannedWorkout
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? WorkoutType { get; set; }
    public string? ExerciseName { get; set; }
    public float? Weight { get; set; }
    public int? Reps { get; set; }
    public int? Sets { get; set; }
    public int? Duration { get; set; }
    public float? Distance { get; set; }
    public string? Notes { get; set; }
}

