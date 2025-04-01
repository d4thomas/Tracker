using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackerService;

public class WorkoutPlan
{
    public Dictionary<int, WorkoutSession> workoutSessions = new();
    public string filePath = "workoutPlan.json";

    public void createWorkoutPlan(UserPreferences userPreferences)
    {
        for (int i = 0; i < userPreferences.daysAvailable.Count; i++)
        {
            var index = i % userPreferences.timesAvailable.Count;
            var session = new WorkoutSession(i, userPreferences.daysAvailable[i], userPreferences.timesAvailable[index], userPreferences.workoutTypes, userPreferences.workoutGoal);
            workoutSessions[i] = session;
        }
    }

    public void displayWorkoutPlan()
    {
        foreach (var session in workoutSessions.Values)
        {
            Console.WriteLine(session.displaySession());
        }
    }

    public void exportWorkoutPlanToJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        File.WriteAllText(filePath, JsonSerializer.Serialize(workoutSessions, options));
        Console.WriteLine($"Workout plan exported to {filePath}");
    }
}


