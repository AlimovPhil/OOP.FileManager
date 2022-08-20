namespace OOP.FileManager;


public interface IUserInterface
{
    void WriteLine(string message);
    void Write(string message);
    string ReadLine(string? Prompt, bool PromptNewLine = true);

    int ReadInt(string? Prompt, bool PromptNewLine = true);

    double ReadDouble(string? Prompt, bool PromptNewLine = true);
}