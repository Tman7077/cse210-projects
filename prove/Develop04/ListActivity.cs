public class ListActivity: Activity
{
    private List<string> _promptList = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListActivity(): base("listing",
    "reflect on the good things in your life by having you list as many things as you can in a certain area.|" +
    "see that there is good in your life, despite the inevitable bad things.") {}

    public void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("\nList as many responses to the following prompt as you can.");
        string prompt = Select(_promptList);
        Console.WriteLine(prompt);
        ReadyGo(5);

        DateTime later = DateTime.Now.AddSeconds(GetRealDuration(10));
        List<string> responses = new List<string>();
        while (DateTime.Now < later)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.Write($"You listed {responses.Count()} items. Well done!");
        DisplayEndMessage();
    }
}