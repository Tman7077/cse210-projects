using System;
using System.IO;
public class Journal {
    // current date in readable format, filename based on date, and a list of entries
    public string _date = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
    public string _filename = $"journal_{DateTime.Now.ToString("MM-dd-yyyy")}.txt";
    public List<Entry> _entries = new List<Entry>();

    // add the passed entry to the list of entries
    public void AddEntry(Entry entry) {
        _entries.Add(entry);
    }

    // display the date (readable) followed by each currently loaded prompt and entry
    public void Display() {
        Console.WriteLine($"\n{_date}\n");
        foreach (Entry entry in _entries) {
            Console.WriteLine($"{entry._prompt}\n{entry._userEntry}\n");
        }
    }

    // save currently loaded entries to a file
    public void Save() {
        List<string> lines = new List<string> {_date}; // list of lines to write, starting with the readable date
        // add a prompt line followed by an entry line for each entry in the list
        foreach (Entry entry in _entries) {
            lines.Add(entry._prompt);
            lines.Add(entry._userEntry);
        }
        // write each line to a text file
        using (StreamWriter file = new StreamWriter(_filename)) {
            foreach (string line in lines) {
                file.WriteLine(line);
            }
        }
    }

    // load a journal from a file
    public Journal Load(string filename) {
        // create a new journal instance, read each line to a string array
        Journal journal = new Journal();
        string[] lines = System.IO.File.ReadAllLines(filename);
        // set the first line to journal's date, and the journal's filename to the file's name
        string date = lines[0];
        journal._date = date;
        journal._filename = filename;
        // iterate through lines to load each prompt and entry into their respective Entry objects
        for (int i = 1; i < lines.Count(); i++) {
            Entry entry = new Entry();
            if (i % 2 == 1) {
                entry._prompt = lines[i];
                entry._userEntry = lines[i+1];
                journal._entries.Add(entry);
            }
        }
        return journal;
    }
}