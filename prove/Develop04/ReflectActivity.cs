public class ReflectActivity: Activity
{
    private List<string> _promptList = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questionList = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What was your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectActivity(): base("reflection",
    "reflect on times in your life when you have shown strength and resilience.|" +
    "recognize the power you have and how you can use it in other aspects of your life.") {}

    public void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("\nConsider the following prompt:");
        string prompt = Select(_promptList);
        Console.WriteLine($"\n> {prompt}\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on the following questions as they relate to this experience.");
        ReadyGo(3);

        int duration = GetRealDuration(7);
        int secondsPerQuestion = 7;
        if (duration > 7 * _questionList.Count())
        {
            duration = GetRealDuration(_questionList.Count());
            secondsPerQuestion = duration / _questionList.Count();
        }
        DateTime later = DateTime.Now.AddSeconds(duration);
        
        string question;

        while (DateTime.Now < later)
        {
            question = Select(_questionList);
            Console.Write($"\n\n{question} ");
            Wait(secondsPerQuestion);
            _questionList.Remove(question);
        }

        DisplayEndMessage();
    }
}