using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PTApp.API.DTO;
using PTApp.Application.Models;
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
    public async Task<IActionResult> CreateWorkout(CreateWorkoutDto dto)
    {
        try
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var exercises = new List<CreateExerciseLogRequest>(); 
            
            foreach (var exerciseDto in dto.Exercises)
            {
                var sets = new List<CreateSetRequest>(); 

                foreach (var setDto in exerciseDto.Sets)
                {
                    sets.Add(new CreateSetRequest
                    {
                        Reps = setDto.Reps,
                        Weight = setDto.Weight
                    }); 
                }

                exercises.Add(new CreateExerciseLogRequest
                {
                    ExerciseName = exerciseDto.ExerciseName,
                    Sets = sets
                });
            }
            var workout = await _workoutService.CreateWorkoutAsync(dto.Name, dto.Date, userId, exercises);
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