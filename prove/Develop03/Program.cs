using System;

class Program
{
    //www.plantuml.com/plantuml/png/RP71IWCn48RlynHxp4AVe8WKB6WFeYZeGMH9ar63sMJ9p5ONwRkRR3Tf3ZqbcVppp_yn6s8PUEmjA2k9cYVym81E8Vn1j_V-UzqG1-C-eLDVSc0CwyOuXkw0WP3cnzixGEaJRNMl3LPDRR1gvi4loMKfeDFdPmjmYrovbXoFCcf4o3-v7WL53Jkw7osRmUBiIAazPh79CrTozED2_go26NWCCpdbHoJS6iN6EnccgqnoEg-XAp7gwHtZBvUyK8n5MzqlTRPHZ1OLYpo_mgi2RWqDLaw9uU2DXeSzgUJ9fbzMadbtTEFxmIAZdUwCrkX4_ihShpxeXFmJp_Eo3PtaYnYIIjII5Y0gwiKSOODEZxtz1m00

    // exceeding requirements: in Scripture.cs line 6, there is a dictionary of all Book of Mormon doctrinal mastery scriptures,
    // from which the program randomly selects for the user to memorize
    static void Main(string[] args)
    {
        // select a random scripture from the dictionary of scriptures and instantiate it as a Scripture object
        // Select() could also take an input of a scripture reference to select that scripture specifically
        Scripture scripture = new Scripture().Select();

        string userInput; // nothing if the user wants to continue, something (quit, usually), if they want to exit
        int times = 0;    // number of times the user has continued
        do
        {
            // clear the console, display the current state of the scripture (including blank lines if applicable), and prompt the user
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nHit enter to continue, or type quit to quit.");

            // scripture.Obscure obscures some of the words of the scripture and returns true if there is more left to obscure, otherwise it returns false
            bool shouldContinue = scripture.Obscure(times);
            times++;

            // if there is more scripture left to obscure, prompt the user if they want to continue, otherwise auto-quit
            if (shouldContinue)
            {
                userInput = Console.ReadLine();
            }
            else
            {
                // this Console.ReadLine is just to allow the user to hit enter one more time before the program quits, it doesn't actually use the input for anything
                Console.ReadLine();
                userInput = "quit";
            }
        } while (userInput == "");
    }
}