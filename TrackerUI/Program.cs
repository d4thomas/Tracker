using TrackerService;

namespace TrackerIU;

public class Program
{
    static void Main(string[] args)
    {
        var userPreferences = new UserPreferences();
        var workoutPlan = WorkoutPlan.loadWorkoutPlan();
        var workoutLog = WorkoutLog.loadWorkoutLog();
        if(workoutPlan.isImported & workoutLog.isImported) {}
        else
        {
             workoutLog.copySessions(workoutPlan.workoutSessions);
             workoutLog.exportWorkoutLog();
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Workout Plan");
            Console.WriteLine("2. View Workout Schedule");
            Console.WriteLine("3. Track Workouts");
            Console.WriteLine("4. Delete Workout Plan");
            Console.WriteLine("5. Delete Workout Log");
            Console.WriteLine("6. Exit");
            Console.Write("Enter menu option: ");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Creating workout plan...");
                // Get days available from the user
                Console.WriteLine("\nPlease enter the day(s) you are available. Type done when complete.");
                Console.WriteLine("Options: " + string.Join(", ", userPreferences.validDayOptions));
                Console.WriteLine("Press return to use all values.");
                userPreferences.getDaysAvailable();

                // Get time of day from the user
                Console.Clear();
                Console.WriteLine("\nPlease enter the time(s) of day you are available. Type done when complete.");
                Console.WriteLine("Options: " + string.Join(", ", userPreferences.validTimeOptions));
                Console.WriteLine("Press return to use all values.");
                userPreferences.getTimesAvailable();

                // Get workout types from the user
                Console.Clear();
                Console.WriteLine("\nPlease enter workout types. Type done when complete.");
                Console.WriteLine("Options: " + string.Join(", ", userPreferences.validWorkoutTypes));
                Console.WriteLine("Press return to use all values.");
                userPreferences.getWorkoutTypes();

                // Get workout goal from the user
                Console.Clear();
                Console.WriteLine("\nPlease enter a workout goal.");
                Console.WriteLine("Options: " + string.Join(", ", userPreferences.validWorkoutGoals));
                Console.WriteLine("Press return to use default goal (General).");
                userPreferences.getWorkoutGoal();

                // Display user preferences
                Console.Clear();
                userPreferences.displayUserPreferences();

                // Create the workout plan
                workoutPlan.createWorkoutPlan(userPreferences);
                workoutPlan.exportWorkoutPlan();

                // Copy the workout plan to a workout log for tracking
                workoutLog.copySessions(workoutPlan.workoutSessions);
                workoutLog.exportWorkoutLog();
            }
            else if (choice == "2")
            {
                // Display the workout schedule
                Console.Clear();
                Console.WriteLine("\nViewing workout schedule...");
                workoutPlan.displayWorkoutPlan();
            }
            else if (choice == "3")
            {
                // Display the workout log
                Console.Clear();
                Console.WriteLine("\nTracking workouts...");
                workoutLog.displayAllSessions();

                // Check to see if an update is wanted
                Console.WriteLine("\nDo you want to update a session? (y/n)");
                string? answer;
                do
                {
                    answer = Console.ReadLine();
                    if (answer?.ToLower() == "y")
                    {
                        workoutLog.updateWorkoutSession();
                        Console.WriteLine("\nDo you want to update another session? (y/n)");
                    }
                } while (answer?.ToLower() == "y");
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("\nDeleting workout plan...");
                if (File.Exists("workoutPlan.json"))
                {
                    File.Delete("workoutPlan.json");
                    Console.WriteLine("Workout plan deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No workout plan found to delete.");
                }
            }
            else if (choice == "5")
            {
                Console.Clear();
                Console.WriteLine("\nDeleting workout log...");
                if (File.Exists("workoutLog.json"))
                {
                    File.Delete("workoutLog.json");
                    Console.WriteLine("Workout log deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No workout log found to delete.");
                }
            }
            else if (choice == "6")
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