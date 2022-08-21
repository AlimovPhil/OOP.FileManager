using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class DeleteDirCommand: FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerCoreLogic _FileManager;

    public override string Description => "Удаление папки";

    public DeleteDirCommand(IUserInterface UserInterface, FileManagerCoreLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }
    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Для удаления папки необходимо указать корректный путь к удаляемому элементу");
            return;
        }
        var dir_path = args[1];

        DirectoryInfo? directory;
        
        directory = new DirectoryInfo(dir_path);

        if (!directory.Exists)
        {
            _UserInterface.WriteLine($"Директория {directory} не существует");
            return;
        }

        try
        {
            Directory.Delete(dir_path, true); // параметр true означает, что подпапки и файлы будут так же удалены рекурсивно
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        
        _UserInterface.WriteLine($"Директория {directory.FullName} удалена");
    }
}
