namespace TrackerService;

public class WorkoutSession
{
    public int sessionID;
    public string? sessionDay;
    public string? sessionTime;
    public string? sessionStatus;
    public int sessionDuration;
    public Workout? sessionWorkout; 

    public WorkoutSession(int sessionID, string sessionDay, string sessionTime, List<string> workoutTypes, string? workoutGoal)
    {
        this.sessionID = sessionID;
        this.sessionDay = sessionDay;
        this.sessionTime = sessionTime;
        sessionDuration = 15;

        var filteredWorkouts = Workout.Workouts.Values.Where(workout => workout.type != null && workoutTypes.Contains(workout.type)).ToList();
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
        var workoutDetails = sessionWorkout != null
            ? $"Workout: {sessionWorkout.name}\nType: {sessionWorkout.type}\nHow To: {sessionWorkout.howTo}"
            : "\nWorkout: None Assigned!";

        return $"\nSession ID: {sessionID}, Day: {sessionDay}, Time: {sessionTime}, Status: {sessionStatus ?? "Not Complete"}, Recommended Duration: {sessionDuration} mins \n{workoutDetails}";
    }
}
