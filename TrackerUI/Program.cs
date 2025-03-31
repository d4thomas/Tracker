using TrackerService;

namespace TrackerIU;

public class Program
{
    static void Main(string[] args)
    {
        var userPreferences = new UserPreferences();

        // Get days available from the user
        Console.WriteLine("\nPlease enter the day(s) you are available. Type done when complete.");
        Console.WriteLine("Options: " + string.Join(", ", userPreferences.validDayOptions));
        userPreferences.getDaysAvailable();

        // Get time of day from the user
        Console.WriteLine("\nPlease enter the time(s) of day you are available. Type done when complete.");
        Console.WriteLine("Options: " + string.Join(", ", userPreferences.validTimeOptions));
        userPreferences.getTimesAvailable();

        // Get workout types from the user
        Console.WriteLine("\nPlease enter workout types. Type done when complete.");
        Console.WriteLine("Options: " + string.Join(", ", userPreferences.validWorkoutTypes));
        userPreferences.getWorkoutTypes();

        // Get workout goal from the user
        Console.WriteLine("\nPlease enter a workout goal.");
        Console.WriteLine("Options: " + string.Join(", ", userPreferences.validWorkoutGoals));
        userPreferences.getWorkoutGoal();

        Console.WriteLine("Days Available: " + string.Join(", ", userPreferences.daysAvailable));
        Console.WriteLine("Times Available: " + string.Join(", ", userPreferences.timesAvailable));
        Console.WriteLine("Workout Types: " + string.Join(", ", userPreferences.workoutTypes));
        Console.WriteLine("Workout Goal: " + userPreferences.workoutGoal);
    }
}