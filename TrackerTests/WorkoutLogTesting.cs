using TrackerService;

namespace WorkoutLogTesting
{
    public class WorkoutLogTesting
    {
        [Fact]
        public void addSessionToWorkoutLog()
        {
            // Create workout log and workout session
            var workoutLog = new WorkoutLog();
            var session = new WorkoutSession { sessionID = 0, sessionStatus = "Not Complete" };

            // Add session to workout log
            workoutLog.addSession(session);

            // Test new workout session
            Assert.True(workoutLog.workoutSessions.ContainsKey(0));
            Assert.Equal("Not Complete", workoutLog.workoutSessions[0].sessionStatus);
        }
    }
}
