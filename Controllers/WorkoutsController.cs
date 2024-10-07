using Microsoft.AspNetCore.Mvc;
using WorkoutCoachApp.Services;


[Route("api/workouts")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutPlanService _workoutPlanService;

    public WorkoutsController(IWorkoutPlanService workoutPlanService)
    {
        _workoutPlanService = workoutPlanService;
    }

    [HttpPost("create-weekly-plan")]
    public async Task<IActionResult> CreateWeeklyPlan()
    {
        var startDate = new DateTime(2024, 10, 7); // Example start date
        var plannedWorkouts = await _workoutPlanService.CreateWeeklyWorkoutPlan(startDate);
        
        return Ok(plannedWorkouts);
    }
}
