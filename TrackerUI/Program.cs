using TrackerService;

namespace TrackerIU;

public class Program
{
    static void Main(string[] args)
    {
        var userPreferences = new UserPreferences();
        var workoutPlan = WorkoutPlan.LoadWorkoutPlan();
        var workoutLog = new WorkoutLog();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Workout Plan");
            Console.WriteLine("2. View Workout Schedule");
            Console.WriteLine("3. Track Workouts");
            Console.WriteLine("4. Exit");
            Console.Write("Enter menu option: ");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Creating workout plan...");
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

                // Display user preferences
                userPreferences.displayUserPreferences();

                // Create the workout plan
                workoutPlan.createWorkoutPlan(userPreferences);
                workoutPlan.exportWorkoutPlanToJson();

                // Copy the workout plan to a workout log for tracking
                workoutLog.copySessions(workoutPlan.workoutSessions);
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("\nViewing workout schedule...");
                workoutPlan.displayWorkoutPlan();
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("\nTracking workouts...");
                workoutLog.displayAllSessions();

                Console.WriteLine("\nDo you want to update a session? (y/n)");
                 string? answer = Console.ReadLine();
                if (answer?.ToLower() == "y")
                {
                    workoutLog.updateWorkoutSession();
                }
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("\nExiting...");
                    return;
                }
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
            }
        }
    }
}