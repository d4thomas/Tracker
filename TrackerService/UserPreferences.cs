namespace TrackerService;

public class UserPreferences
{
    // Initialize user preferences
    public List<string> daysAvailable = new List<string>();
     public List<string> validDayOptions = new List<string> {
        "Mon", "Tue", "Weds", "Thur", "Fri", "Sat", "Sun"
        };
    public List<string> timesAvailable = new List<string>();
    public List<string> validTimeOptions = new List<string> {
        "Morning", "Evening"
        };
    public List<string> workoutTypes = new List<string>();
    public List<string> validWorkoutTypes = new List<string> {
        "Strength", "Cardio", "Flexibility", "Recovery"
        };
    public string? workoutGoal;
    public List<string> validWorkoutGoals = new List<string> {
        "General", "Strength", "Weightloss"
        };

    public void getDaysAvailable()
    {
        // Erase imput so a user can reinitilize preferences
        daysAvailable = new List<string>();

        // Get days from user
        string newDayAvailable;
        do
        {
            newDayAvailable = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newDayAvailable))
            {
                daysAvailable = new List<string>(validDayOptions);
                break;
            }
            if (newDayAvailable == "done")
            {
                break;
            }
            if (validDayOptions.Contains(newDayAvailable))
            {
                daysAvailable.Add(newDayAvailable);
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a valid option.");
                Console.WriteLine("Options: " + string.Join(", ", validDayOptions));
            }
        } while (true);
    }

    public void getTimesAvailable()
    {
        // Erase imput so a user can reinitilize preferences
        timesAvailable = new List<string>();

        // Get times from user
        string newTimeAvailable;
        do
        {
            newTimeAvailable = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newTimeAvailable))
            {
                timesAvailable = new List<string>(validTimeOptions);
                break;
            }
            if (newTimeAvailable == "done")
            {
                break;
            }
            if (validTimeOptions.Contains(newTimeAvailable))
            {
                timesAvailable.Add(newTimeAvailable);
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a valid option.");
                Console.WriteLine("Options: " + string.Join(", ", validTimeOptions));
            }
        } while (true);
    }

    public void getWorkoutTypes()
    {
        // Erase imput so a user can reinitilize preferences
        workoutTypes = new List<string>();

        // Get workout types from user
        string newWorkoutType;
        do
        {
            newWorkoutType = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newWorkoutType))
            {
                workoutTypes = new List<string>(validWorkoutTypes);
                break;
            }
            if (newWorkoutType == "done")
            {
                break;
            }
            if (validWorkoutTypes.Contains(newWorkoutType))
            {
                workoutTypes.Add(newWorkoutType);
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a valid option.");
                Console.WriteLine("Options: " + string.Join(", ", validWorkoutTypes));
            }
        } while (true);
    }

    public void getWorkoutGoal()
    {
        // Erase imput so a user can reinitilize preferences
        string newWorkoutGoal;

        // Get workout goal from user
        do
        {
            newWorkoutGoal = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newWorkoutGoal))
            {
                workoutGoal = "General";
                break;
            }
            if(validWorkoutGoals.Contains(newWorkoutGoal))
            {
                workoutGoal = newWorkoutGoal;
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a valid option.");
                Console.WriteLine("Options: " + string.Join(", ", validWorkoutGoals));
            }
        } while (true);
    }

    public void displayUserPreferences()
    {
        // Display user preferences
        Console.Clear();
        Console.WriteLine("\nThe following user preferences have been save:");
        Console.WriteLine("Days Available: " + string.Join(", ", daysAvailable));
        Console.WriteLine("Times Available: " + string.Join(", ", timesAvailable));
        Console.WriteLine("Workout Types: " + string.Join(", ", workoutTypes));
        Console.WriteLine("Workout Goal: " + workoutGoal);
        Console.WriteLine("\nPress return to continue...");
        Console.ReadLine();
        Console.Clear();
    }

}

