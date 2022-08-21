using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class DeleteFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerCoreLogic _FileManager;

    public override string Description => "Удаление файла";

    public DeleteFileCommand(IUserInterface UserInterface, FileManagerCoreLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }
    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Для удаления файла необходимо указать корректный путь к удаляемому элементу");
            return;
        }

        var file_path = args[1];

        FileInfo? file;

        file = new FileInfo(file_path);

        if (!file.Exists)
        {
            _UserInterface.WriteLine($"Файла {file} не существует");
            return;
        }

        try
        {
            File.Delete(file_path);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        _UserInterface.WriteLine($"Файл {file.FullName} удален");
    }
}
