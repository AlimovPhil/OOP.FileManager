using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class DeleteFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Удаление файла";

    public DeleteFileCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

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

        _UserInterface.WriteLine($"Вы действительно хотите удалить файл {file.FullName}?\n YES  NO");

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
            _UserInterface.WriteLine($"Операция удаления файла отменена");
            return;
        }

        if (input == "yes" || input == "YES")
        {
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
}
