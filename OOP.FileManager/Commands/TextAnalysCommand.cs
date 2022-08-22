using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class TextAnalysCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerCoreLogic _FileManager;

    public override string Description => "Вывод статистики по выбранному текстовому файлу";

    public TextAnalysCommand(IUserInterface UserInterface, FileManagerCoreLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Введите название текстового файла для анализа");
            return;
        }

        var file = args[1];
        var file_full_path = $"{_FileManager.CurrentDirectory}\\{args[1]}";

        if (File.Exists(file_full_path))
        {
            var text = File.ReadAllText(file_full_path);

            string[] split_text;

            split_text = text.Split(' ');

            _UserInterface.WriteLine($"Текстовый файл {file} содержит {split_text.Length} слов");
        }
        else
        {
            _UserInterface.WriteLine($"Файл {file} не существует");
            return;
        }

    }
}
