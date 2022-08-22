using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;

public class CreateDirCommand: FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerCoreLogic _FileManager;

    public override string Description => "Создание новой папки в текущей директории";

    public CreateDirCommand(IUserInterface UserInterface, FileManagerCoreLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Для создания папки необходимо ввести ее название");
            return;
        }
        var dir_name = args[1];

        var dir_full_path = $"{_FileManager.CurrentDirectory}\\{dir_name}";

        try
        {
            if (Directory.Exists(dir_full_path))
            {
                Console.WriteLine("Такая папка уже существует");
                return;
            }

            DirectoryInfo dir = Directory.CreateDirectory(dir_full_path);
            
            _UserInterface.WriteLine($"Папка {dir_name} создана");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Создание папки прошло неудачно:{e}");
        }
    }
}
