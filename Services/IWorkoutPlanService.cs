using System;
using System.Collections.Generic;
using System.Threading.Tasks; // Ensure you have this for async/await
using WorkoutCoachApp.Models;

namespace WorkoutCoachApp.Services
{
    public interface IWorkoutPlanService
    {
        // Define methods for creating and managing workout plans
        Task<List<PlannedWorkout>> CreateWeeklyWorkoutPlan(DateTime startDate);
        

    }
}
