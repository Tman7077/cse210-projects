using System;

class Program
{
    //www.plantuml.com/plantuml/png/VL6zJiCm4Dxz59Qwk0fvWQX21GcnG0SwC28J7yLIuWJVkH82tXsR1BYuLjVl_-mjalOK-awqdKQKLotPewLtyI5g-VH3tWEYFa0ZaRnrXuI3CmLKpzwTxXUu0Moz7SaERW47hoVCEX9YzTUjIa4NaiKma8UiHSoz1TgpsMhDEYDtuymfivAFsf92Q0TdSCfgv76m9b9xwA0bTMUHDfF-yj_v9SJySW_madHno_8DHp_q8oLt8tb6uju2O78KM54L4bL-RXG5Lz3DwoNRT-r1qslCPlEgKxHSmMJB1bQGvlFuyzUBAZUeub_kGlyCFad1nD94JPEOEn_qYydDPrqNdZ4JyEDAV7xO5fm9VVSD
    static void Main(string[] args)
    {
        int choice = 0; // the user's choice, from 1-5

        // instantiate one of each of the activities that needs to stay in memory
        // (for keeping track of which prompts have been used)
        ListActivity list = new ListActivity();
        ReflectActivity reflect = new ReflectActivity();

        // function that displays the menu to the user and acts on their choices
        void Menu() {
            Console.Clear();

            // display the menu choices
            Console.WriteLine("Enter a number corresponding to an option below:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start listing activity");
            Console.WriteLine("  3. Start reflection activity");
            Console.WriteLine("  4. Start senses activity");
            Console.WriteLine("  5. Quit");
            Console.Write("> ");
            choice = int.Parse(Console.ReadLine()); // the user's input as an int

            // choose from 5 options based on user input
            switch (choice)
            {
                case 1:  // breathing activity
                    new BreatheActivity().Run();
                    break;
                case 2:  // listing activity
                    list.Run();
                    break;
                case 3:  // reflection activity
                    reflect.Run();
                    break;
                case 4:  // sense activity
                    new SenseActivity().Run();
                    break;
                case 5:  // quit
                    // set choice to 0 to break the while loop and exit
                    choice = 0;
                    Console.Clear();
                    break;
                default: // if the user input a number that is not a valid choice
                    Console.WriteLine("Please enter 1-5.");
                    Thread.Sleep(2000);
                    break;
            }
        }

        // call the menu to display, and do so as many times as the user doesn't quit
        do
        {
            Menu();
        } while (choice != 0);
    }
}