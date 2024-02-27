public class ListActivity: Activity
{
    private List<string> _promptList = new List<string> // list of prompts to display to the user
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // instantiate an Activity with listing info
    public ListActivity(): base("listing",
    "reflect on the good things in your life by having you list as many things as you can in a certain area.|" +
    "see that there is good in your life, despite the inevitable bad things.") {}

    // run the List activity
    public void Run()
    {
        string prompt = Select(_promptList); // select a prompt from the list to display to the user

        // if Select() does not return a usable prompt
        if (prompt == "empty")
        {
            Console.WriteLine("You have answered all of today's listing prompts already.");
            Wait(3);
        }
        // if Select() returns a usable prompt
        else
        {
            // prompt the user for the duration of the activity and display the start message
            PromptDuration("listing");
            DisplayStartMessage();

            // display a prompt to the user, remove it from _promptList, and wait for 5 seconds to let them think
            Console.WriteLine("\nList as many responses to the following prompt as you can.");
            Console.WriteLine(prompt);
            _promptList.Remove(prompt);
            ReadyGo(6);

            DateTime later = DateTime.Now.AddSeconds(GetRealDuration(10)); // the time until when the activity should run (an even multiple of 10 seconds)
            List<string> responses = new List<string>(); // list of the user's responses to count later

            while (DateTime.Now < later)
            {
                // prompt for, then add to responses, the user's input
                Console.Write("> ");
                responses.Add(Console.ReadLine());
            }

            // thank the user for participating
            Console.Write($"You listed {responses.Count()} items. Well done!");
            DisplayEndMessage();
        }
    }
}