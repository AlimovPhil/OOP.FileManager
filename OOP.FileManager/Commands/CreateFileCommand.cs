using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class CreateFileCommand: FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerCoreLogic _FileManager;

    public override string Description => "Создание нового файла в текущей директории";

    public CreateFileCommand(IUserInterface UserInterface, FileManagerCoreLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Для создания файла необходимо ввести его название");
            return;
        }
        var file_name = args[1];
        
        var file_full_path = $"{_FileManager.CurrentDirectory}\\{file_name}";

        var new_file = File.Create(file_full_path);
        
        new_file.Close();


        _UserInterface.WriteLine($"Файл {file_name} создан");
    }

}
