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

    // instantiate an Activity with reflection info
    public ReflectActivity(): base("reflection",
    "reflect on times in your life when you have shown strength and resilience.|" +
    "recognize the power you have and how you can use it in other aspects of your life.") {}

    // run the Reflect activity
    public void Run()
    {
        string prompt = Select(_promptList); // select a prompt from the list to display to the user

        // if Select() does not return a usable prompt
        if (prompt == "empty")
        {
            Console.WriteLine("You have answered all of today's reflection prompts already.");
            Wait(3);
        }
        // if Select() returns a usable prompt
        else
        {
            // prompt the user for the duration of the activity and display the start message
            PromptDuration("reflection");
            DisplayStartMessage();

            // Prompt the user, allow them time to think (and hit enter), then tell them to start pondering
            Console.WriteLine("\nConsider the following prompt:");
            Console.WriteLine($"\n> {prompt}\n");
            _promptList.Remove(prompt);
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Now ponder on the following questions as they relate to this experience.");
            ReadyGo(3);

            int duration = GetRealDuration(7); // duration as a multiple of 7 seconds
            int secondsPerQuestion = 7;        // seconds for which to display each question

            // if the duration is greater than 7 seconds per question in _questionList
            if (duration > 7 * _questionList.Count())
            {
                // set duration equal to a multiple of the length of _questionList
                duration = GetRealDuration(_questionList.Count());
                // set the seconds per question to evenly spread out each question
                secondsPerQuestion = duration / _questionList.Count();
            }
            DateTime later = DateTime.Now.AddSeconds(duration); // the time until when the activity should run
            // (this will be an even multiple of either 7 seconds or the length of _questionList
            // to account for input times greater than 7 * _questionList.Count())

            while (DateTime.Now < later)
            {
                string question = Select(_questionList); // question from _questionList

                // write the question, wait for (secondsPerQuestion) seconds, and remove that question from the list
                Console.Write($"\n\n{question} ");
                Wait(secondsPerQuestion);
                _questionList.Remove(question);
            }

            // thank the user for participating
            DisplayEndMessage();
        }
    }
}