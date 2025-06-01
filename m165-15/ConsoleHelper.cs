public class ConsoleHelper
{

    public static void PrintExercise(String exerciseName, String text)
    {
        Console.WriteLine($"Aufgabe {exerciseName}: ".PadRight(20, '-'));
        Console.WriteLine(text);
        Console.WriteLine();
    }

    public static void PrintExercise(String exerciseName, String title, List<string> listItems)
    {
        Console.WriteLine($"Aufgabe {exerciseName}: ".PadRight(20, '-'));
        Console.WriteLine($"{title}:");
        listItems.ForEach(item => Console.WriteLine($"- {item}"));
        Console.WriteLine();
    }

}