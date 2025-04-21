
using System;
using System.IO;
using System.Collections.Generic;
using TrackerService;
using Xunit;

namespace TrackerServiceTests
{
    public class UserPreferencesTests
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
    }
}
