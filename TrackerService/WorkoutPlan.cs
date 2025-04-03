using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackerService;

public class WorkoutPlan
{
    // Initialize workout plan
    public Dictionary<int, WorkoutSession> workoutSessions = new();
    public string filePath = "workoutPlan.json";
    public bool isImported { get; private set; } = false;

    public void createWorkoutPlan(UserPreferences userPreferences)
    {
        // Create a workout session for each day available
        for (int i = 0; i < userPreferences.daysAvailable.Count; i++)
        {
            // Create an index to cycle through the times available
            var index = i % userPreferences.timesAvailable.Count;
            // Create a workout session
            var session = new WorkoutSession(i, userPreferences.daysAvailable[i], userPreferences.timesAvailable[index], userPreferences.workoutTypes, userPreferences.workoutGoal);
            // Add the session to the workout plan
            workoutSessions[i] = session;
        }
    }

    public void displayWorkoutPlan()
    {
        // Display each session in the workout plan
        foreach (var session in workoutSessions.Values)
        {
            Console.WriteLine(session.displaySession());
        }
    }

    public void exportWorkoutPlan()
    {
        // Export the workout plan to a JSON file
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        File.WriteAllText(filePath, JsonSerializer.Serialize(workoutSessions, options));
    }

    public static WorkoutPlan loadWorkoutPlan(string filePath = "workoutPlan.json")
    {
        // Load the workout plan from a JSON file
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var sessions = JsonSerializer.Deserialize<Dictionary<int, WorkoutSession>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (sessions == null)
                {
                    Console.WriteLine("Failed to load workout plan. Creating empty workout plan.");
                    return new WorkoutPlan();
                }

                Console.WriteLine("Workout plan loaded from file.");
                return new WorkoutPlan { 
                    workoutSessions = sessions,
                    isImported = true };
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error reading workout plan: {exception.Message}");
                return new WorkoutPlan();
            }
        }
        else
        {
            return new WorkoutPlan();
        }
    }
}


