using System;
using System.Diagnostics.Tracing;
using System.IO;
public class Journal
{
    // current date in readable format, filename based on date, and a list of entries
    public string _date = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
    public string _filename = $"journal_{DateTime.Now.ToString("MM-dd-yyyy")}.txt";
    public List<Entry> _entries = new List<Entry>();

    // add the passed entry to the list of entries
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // display the date (readable) followed by each currently loaded prompt and entry.
    // displayNumbers, false by default, will number the entries, used in the case that the user would like to edit an entry
    public void Display(Journal journal, bool displayNumbers = false)
    {
        // if there is at least one entry in the current journal
        if (journal._entries is not [])
        {
            Console.WriteLine($"\n{_date}");
            int i = 1; // to number the entries if numbering is displayed
            if (displayNumbers)
            {
                // display numbers in front of entries (for entry editing purposes)
                foreach (Entry entry in _entries)
                {
                    Console.WriteLine($"{i}. {entry._prompt}\n{entry._userEntry}\n");
                    i++;
                }
            }
            else
            {
                // display entries normally
                foreach (Entry entry in _entries)
                {
                    Console.WriteLine($"{entry._prompt}\n{entry._userEntry}\n");
                }
            }
        }
        else
        {
            Console.WriteLine("\nThere is nothing in the currently loaded journal.\n");
        }
    }

    // edit an entry in the given journal
    public void Edit(Journal journal)
    {
        int length = journal._entries.Count(); // number of entries in journal
        int index = 0; // index at which the user wwould like to edit the entry, zero unless edited
        // if journal is empty, call the above and tell the user such, then don't continue this function.
        if (length == 0)
        {
            Display(journal);
            return;
        // if there is more than one entry, ask the user which entry they would like to edit; if not, edit the only one there
        }
        else if (length > 1)
        {
            Display(journal, true);
            Console.Write($"Which entry would you like to edit? Enter 1-{length}.\n> ");
            index = int.Parse(Console.ReadLine()) - 1;
        }
        Entry entry = journal._entries[index];
        Console.WriteLine($"You are now editing journal entry {index+1}.");
        Console.Write($"{entry._prompt}\nYour original response (you may copy or rewrite):\n> {entry._userEntry}\nYour edit: ");
        entry._userEntry = Console.ReadLine();
        Console.WriteLine("Edit accepted.\n");
    }

    // save currently loaded entries to a file
    public void Save()
    {
        List<string> lines = new List<string> {_date}; // list of lines to write, starting with the readable date
        // add a prompt line followed by an entry line for each entry in the list
        foreach (Entry entry in _entries)
        {
            lines.Add(entry._prompt);
            lines.Add(entry._userEntry);
        }
        // write each line to a text file
        using (StreamWriter file = new StreamWriter(_filename))
        {
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }
    }

    // load a journal from a file
    public Journal Load(string filename)
    {
        // create a new journal instance, read each line to a string array
        Journal journal = new Journal();
        string[] lines = System.IO.File.ReadAllLines(filename);
        // set the first line to journal's date, and the journal's filename to the file's name
        string date = lines[0];
        journal._date = date;
        journal._filename = filename;
        // iterate through lines to load each prompt and entry into their respective Entry objects
        for (int i = 1; i < lines.Count(); i++)
        {
            Entry entry = new Entry();
            if (i % 2 == 1)
            {
                entry._prompt = lines[i];
                entry._userEntry = lines[i+1];
                journal._entries.Add(entry);
            }
        }
        return journal;
    }
}