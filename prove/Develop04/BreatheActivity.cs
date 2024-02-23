public class BreatheActivity: Activity
{
    public BreatheActivity(): base("breathing",
    "relax by walking your through breathing in and out slowly.|" +
    "clear your mind. Focus on your breathing.") {}

    public void Run()
    {
        DisplayStartMessage();
        ReadyGo(3);
        Thread.Sleep(1000);

        DateTime later = DateTime.Now.AddSeconds(GetRealDuration(8));

        while (DateTime.Now < later)
        {
            Console.Clear();
            Console.Write("Breathe in... ");
            Wait(4, false);
            Console.Write("\nBreathe out... ");
            Wait(4, false);
        }

        DisplayEndMessage();
    }
}