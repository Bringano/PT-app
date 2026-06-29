using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTApp.API.DTO;
using PTApp.Application.Services;

namespace PTApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly WorkoutService _workoutService;

    public WorkoutsController(WorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Register(CreateWorkoutDto dto)
    {
        try
        {
            var workout = await _workoutService.CreateWorkoutAsync(dto.Name, dto.Date, dto.UserId);
            return Ok(workout);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkout(Guid id)
    {
        try
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);
            return Ok(workout);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetWorkouts(Guid userId)
    {
        try
        {
            var workouts = await _workoutService.GetWorkoutByUserIdAsync(userId);
            return Ok(workouts); 
        } 
        catch (Exception ex)
        {
            return NotFound(ex.Message); 
        }
    }
}