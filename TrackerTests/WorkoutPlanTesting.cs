namespace TrackerService.Tests;

public class WorkoutPlanTesting
{
    [Fact]
    public void checkWorkoutPlanSessionCount()
    {
        // Create workout plan
        var workoutPlan = new WorkoutPlan();
        var userPreferences = new UserPreferences
        {
            daysAvailable = new List<string> { "Mon", "Tue", "Fri" },
            timesAvailable = new List<string> { "Morning", "Evening" },
            workoutTypes = new List<string> { "Cardio", "Strength" },
            workoutGoal = "Weightloss"
        };

        workoutPlan.createWorkoutPlan(userPreferences);

        // Test number of workout sessions
        Assert.Equal(3, workoutPlan.workoutSessions.Count);
    }

    [Fact]
    public void checkWorkoutPlanTime()
    {
        // Create workout plan
        var workoutPlan = new WorkoutPlan();
        var userPreferences = new UserPreferences
        {
            daysAvailable = new List<string> { "Mon", "Tue", "Fri" },
            timesAvailable = new List<string> { "Morning", "Evening" },
            workoutTypes = new List<string> { "Cardio", "Strength" },
            workoutGoal = "Weightloss"
        };

        workoutPlan.createWorkoutPlan(userPreferences);

        // Test time of day for workouts
        Assert.Equal("Mon", workoutPlan.workoutSessions[0].sessionDay);
        Assert.Equal("Morning", workoutPlan.workoutSessions[0].sessionTime);

        Assert.Equal("Tue", workoutPlan.workoutSessions[1].sessionDay);
        Assert.Equal("Evening", workoutPlan.workoutSessions[1].sessionTime);

        Assert.Equal("Fri", workoutPlan.workoutSessions[2].sessionDay);
        Assert.Equal("Morning", workoutPlan.workoutSessions[2].sessionTime);
    }
}