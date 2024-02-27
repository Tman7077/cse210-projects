public class SenseActivity: Activity
{
    private List<string> _promptList = new List<string>
    {
        "From your nose to your toes, think of something you can touch, and focus on how it feels.",
        "Look around the room and focus on something you can see, and think about what it looks like.",
        "Listen closely and focus on something you can hear, loud or quiet.",
        "Think of something you can smell, and focus on its scent.",
        "Think of the taste of something, from your favorite food to what you had for lunch, and focus on that taste."
    };

    // instantiate an Activity with sense info
    public SenseActivity(): base("senses",
    "relax by focusing on each of your 5 senses.|" +
    "be more grounded. Clear your mind, and get ready to focus on your senses.") {}

    // run the Sense activity
    public void Run()
    {
        // prompt the user for the duration of the activity, display the start message, and ready them
        PromptDuration("senses");
        DisplayStartMessage();
        ReadyGo(3);

        int duration = GetRealDuration(10); // duration as a multiple of 10 seconds
        int secondsPerPrompt = 10;          // seconds for which to display each question

        // if the duration is greater than 10 seconds per question in _promptList
        if (duration > 10 * _promptList.Count())
        {
            // set duration equal to a multiple of the length of _promptList
            duration = GetRealDuration(_promptList.Count());
                // set the seconds per question to evenly spread out each prompt
            secondsPerPrompt = duration / _promptList.Count();
        }
        DateTime later = DateTime.Now.AddSeconds(duration); // the time until when the activity should run
        // (this will be an even multiple of either 10 seconds or the length of _promptList
        // to account for input times greater than 10 * _promptList.Count())

        while (DateTime.Now < later)
        {
            string prompt = Select(_promptList); // prompt from _promptList

            // write the prompt, wait for (secondsPerPrompt) seconds, and remove that prompt from the list
            Console.Write($"\n\n{prompt} ");
            Wait(secondsPerPrompt);
            _promptList.Remove(prompt);
        }

        // thank the user for participating
        DisplayEndMessage();
    }
}