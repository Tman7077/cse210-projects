using System.Security.Cryptography.X509Certificates;

public class Activity
{
    private int _duration;
    private string _startMessage;
    private string _endMessage;

    protected Activity(string name, string description)
    {
        PromptDuration(name);
        SetStartMessage(name, description);
        SetEndMessage(name);
    }

    private void PromptDuration(string name)
        {
            Console.WriteLine($"For how many seconds would you like to do the {name} activity?");
            _duration = int.Parse(Console.ReadLine());
        }
    private void SetStartMessage(string name, string description)
    {
        string[] splitDescription = description.Split("|");
        _startMessage =
        "Welcome to the " + name + " activity. " +
        "This activity will help you " + splitDescription[0] +
        " This will help you " + splitDescription[1];
    }
    private void SetEndMessage(string name)
    {
        _endMessage =  $"You have completed {_duration} seconds of the {name} activity.";
    }
    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine(_startMessage);
        Thread.Sleep(2000);
    }
    protected void DisplayEndMessage()
    {
        Console.WriteLine("\n");
        Console.Write($"{_endMessage} ");
        Wait(5);
    }
    public void Wait(int seconds, bool spin = true)
    {
        if (spin)
        {
            DateTime later = DateTime.Now.AddSeconds(seconds);
            List<string> spinner = new List<string> {"|", "/", "─", "\\"};
            int i = 0;
            while (DateTime.Now < later)
            {
                Console.Write(spinner[i]);
                Thread.Sleep(250);
                i++;
                if (i >= spinner.Count())
                {
                    i = 0;
                }
                Console.Write("\b \b");
            }
        }
        else
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i.ToString());
                Thread.Sleep(1000);
                if (i >= 9)
                {
                    Console.Write("\b\b  \b\b");
                }
                else
                {
                    Console.Write("\b \b");
                }
            }
        }
    }
    protected string Select(List<string> list)
    {
        int i = new Random().Next(0,list.Count());
        return list[i];
    }
    protected void ReadyGo(int seconds)
    {
        Console.Write("\nReady");

        double secondsPerPeriod = Math.Ceiling((float)(seconds / 3));

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000 * (int)secondsPerPeriod);
        }
        Console.Write(" Go.\n");
    }
    protected int GetRealDuration(int mod)
    {
        int difference = 0;
        if (_duration % mod != 0)
        {
            difference = mod - _duration % mod;
        }
        return Math.Max(mod, _duration + difference);
    }
}