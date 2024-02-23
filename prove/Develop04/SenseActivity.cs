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

    public SenseActivity(): base("senses",
    "relax by focusing on each of your 5 senses.|" +
    "be more grounded. Clear your mind, and get ready to focus on your senses.") {}

    public void Run()
    {
        DisplayStartMessage();
        ReadyGo(3);

        int duration = GetRealDuration(10);
        int secondsPerPrompt = 10;
        if (duration > 10 * _promptList.Count())
        {
            duration = GetRealDuration(_promptList.Count());
            secondsPerPrompt = duration / _promptList.Count();
        }
        DateTime later = DateTime.Now.AddSeconds(duration);
        
        string prompt;

        while (DateTime.Now < later)
        {
            prompt = Select(_promptList);
            Console.Write($"\n\n{prompt} ");
            Wait(secondsPerPrompt);
            _promptList.Remove(prompt);
        }

        DisplayEndMessage();
    }
}