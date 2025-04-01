namespace TrackerService;

public class WorkoutLog
{
    private Dictionary<int, WorkoutSession> workoutSessions = new();

    public void AddSession(WorkoutSession session)
    {
        workoutSessions[session.sessionID] = session;
    }

public void updateWorkoutSession()
{
    Console.WriteLine("Enter the Session ID:");
    string? sessionIDString = Console.ReadLine();

    if (int.TryParse(sessionIDString, out int sessionID))
    {
        if (workoutSessions.ContainsKey(sessionID))
        {
            var session = workoutSessions[sessionID];

            Console.WriteLine("Was this session completed or missed? (Complete/Missed):");
            string? status = Console.ReadLine();
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
            Console.WriteLine("\nUpdated Session:");
            Console.WriteLine(session.displaySession());
        }
        else
        {
            Console.WriteLine($"Session with ID {sessionID} not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid Session ID entered.");
    }
}

    public void displayAllSessions()
    {
        foreach (var session in workoutSessions.Values)
        {
            Console.WriteLine(session.displaySession());
        }
    }

    public void copySessions(Dictionary<int, WorkoutSession> sessionsToCopy)
    {
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
                sessionStatus = "Pending"
            };

            workoutSessions[kvp.Key] = logSession;
        }
    }
}
