using System;

public static class Program
{
    public static void Main(string[] args)
    {
        string message = "Welcome to using a .NET Core global tool!";

        if (Console.IsInputRedirected)
        {
            message = Console.In.ReadToEnd();
        }
        else if (args.Length > 0)
        {
            message = string.Join(" ", args);
        }

        Console.WriteLine(message);
    }
}