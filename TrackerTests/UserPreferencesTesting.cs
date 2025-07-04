using TrackerService;

namespace TrackerServiceTests
{
    public class UserPreferencesTesting
    {
        private UserPreferences createUserPreferences(string input)
        {
            var userPreferences = new UserPreferences();
            Console.SetIn(new StringReader(input));
            return userPreferences;
        }

        [Fact]
        public void getDaysAvailableWithValidInput()
        {
            var userPreferences = createUserPreferences("Mon\nTue\ndone\n");

            userPreferences.getDaysAvailable();

            var expected = new List<string> { "Mon", "Tue" };
            Assert.Equal(expected, userPreferences.daysAvailable);
        }

        [Fact]
        public void getDaysAvailableWithEmptyInput()
        {
            var userPreferences = createUserPreferences("\n");

            userPreferences.getDaysAvailable();

            Assert.Equal(userPreferences.validDayOptions, userPreferences.daysAvailable);
        }

        [Fact]
        public void getTimesAvailableWithValidInput()
        {
            var userPreferences = createUserPreferences("Morning\nEvening\ndone\n");

            userPreferences.getTimesAvailable();

            var expected = new List<string> { "Morning", "Evening" };
            Assert.Equal(expected, userPreferences.timesAvailable);
        }

        [Fact]
        public void getTimesAvailableWithEmptyInput()
        {
            var userPreferences = createUserPreferences("\n");

            userPreferences.getTimesAvailable();

            Assert.Equal(userPreferences.validTimeOptions, userPreferences.timesAvailable);
        }

        [Fact]
        public void getWorkoutTypesWithValidInput()
        {
            var userPreferences = createUserPreferences("Cardio\nFlexibility\ndone\n");

            userPreferences.getWorkoutTypes();

            var expected = new List<string> { "Cardio", "Flexibility" };
            Assert.Equal(expected, userPreferences.workoutTypes);
        }

        [Fact]
        public void getWorkoutTypesWithEmptyInput()
        {
            var userPreferences = createUserPreferences("\n");

            userPreferences.getWorkoutTypes();

            Assert.Equal(userPreferences.validWorkoutTypes, userPreferences.workoutTypes);
        }

        [Fact]
        public void getWorkoutGoalWithValidInput()
        {
            var userPreferences = createUserPreferences("Strength\n");

            userPreferences.getWorkoutGoal();

            Assert.Equal("Strength", userPreferences.workoutGoal);
        }

        [Fact]
        public void getWorkoutGoalWithEmptyInput()
        {
            var userPreferences = createUserPreferences("\n");

            userPreferences.getWorkoutGoal();

            Assert.Equal("General", userPreferences.workoutGoal);
        }
    }
}