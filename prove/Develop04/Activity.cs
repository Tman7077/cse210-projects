public class Activity
{
    private int _duration;        // the minimum number of seconds for which the program will run
    private string _startMessage; // the message to display at the start of a new activity
    private string _endMessage;   // the message to display at the end of an activity

    // instantiates an Activity given the sub-activity's name and it's description;
    // the user will be prompted for the duration of the activity when it is run,
    // at which time the end message will also be set
    protected Activity(string name, string description)
    {
        SetStartMessage(name, description);
    }

    // set the start message, given the activity name and description
    private void SetStartMessage(string name, string description)
    {
        string[] splitDescription = description.Split("|"); // string array that holds the meat of the first and second sentences
        _startMessage =
        "Welcome to the " + name + " activity. " +
        "This activity will help you " + splitDescription[0] +
        " This will help you " + splitDescription[1];       // start message string
    }
    // set the end message, given the activity name
    private void SetEndMessage(string name)
    {
        _endMessage =  $"You have completed {_duration} seconds of the {name} activity.";
    }

    // prompt the user for the duration of the activity, given the name of the activity
    protected void PromptDuration(string name)
        {
            Console.WriteLine($"For how many seconds would you like to do the {name} activity?");
            _duration = int.Parse(Console.ReadLine());
            
            // because the end message includes the duration, set it now
            SetEndMessage(name);
        }
    // clear the console, display the start message and wait two seconds
    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine(_startMessage);
        Thread.Sleep(2000);
    }
    // display the end message and display a spinner for 5 seconds
    protected void DisplayEndMessage()
    {
        Console.WriteLine("\n");
        Console.Write($"{_endMessage} ");
        Wait(5);
    }
    // Display a waiting animation, given the number of seconds for which to display and the type of animation (default: spinner)
    protected void Wait(int seconds, bool spin = true)
    {
        // if display should be a spinner
        if (spin)
        {
            DateTime later = DateTime.Now.AddSeconds(seconds);             // until when spinner should be displayed
            List<string> spinner = new List<string> {"|", "/", "─", "\\"}; // glyphs through which function will iterate to make spinner look
            int i = 0; // index of spinner list to display

            // while it is still before the time to stop displaying spinner
            while (DateTime.Now < later)
            {
                // display one of the spinner glyphs and wait a quarter second, and increment i
                Console.Write(spinner[i]);
                Thread.Sleep(250);
                i++;

                // set i back to 0 if it past the end of the spinner glyph list's length
                if (i >= spinner.Count())
                {
                    i = 0;
                }

                // remove the previous glyph to be replaced by the next iteration of this loop
                Console.Write("\b \b");
            }
        }
        // if display should be a countdown
        else
        {
            // for as many seconds as the wait timer specifies, greater than 0, with decrements of 1
            for (int i = seconds; i > 0; i--)
            {
                // write the second value as a string, and wait 1 second
                Console.Write(i.ToString());
                Thread.Sleep(1000);
                
                int numDigits = i.ToString().Count(); // number of digits in i, aka seconds

                // overwrite the digit(s) in i (seconds)─ accounts for as many digits as i is
                for (int x = numDigits; x > 0; x--)
                {
                    Console.Write("\b");
                }
                for (int x = numDigits; x > 0; x--)
                {
                    Console.Write(" ");
                }
                for (int x = numDigits; x > 0; x--)
                {
                    Console.Write("\b");
                }
            }
        }
    }
    // returns a random string selected from a list, or "empty" if there are no mroe items in the list
    protected string Select(List<string> list)
    {
        int length = list.Count();
        if (length == 0)
        {
            return "empty";
        }
        else
        {
            int i = new Random().Next(0,length);
            return list[i];
        }
    }
    // Slowly writes "Ready... Go.", given input seconds
    protected void ReadyGo(int seconds)
    {
        Console.Write("\nReady");

        double secondsPerPeriod = Math.Ceiling((float)(seconds / 3)); // smallest integer greater than 1/3 of the input seconds

        // write one period every (secondsPerPeriod) seconds
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000 * (int)secondsPerPeriod);
        }

        Console.Write(" Go.\n");
    }
    // returns the "real" duration that an activity should take, given how many seconds each iteration/part of an activity takes
    protected int GetRealDuration(int mod)
    {
        int difference = 0; // the difference between user-input seconds and a multiple of the passed seconds

        // if there is actually a difference (e.g. user input 20, but it has to be a multiple of 8, difference = 4)
        if (_duration % mod != 0)
        {
            difference = mod - _duration % mod;
        }

        // return the lowest multiple of passed seconds greater than the user-input seconds, minimum: passed seconds
        return Math.Max(mod, _duration + difference);
    }
}