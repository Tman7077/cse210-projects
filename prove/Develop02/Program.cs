using System;
using System.Security.Cryptography;

class Program
{
    /* extra points: I added an edit function, in Journal.cs line 49,
    which allows the user to edit an entry of their choosing from the currently loaded entries */
    static void Main(string[] args)
    {
        int choice = 0; // user's entry, should be 1-6
        int choices = 0; // number of times user has entered a choice
        // Load a journal object to keep track of all entries, and a Prompt object to keep track of which prompts have been displayed already
        Journal journal = new Journal();
        Prompt prompt = new Prompt();

        // function to repeat, allows the user to pick what they would like to do (write, load, save, etc.)
        void ChooseAction()
        {
            // if this is the user's first interaction, treat it as such; if not, ask "what else" they would like to do
            if (choices == 0)
            {
                Console.WriteLine("What would you like to do with your journal? Enter 1-6.");
            }
            else
            {
                Console.WriteLine("What else would you like to do? Enter 1-6.");
            }
            // display 5 options to the user, ask for input
            Console.WriteLine("1. Write in journal");
            Console.WriteLine("2. Display current journal");
            Console.WriteLine("3. Load a journal from a file");
            Console.WriteLine("4. Save current journal");
            Console.WriteLine("5. Edit an entry in current journal");
            Console.WriteLine("6. Quit");
            Console.Write("> ");
            choice = int.Parse(Console.ReadLine());

            // choose from 5 options based on user input
            switch (choice)
            {
                case 1: // write in journal
                    // if there is at least one prompt that has not already been answered
                    if (prompt._prompts.Count() > 0)
                    {
                        // create a new entry object, prompt the user, and add it to the current journal.
                        Entry entry = new Entry();
                        entry.PromptUser(prompt);
                        journal.AddEntry(entry);
                        Console.WriteLine("Entry recorded.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nYou've answered all of today's prompts!\n");
                    }
                    break;
                case 2: // display current journal
                    journal.Display(journal);
                    break;
                case 3: // load a journal from a file
                    // if the currently loaded journal has no entries
                    if (journal._entries is [])
                    {
                        PromptLoadJournal();
                    }
                    else
                    {
                        string entryEntries; // either "entry" or "entries" depending on number of loaded entries
                        string itThem; // either "it" or "them" depending on the number of loaded entries
                        if (journal._entries.Count() > 1)
                        {
                            entryEntries = "entries";
                            itThem = "them";
                        }
                        else
                        {
                            entryEntries = "entry";
                            itThem = "it";
                        }
                        // confirm with the user if they want to overwrite currently loaded entries with entries from a file
                        Console.Write($"You have {journal._entries.Count()} {entryEntries} loaded already. Would you like to overwrite {itThem}? Enter y/n.\n> ");
                        string shouldLoad = Console.ReadLine();
                        if (shouldLoad == "y")
                        {
                            PromptLoadJournal();
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case 4: // save current journal
                    journal.Save();
                    Console.WriteLine($"\nJournal saved as {journal._filename}\n");
                    break;
                case 5: // edit an entry in current journal
                    journal.Edit(journal);
                    break;
                case 6: // quit
                    // set choice to 0 to break the while loop and exit
                    choice = 0;
                    break;
                default: // if choice variable is not a number from 1-6.
                    Console.WriteLine("\nPlease enter 1-6.\n");
                    choice = -1;
                    break;
            }
        }

        void PromptLoadJournal()
        {
            // prompt the user for the name of the file they would like to load
            Console.Write("\nEnter the name of the file you would like to load.\n> ");
            string filename = Console.ReadLine();
            journal = journal.Load(filename);
            // remove the prompts that have been answered in the loaded journal from the remaining possibilities
            foreach (Entry entry in journal._entries)
            {
                prompt._prompts.Remove(entry._prompt);
            }
            Console.WriteLine("File loaded.");
        }
        
        do
        {
            ChooseAction();
            choices++;
        } while (choice != 0);
        
    }
}