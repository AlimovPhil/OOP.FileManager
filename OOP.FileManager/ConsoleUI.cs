namespace OOP.FileManager;

public class ConsoleUI : IUserInterface
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    public void Write(string message)
    {
        Console.Write(message);
    }
    private void WritePrompt(string? Prompt, bool PromptNewLine)
    {
        //if(Prompt != null && Prompt.Length > 0)
        if (Prompt is { Length: > 0 })
            if (PromptNewLine)
                WriteLine(Prompt);
            else
                Write(Prompt);
    }

    public string ReadLine(string? Prompt, bool PromptNewLine = true)
    {
        WritePrompt(Prompt, PromptNewLine);

        return Console.ReadLine()!;
    }

    public int ReadInt(string? Prompt, bool PromptNewLine = true)
    {
        bool success;
        int value;
        do
        {
            WritePrompt(Prompt, PromptNewLine);

            var input = Console.ReadLine();
            success = int.TryParse(input, out value);
            if (!success)
                WriteLine("Строка имела неверный формат");
        }
        while (!success);

        return value;
    }

    public double ReadDouble(string? Prompt, bool PromptNewLine = true)
    {
        bool success;
        double value;
        do
        {
            WritePrompt(Prompt, PromptNewLine);

            var input = Console.ReadLine();
            success = double.TryParse(input, out value);
            if (!success)
                WriteLine("Строка имела неверный формат");
        }
        while (!success);

        return value;
    }
}
