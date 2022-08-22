using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class DeleteDirCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Удаление папки";

    public DeleteDirCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

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

        _UserInterface.WriteLine($"Вы действительно хотите удалить директорию {directory.FullName}?\n YES  NO");
        
        var input = _UserInterface.ReadLine("> ", false);
        
        if (input.Length > 3)
        {
            _UserInterface.WriteLine("Подтверждение не получено, удаление отменено");
            return;
        }

        if (input == "")
        {
            _UserInterface.WriteLine("Подтверждение не получено, удаление отменено");
            return;
        }  
        
        if (input == "no" || input == "NO")
        {
            _UserInterface.WriteLine($"Операция удаления директории отменена");
            return;
        }

        if (input == "yes" || input == "YES")
        {
            try
            {
                Directory.Delete(dir_path, true); // параметр true означает, что подпапки и файлы будут так же удалены рекурсивно
                _UserInterface.WriteLine($"Директория {directory.FullName} удалена");
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
