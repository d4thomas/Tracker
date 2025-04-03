namespace TrackerService;

public class Workout
{
    // Initialize workout properties
    public string? name { get; set; }
    public string? type { get; set; }
    public string? howTo { get; set; }

    // Required for JSON deserialization
    public Workout() { }

    public Workout(string name, string type, string howTo)
    {
        // Create workout
        this.name = name;
        this.type = type;
        this.howTo = howTo;
    }

    public static Dictionary<string, Workout> Workouts = new Dictionary<string, Workout>
    {
        // Create defined workouts

        // Strength workouts
        { "Push-Ups", new Workout("Push-Ups", "Strength", "Start in a plank position, lower your body until your chest nearly touches the floor, then push back up.") },
        { "Squats", new Workout("Squats", "Strength", "Stand with feet shoulder-width apart, lower your hips until thighs are parallel to the ground, then return to standing.") },
        { "Deadlifts", new Workout("Deadlifts", "Strength", "Lift a barbell from the ground to hip level while keeping your back straight.") },
        { "Bench Press", new Workout("Bench Press", "Strength", "Lie on a bench, lower the barbell to your chest, then press it back up.") },
        { "Pull-Ups", new Workout("Pull-Ups", "Strength", "Hang from a bar with palms facing away, pull your body up until your chin is above the bar.") },
        { "Lunges", new Workout("Lunges", "Strength", "Step forward with one leg, lower your hips until both knees are bent at 90 degrees, then return to standing.") },
        { "Plank", new Workout("Plank", "Strength", "Hold a push-up position with your body straight and core engaged.") },
        { "Overhead Press", new Workout("Overhead Press", "Strength", "Lift a barbell or dumbbells from shoulder height to overhead.") },
        { "Bicep Curls", new Workout("Bicep Curls", "Strength", "Hold dumbbells and curl them toward your shoulders.") },

        // Cardio workouts
        { "Running", new Workout("Running", "Cardio", "Run at a steady pace for a set distance or time.") },
        { "Jumping Jacks", new Workout("Jumping Jacks", "Cardio", "Jump while spreading your legs and arms, then return to the starting position.") },
        { "Cycling", new Workout("Cycling", "Cardio", "Ride a bicycle at a steady pace for a set distance or time.") },
        { "Burpees", new Workout("Burpees", "Cardio", "Start in a standing position, drop into a squat, kick your feet back into a plank, return to squat, and jump up.") },
        { "Rowing", new Workout("Rowing", "Cardio", "Use a rowing machine to simulate rowing a boat.") },
        { "High Knees", new Workout("High Knees", "Cardio", "Run in place while lifting your knees as high as possible.") },
        { "Mountain Climbers", new Workout("Mountain Climbers", "Cardio", "Start in a plank position and alternate driving your knees toward your chest.") },
        { "Jump Rope", new Workout("Jump Rope", "Cardio", "Jump over a rope swung under your feet.") },
        { "Stair Climbing", new Workout("Stair Climbing", "Cardio", "Run or walk up and down stairs repeatedly.") },

        // Flexibility workouts
        { "Yoga - Downward Dog", new Workout("Yoga - Downward Dog", "Flexibility", "Start on all fours, lift your hips to form an inverted V-shape, and hold.") },
        { "Hamstring Stretch", new Workout("Hamstring Stretch", "Flexibility", "Sit on the floor, extend one leg, and reach for your toes.") },
        { "Cat-Cow Stretch", new Workout("Cat-Cow Stretch", "Flexibility", "Alternate between arching and rounding your back while on all fours.") },
        { "Side Stretch", new Workout("Side Stretch", "Flexibility", "Stand tall, reach one arm overhead, and lean to the opposite side.") },
        { "Butterfly Stretch", new Workout("Butterfly Stretch", "Flexibility", "Sit on the floor, bring the soles of your feet together, and gently press your knees toward the ground.") },
        { "Seated Forward Bend", new Workout("Seated Forward Bend", "Flexibility", "Sit with legs extended and reach forward toward your toes.") },
        { "Chest Opener", new Workout("Chest Opener", "Flexibility", "Clasp your hands behind your back and lift them while opening your chest.") },
        { "Hip Flexor Stretch", new Workout("Hip Flexor Stretch", "Flexibility", "Kneel on one knee, push your hips forward, and stretch the front of your hip.") },
        { "Spinal Twist", new Workout("Spinal Twist", "Flexibility", "Sit on the floor, cross one leg over the other, and twist your torso toward the bent knee.") },

        // Recovery workouts
        { "Foam Rolling", new Workout("Foam Rolling", "Recovery", "Use a foam roller to massage sore muscles.") },
        { "Child's Pose", new Workout("Child's Pose", "Recovery", "Kneel on the floor, sit back on your heels, and stretch your arms forward.") },
        { "Light Walking", new Workout("Light Walking", "Recovery", "Walk at a slow pace to cool down and recover.") },
        { "Breathing Exercises", new Workout("Breathing Exercises", "Recovery", "Practice deep, controlled breathing to relax and recover.") },
        { "Legs-Up-The-Wall Pose", new Workout("Legs-Up-The-Wall Pose", "Recovery", "Lie on your back with your legs extended up against a wall.") },
        { "Neck Stretch", new Workout("Neck Stretch", "Recovery", "Gently tilt your head to one side to stretch your neck.") },
        { "Wrist Stretch", new Workout("Wrist Stretch", "Recovery", "Extend one arm forward and gently pull back on your fingers with the opposite hand.") },
        { "Ankle Rolls", new Workout("Ankle Rolls", "Recovery", "Sit or lie down and rotate your ankles in circles.") },
        { "Meditation", new Workout("Meditation", "Recovery", "Sit quietly and focus on your breath or a calming thought.") }
    };
}
