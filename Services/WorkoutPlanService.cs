using System; // Namespace for DateTime and related types
using System.Collections.Generic; // Namespace for using List<T>
using System.Linq; // Namespace for LINQ queries (not used here but can be useful)
using System.Threading.Tasks; // Namespace for asynchronous programming
using Microsoft.EntityFrameworkCore; // Namespace for Entity Framework Core
using WorkoutCoachApp.Data; // Namespace for the WorkoutCoachContext
using WorkoutCoachApp.Models; // Namespace for the WorkoutCoach Models

namespace WorkoutCoachApp.Services
{
    public class WorkoutPlanService : IWorkoutPlanService // Service class to handle workout planning logicspublic class WorkoutPlanService
    {
        private readonly WorkoutCoachContext _context; // Field to hold the database context

        // Constructor that takes the WorkoutCoachContext as a dependency
        public WorkoutPlanService(WorkoutCoachContext context)
        {
            _context = context; // Assign the injected context to the field
        }

        // Asynchronous method to create a week's worth of planned workouts
        public async Task<List<PlannedWorkout>> CreateWeeklyWorkoutPlan(DateTime startDate)
        {
            var plannedWorkouts = new List<PlannedWorkout>(); // List to hold the planned workouts

            // Loop to create workouts for each day of the week (7 days)
            for (int i = 0; i < 7; i++)
            {
                var workoutDate = startDate.AddDays(i); // Calculate the date for the workout

                // Create a new PlannedWorkout object with the date and other details
                var plannedWorkout = new PlannedWorkout
                {
                    Date = workoutDate, // Set the workout date
                    WorkoutType = GetWorkoutType(i), // Determine the type of workout based on the day index
                    Duration = 60, // Set a default duration for the workout (in minutes)
                    Notes = "Initial workout plan for the week" // Add a note for context
                };

                plannedWorkouts.Add(plannedWorkout); // Add the new workout to the list
            }

            // Save the planned workouts to the database using Entity Framework
            _context.PlannedWorkouts.AddRange(plannedWorkouts); // Add the list of planned workouts to the context
            await _context.SaveChangesAsync(); // Save changes asynchronously

            return plannedWorkouts; // Return the list of planned workouts
        }

        // Private method to determine the type of workout based on the day index
        private string GetWorkoutType(int dayIndex)
        {
            // Switch statement to return the type of workout based on the day of the week
            switch (dayIndex)
            {
                case 0: // Sunday
                case 3: // Wednesday
                    return "Running"; // Assign Running on Sunday and Wednesday
                case 1: // Monday
                case 4: // Thursday
                    return "Biking"; // Assign Biking on Monday and Thursday
                case 2: // Tuesday
                    return "Strength Training"; // Assign Strength Training on Tuesday
                case 5: // Friday
                    return "Rest Day"; // Assign Rest Day on Friday
                case 6: // Saturday
                    return "Active Recovery"; // Assign Active Recovery on Saturday
                default: // Fallback case
                    return "Unknown"; // Return Unknown for any unexpected values
            }
        }
    }   
    
}

