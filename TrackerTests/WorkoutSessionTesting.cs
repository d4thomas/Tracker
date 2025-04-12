namespace TrackerService.Tests
{
    public class WorkoutSessionTesting
    {
        public WorkoutSessionTesting()
        {
            // Create workouts
            Workout.Workouts = new Dictionary<string, Workout>
            {
                { "0", new Workout { name = "Push-Ups", type = "Strength", howTo = "Start in a plank position, lower your body until your chest nearly touches the floor, then push back up." } },
                { "1", new Workout { name = "Cycling", type = "Cardio", howTo = "Ride a bicycle at a steady pace for a set distance or time." } },
                { "2", new Workout { name = "Bench Press", type = "Strength", howTo = "Lie on a bench, lower the barbell to your chest, then press it back up." } },
            };
        }

        [Fact]
        public void testWorkoutGoal()
        {
            // Create workout session with Strength as goal
            List<string> workoutTypes = new List<string> { "Strength", "Cardio" };
            var session = new WorkoutSession(0, "Mon", "Morning", workoutTypes, "Strength");

            // Test for only Strength workouts
            Assert.Equal(0, session.sessionID);
            Assert.Equal("Mon", session.sessionDay);
            Assert.Equal("Morning", session.sessionTime);
            Assert.Equal(15, session.sessionDuration);
            Assert.NotNull(session.sessionWorkout);
            Assert.Equal("Strength", session.sessionWorkout!.type);
            Assert.Contains(session.sessionWorkout.name, new[] { "Push-Ups", "Bench Press" });
        }
    }
}