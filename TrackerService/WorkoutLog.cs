using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackerService;

public class WorkoutLog
{
    // Initilize a dictionary variables
    private Dictionary<int, WorkoutSession> workoutSessions = new();
    public string filePath = "workoutLog.json";
    public bool isImported { get; private set; } = false;

    public void AddSession(WorkoutSession session)
    {
        // Add session to workkout session dictionary
        workoutSessions[session.sessionID] = session;
    }

public void updateWorkoutSession()
{
    // Get session ID
    Console.WriteLine("Enter the Session ID:");
    string? sessionIDString = Console.ReadLine();

    // Update session ID status, if complete ask user for metric (duration) 
    if (int.TryParse(sessionIDString, out int sessionID))
    {
        if (workoutSessions.ContainsKey(sessionID))
        {
            var session = workoutSessions[sessionID];

            Console.WriteLine("Was this session completed or missed? (Complete/Missed, return will register Complete):");
            string? status = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(status))
            {
                status = "Complete";
            }
            session.sessionStatus = status;

            if(status == "Complete")
            {
                Console.WriteLine("Enter the duration of the workout:");
                string? newWorkoutDuration = Console.ReadLine();
                if (int.TryParse(newWorkoutDuration, out int workoutDuration))
                {
                    session.sessionStatus += $" | Workout Duration: {workoutDuration}";
                }
            }

            // Export the workout log and display sessions
            exportWorkoutLog();
            Console.WriteLine("\nUpdated Session:");
            displayAllSessions();
        }
        else
        {
            Console.WriteLine($"Session with ID {sessionID} not found.");
        }
    }
}

    public void displayAllSessions()
    {
        // Initialize variables to determine progress
        int total = workoutSessions.Count;
        int completed = 0;

        // Display all sessions in the workout log
        foreach (var session in workoutSessions.Values)
        {
            Console.WriteLine($"Session ID: {session.sessionID}, Day: {session.sessionDay}, Time: {session.sessionTime}, Status: {session.sessionStatus}, Recommended Duration: {session.sessionDuration} mins");

            Console.WriteLine($"Workout: {session.sessionWorkout?.name ?? "Unknown"}");
            Console.WriteLine($"Type: {session.sessionWorkout?.type ?? "Unknwon"}\n");

            if (!string.IsNullOrWhiteSpace(session.sessionStatus) && session.sessionStatus.Contains("Complete |"))
            {
                completed++;
            }
        }

        // Display progress
        Console.WriteLine($"Progress: {completed} out of {total} sessions completed.");
    }

    public void copySessions(Dictionary<int, WorkoutSession> sessionsToCopy)
    {
        // Copy each key-value pair for each session to create the workout log
        foreach (var kvp in sessionsToCopy)
        {
            var original = kvp.Value;
            var logSession = new WorkoutSession(
                original.sessionID,
                original.sessionDay!,
                original.sessionTime!,
                new List<string> { original.sessionWorkout?.type ?? "General" },
                original.sessionWorkout?.type ?? "General"
            )
            {
                sessionWorkout = original.sessionWorkout,
                sessionDuration = original.sessionDuration,
                sessionStatus = "Not Complete"
            };

            workoutSessions[kvp.Key] = logSession;
        }
    }

    public void exportWorkoutLog()
    {
        // Export workout log to JSON file
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        File.WriteAllText(filePath, JsonSerializer.Serialize(workoutSessions, options));
    }

    public static WorkoutLog loadWorkoutLog(string filePath = "workoutLog.json")
    {
        // Load workout log from JSON file
        var workoutLog = new WorkoutLog();

        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var sessions = JsonSerializer.Deserialize<Dictionary<int, WorkoutSession>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (sessions != null)
                {
                    foreach (var kvp in sessions)
                    {
                        workoutLog.AddSession(kvp.Value);
                    }
                    workoutLog.isImported = true;
                    Console.WriteLine("Workout log loaded from file.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error reading workout log: {exception.Message}");
            }
        }

        return workoutLog;
    }
}
