using System;
public class Prompt {
    // create a list of prompts
    public List<string> _prompts = new List<string> {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "How did you see the hand of the Lord in your life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do over today, what would it be?",
        "What can you do to better include God in your life tomorrow?",
        "How did your actions today prepare you for a better future?"
    };

    // pick and return a prompt from the currently available prompts
    public string Generate() {
        Random rnd = new Random();
        int _promptNumber = rnd.Next(0,_prompts.Count());
        string prompt = _prompts[_promptNumber];
        // remove the selected prompt from the available list for the next random generation
        _prompts.RemoveAt(_promptNumber);
        return prompt;
    }
}