using System;
public class Entry {
    public string _prompt = ""; // the user's prompt
    public string _userEntry = ""; // the user's answer
    public void PromptUser(Prompt prompt) {
        // generate a prompt and ask the user's input
        _prompt = prompt.Generate();
        Console.Write($"{_prompt}\n> ");
        _userEntry = Console.ReadLine();
    }
}