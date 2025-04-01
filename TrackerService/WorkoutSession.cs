namespace TrackerService;

public class WorkoutSession
{
    public int sessionID { get; set; }
    public string? sessionDay { get; set; }
    public string? sessionTime { get; set; }
    public string? sessionStatus { get; set; }
    public int sessionDuration { get; set; }
    public Workout? sessionWorkout { get; set; }
    public WorkoutSession() { }

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

        return $"\nSession ID: {sessionID}, Day: {sessionDay}, Time: {sessionTime}, Duration: {sessionDuration} mins \n{workoutDetails}";
    }

}
