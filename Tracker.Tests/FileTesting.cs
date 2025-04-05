using System.Text.Json;
using TrackerService;

namespace Tracker.Tests
{
    public class WorkoutPlanTest
    {
        [Fact]
        public void testWorkoutPlanExport()
        {
            // Create workout plan
            var userPreferences = new UserPreferences
            {
                daysAvailable = new List<string> { "Mon", "Tue" },
                timesAvailable = new List<string> { "Morning", "Evening" },
                workoutTypes = new List<string> { "Cardio", "Strength" },
                workoutGoal = "General"
            };

            var workoutPlan = new WorkoutPlan();
            workoutPlan.createWorkoutPlan(userPreferences);
            workoutPlan.exportWorkoutPlan();

            var expectedFilePath = "workoutPlan.json";
            var fileContent = File.ReadAllText(expectedFilePath);
            var deserializedLog = JsonSerializer.Deserialize<Dictionary<int, WorkoutSession>>(fileContent);

            // Check for JSON file
            Assert.True(File.Exists(expectedFilePath), "The workout plan JSON file was not created.");

            // Check JSON file content
            Assert.NotNull(deserializedLog);
            Assert.True(deserializedLog.ContainsKey(0), "The workout plan was not exported correctly.");
            Assert.Equal(0, deserializedLog[0].sessionID);
            Assert.Equal("Mon", deserializedLog[0].sessionDay);
            Assert.Equal("Morning", deserializedLog[0].sessionTime);
            Assert.Equal(15, deserializedLog[0].sessionDuration);
            Assert.True(deserializedLog[0].sessionWorkout?.name?.Length > 0);
            Assert.Contains(deserializedLog[0].sessionWorkout?.type, new[] { "Cardio", "Strength" });
            Assert.True(deserializedLog[0].sessionWorkout?.howTo?.Length > 0);

            Assert.Equal(1, deserializedLog[1].sessionID);
            Assert.Equal("Tue", deserializedLog[1].sessionDay);
            Assert.Contains(deserializedLog[1].sessionTime, new[] { "Morning", "Evening" });
            Assert.Equal(15, deserializedLog[1].sessionDuration);
            Assert.True(deserializedLog[1].sessionWorkout?.name?.Length > 0);
            Assert.Contains(deserializedLog[1].sessionWorkout?.type, new[] { "Cardio", "Strength" });
            Assert.True(deserializedLog[1].sessionWorkout?.howTo?.Length > 0);

            // Delete JSON file
            if (File.Exists(expectedFilePath))
            {
                File.Delete(expectedFilePath);
            }
        }
    }

    public class WorkoutLogTest
    {
        [Fact]
        public void testWorkoutLogExport()
        {
            // Create workout log entry
            var workoutLog = new WorkoutLog();
            var session = new WorkoutSession
            {
                sessionID = 0,
                sessionDay = "Mon",
                sessionTime = "Morning",
                sessionDuration = 15,
                sessionStatus = "Not Complete",
                sessionWorkout = new Workout
                {
                    name = "Running",
                    type = "Cardio",
                }
            };

            workoutLog.addSession(session);
            var expectedFilePath = "workoutLog.json";
            workoutLog.exportWorkoutLog();

            // Check for JSON file
            Assert.True(File.Exists(expectedFilePath), "The workout log JSON file was not created.");

            // Check JSON file content
            var fileContent = File.ReadAllText(expectedFilePath);
            var deserializedLog = JsonSerializer.Deserialize<Dictionary<int, WorkoutSession>>(fileContent);

            Assert.NotNull(deserializedLog);
            Assert.True(deserializedLog.ContainsKey(0), "The workout log was not exported correctly.");
            Assert.Equal(0, deserializedLog[0].sessionID);
            Assert.Equal("Mon", deserializedLog[0].sessionDay);
            Assert.Equal("Morning", deserializedLog[0].sessionTime);
            Assert.Equal(15, deserializedLog[0].sessionDuration);
            Assert.Equal("Not Complete", deserializedLog[0].sessionStatus);
            Assert.Equal("Running", deserializedLog[0].sessionWorkout?.name);
            Assert.Equal("Cardio", deserializedLog[0].sessionWorkout?.type);

            // Delete JSON file
            if (File.Exists(expectedFilePath))
            {
                File.Delete(expectedFilePath);
            }
        }
    }
}