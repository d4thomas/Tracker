namespace TrackerService;

public class UserPreferences
{
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
        "General", "Strenth", "Weightloss"
        };

    public void getDaysAvailable()
        {
        string newDayAvailable;
        do
        {
            newDayAvailable = Console.ReadLine() ?? string.Empty;
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
        string newTimeAvailable;
        do
        {
            newTimeAvailable = Console.ReadLine() ?? string.Empty;
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
        string newWorkoutType;
        do
        {
            newWorkoutType = Console.ReadLine() ?? string.Empty;
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
        string newWorkoutGoal;
        do
        {
            newWorkoutGoal = Console.ReadLine() ?? string.Empty;
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
        Console.WriteLine("Days Available: " + string.Join(", ", daysAvailable));
        Console.WriteLine("Times Available: " + string.Join(", ", timesAvailable));
        Console.WriteLine("Workout Types: " + string.Join(", ", workoutTypes));
        Console.WriteLine("Workout Goal: " + workoutGoal);
    }

}

