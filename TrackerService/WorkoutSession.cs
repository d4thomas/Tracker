namespace TrackerService;

public class WorkoutSession
{
    // Initialize workout session properties
    public int sessionID { get; set; }
    public string? sessionDay { get; set; }
    public string? sessionTime { get; set; }
    public string? sessionStatus { get; set; }
    public int sessionDuration { get; set; }
    public Workout? sessionWorkout { get; set; }
    public WorkoutSession() { }

    public WorkoutSession(int sessionID, string sessionDay, string sessionTime, List<string> workoutTypes, string? workoutGoal)
    {
        // Initialize workout session with provided parameters
        this.sessionID = sessionID;
        this.sessionDay = sessionDay;
        this.sessionTime = sessionTime;
        sessionDuration = 15;

        // Filter workouts based on the provided workout types
        var filteredWorkouts = Workout.Workouts.Values.Where(workout => workout.type != null && workoutTypes.Contains(workout.type)).ToList();

        // Match the workout types to include only items from the correct goal
        var random = new Random();
        if (workoutGoal == "General")
        {
            sessionWorkout = filteredWorkouts[random.Next(filteredWorkouts.Count)];
        }
        else if (workoutGoal == "Strength")
        {
            var strengthWorkouts = filteredWorkouts.Where(workout => workout.type == "Strength").ToList();
            sessionWorkout = strengthWorkouts[random.Next(strengthWorkouts.Count)];
        }
        else if (workoutGoal == "Weightloss")
        {
            var weightLossWorkouts = filteredWorkouts.Where(workout  => workout.type == "Cardio").ToList();
            sessionWorkout = weightLossWorkouts[random.Next(weightLossWorkouts.Count)];
        }
    }

    public string displaySession()
    {
        // Set workout details... ensure no null value
        var workoutDetails = sessionWorkout != null
            ? $"Workout: {sessionWorkout.name}\nType: {sessionWorkout.type}\nHow To: {sessionWorkout.howTo}"
            : "\nWorkout: None Assigned!";

        // Return session details
        return $"\nSession ID: {sessionID}, Day: {sessionDay}, Time: {sessionTime}, Duration: {sessionDuration} mins \n{workoutDetails}";
    }

}
