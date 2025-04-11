using System.Text;
using TrackerService;

namespace TrackerTests;

public class ProgressTesting
{
    [Fact]
    public void TestProgress()
    {
        // Create sessions
        var workoutLog = new WorkoutLog();
        var session0 = new WorkoutSession(0, "Mon", "Morning", new List<string> { "Cardio" }, "Cardio")
        {
            sessionStatus = "Complete | Workout Duration: 30",
            sessionDuration = 15,
            sessionWorkout = new Workout { name = "Running", type = "Cardio" }
        };
        var session1 = new WorkoutSession(1, "Tue", "Evening", new List<string> { "Strength" }, "Strength")
        {
            sessionStatus = "Not Complete",
            sessionDuration = 15,
            sessionWorkout = new Workout { name = "Weight Lifting", type = "Strength" }
        };

        workoutLog.addSession(session0);
        workoutLog.addSession(session1);

        var output = new StringBuilder();
        Console.SetOut(new StringWriter(output));

        // Press return in test
        Console.SetIn(new StringReader("\n"));

        // Display log
        workoutLog.displayAllSessions();

        // Test progress output
        var consoleOutput = output.ToString();
        Assert.Contains("\nProgress: [###############---------------]", consoleOutput);
        Assert.Contains("1 out of 2 sessions completed.", consoleOutput);
        Assert.Contains("Completion Percentage: 50%", consoleOutput);
        Assert.Contains("You're more than halfway there!", consoleOutput);
        Assert.Contains("Session ID: 0, Day: Mon, Time: Morning, Status: Complete | Workout Duration: 30, Recommended Duration: 15 mins", consoleOutput);
        Assert.Contains("Workout: Running", consoleOutput);
        Assert.Contains("Type: Cardio", consoleOutput);
        Assert.Contains("Session ID: 1, Day: Tue, Time: Evening, Status: Not Complete, Recommended Duration: 15 mins", consoleOutput);
        Assert.Contains("Workout: Weight Lifting", consoleOutput);
        Assert.Contains("Type: Strength", consoleOutput);
    }
}