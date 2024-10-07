using Microsoft.EntityFrameworkCore;
using WorkoutCoachApp.Models;

namespace WorkoutCoachApp.Data
{
    public class WorkoutCoachContext : DbContext
    {
        public WorkoutCoachContext(DbContextOptions<WorkoutCoachContext> options) : base(options) { }

        public DbSet<PlannedWorkout> PlannedWorkouts { get; set; }
        public DbSet<ActualWorkout> ActualWorkouts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships or any additional configuration
        }
    }
}
