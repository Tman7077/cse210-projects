using System;
//www.plantuml.com/plantuml/png/bP91IyGm48Nl-HKvAhBqNZoiKDsB8EWFa24PtM2Qb9b9eSZ-TpKDJLilUcjUfzzxRveZ2v2atYlZWLdVZnX4VQg3VXKd7blDGYwy_mWMsP0RnCMmaK4sO-BwpHci9MHkzTtyeDIDxXmF7gONWM21R8S2plFLTQl7wEptGDEKaOVa_Uvrqwm8vqZIrM0Bub8AFQAHH3XNuW7X0scTpi00nidKQXUaHjluxfdFQ32xpLJYSIZT5lBVG4z9R8nq0ZbZ_YpptYAX0PP_mag4qbG8KJP5SybwPjdzDnDJ49hMhYUKcPhTYdvH-PBesyDXsMvLwcwgzglc4ODDlVy2
class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>
        {
            new Lecture("Lecture Title", "Lecture Description", "January 1st", "12:00 p.m.", new Address("123 Lecture St.", "Lecture City", "New Lectureshire", "ULA"), "Lecture Speaker", 2),
            new Reception("Reception Title", "Reception Description", "January 2nd", "12:00 p.m.", new Address("456 Reception St.", "Reception City", "New Receptionshire", "URA"), "re@cep.tion"),
            new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", "January 3rd", "12:00 p.m.", new Address("789 Outdoor Gathering St.", "Outdoor Gathering City", "New Outdoor Gatheringshire", "UOGA"), "Cloudy with a chance of meatballs")
        };
        
        foreach (Event e in events)
        {
            Console.WriteLine($"Info about a{(e.GetType().ToString() == "OutdoorGathering" ? "n Outdoor Gathering" : $" {e.GetType()}")}:\n");
            Console.WriteLine("Short description:");
            e.DisplayShortDescription();
            Console.WriteLine();

            Console.WriteLine("Standard details:");
            e.DisplayStandardDetails();
            Console.WriteLine();

            Console.WriteLine("Full details:");
            e.DisplayFullDetails();
            Console.WriteLine("\n");
        }
    }
}