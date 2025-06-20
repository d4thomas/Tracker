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

        // Create workout log if workout plan was imported but no workout log
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
                // Get days available from the user
                Console.WriteLine("\nPlease enter the day(s) you are available.");
                Console.WriteLine("Press return after each entry. Type done when complete.");
                Console.WriteLine("Options: " + string.Join(", ", userPreferences.validDayOptions));
                Console.WriteLine("Press return to use all values.");
                userPreferences.getDaysAvailable();

                // Get time of day from the user
                Console.Clear();
                Console.WriteLine("\nPlease enter the time(s) of day you are available.");
                Console.WriteLine("Press return after each entry. Type done when complete.");
                Console.WriteLine("Options: " + string.Join(", ", userPreferences.validTimeOptions));
                Console.WriteLine("Press return to use all values.");
                userPreferences.getTimesAvailable();

                // Get workout types from the user
                Console.Clear();
                Console.WriteLine("\nPlease enter workout types.");
                Console.WriteLine("Press return after each entry. Type done when complete.");
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
                if (workoutPlan.workoutSessions.Count > 0)
                {
                    workoutPlan.displayWorkoutPlan();
                }
                else
                {
                    Console.WriteLine("\nNo workout plan found!");
                }
            }

            // Track workouts
            else if (choice == "3")
            {
                // Display the workout log
                Console.Clear();
                if(workoutLog.workoutSessions.Count > 0)
                {
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

                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nNo workout log found!");
                }
            }

            // Delete workout plan
            else if (choice == "4")
            {
                Console.Clear();
                if (File.Exists("workoutPlan.json"))
                {
                    // Make sure to clear the current workout plan, then delete file
                    workoutPlan = new WorkoutPlan();
                    File.Delete("workoutPlan.json");
                    Console.WriteLine("\nWorkout plan deleted successfully.");
                }
                else
                {
                    Console.WriteLine("\nNo workout plan found to delete.");
                }
            }

            // Delete workout log
            else if (choice == "5")
            {
                Console.Clear();
                if (File.Exists("workoutLog.json"))
                {
                    // Make sure to clear the current workout log, then delete file
                    workoutLog = new WorkoutLog();
                    File.Delete("workoutLog.json");
                    Console.WriteLine("\nWorkout log deleted successfully.");
                }
                else
                {
                    Console.WriteLine("\nNo workout log found to delete.");
                }
            }

            // Exit the program
            else if (choice == "6")
            {
                Console.Clear();
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