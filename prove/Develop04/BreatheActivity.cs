public class BreatheActivity: Activity
{
    // instantiate an Activity with breathing info
    public BreatheActivity(): base("breathing",
    "relax by walking your through breathing in and out slowly.|" +
    "clear your mind. Focus on your breathing.") {}

    // run the Breathe activity
    public void Run()
    {
        // prompt the user for the duration of the activity, display the start message, ready them, and wait
        PromptDuration();
        DisplayStartMessage();
        ReadyGo(3);
        Thread.Sleep(1000);

        DateTime later = DateTime.Now.AddSeconds(GetRealDuration(8)); // the time until when the activity should run (an even multiple of 8 seconds)

        while (DateTime.Now < later)
        {
            // display a message to breathe in, then out, each with a 4 second countdown, on a clear console
            Console.Clear();
            Console.Write("Breathe in... ");
            Wait(4, false);
            Console.Write("\nBreathe out... ");
            Wait(4, false);
        }

        // thank the user for participating
        DisplayEndMessage();
    }
}