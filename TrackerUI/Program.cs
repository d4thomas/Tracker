using TrackerService;

namespace TrackerUI;

public class Program
{
    static void Main(string[] args)
    {
        // Initialize user preferences, workout plan, and workout log
        var userPreferences = new UserPreferences();
        var workoutPlan = WorkoutPlan.loadWorkoutPlan();
        var workoutLog = WorkoutLog.loadWorkoutLog();

        // Create a workout log if workout plan was imported, but no workout log
        if (!workoutPlan.isImported || !workoutLog.isImported)
        {
            workoutLog.copySessions(workoutPlan.workoutSessions);
            workoutLog.exportWorkoutLog();
        }

        Console.Clear();

        while (true)
        {
            // Display the menu options
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Workout Plan");
            Console.WriteLine("2. View Workout Schedule");
            Console.WriteLine("3. Track Workouts");
            Console.WriteLine("4. Delete Workout Plan");
            Console.WriteLine("5. Delete Workout Log");
            Console.WriteLine("6. Exit");
            Console.Write("Enter menu option: ");

            // Get user input for menu option
            var choice = Console.ReadLine();

            // Get user preferences and create workout plan
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

                // Create workout plan
                workoutPlan.createWorkoutPlan(userPreferences);
                workoutPlan.exportWorkoutPlan();

                // Copy workout plan to a workout log for tracking
                workoutLog.copySessions(workoutPlan.workoutSessions);
                workoutLog.exportWorkoutLog();
            }

            // View workout schedule
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("\nViewing workout schedule...");
                workoutPlan.displayWorkoutPlan();
            }

            // Track workouts
            else if (choice == "3")
            {
                // Display the workout log
                Console.Clear();
                Console.WriteLine("\nTracking workouts...");
                workoutLog.displayAllSessions();

                // Check to see if an update is wanted
                Console.WriteLine("\nDo you want to update a session? (y/n)");
                string? answer;
                // Loop until user does not want to update sessions
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

            // Delete workout plan
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

            // Delete workout log
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

            // Exit the program
            else if (choice == "6")
            {
                Console.Clear();
                Console.WriteLine("\nExiting...");
                return;
            }

            // Invalid choice notification
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
            }
        }
    }
}