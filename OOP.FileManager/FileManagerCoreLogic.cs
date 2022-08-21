using FileManager.Commands;
using OOP.FileManager.Commands;
using OOP.FileManager.Commands.Base;

namespace OOP.FileManager;

public class FileManagerCoreLogic
{
    private readonly IUserInterface _UserInterface;
    private bool _CanWork = true;
    public DirectoryInfo CurrentDirectory { get; set; } = new("c:\\");

    public IReadOnlyDictionary<string, FileManagerCommand> Commands { get; }
    public FileManagerCoreLogic(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;

        var list_dir_command = new PrintDirectoryFilesCommand(UserInterface, this);
        var help_command = new HelpCommand(UserInterface, this);
        var quit_command = new QuitCommand(this);
        var del_dir_command = new DeleteDirCommand(UserInterface, this);
        var del_file_command = new DeleteFileCommand(UserInterface, this);

        Commands = new Dictionary<string, FileManagerCommand>
        {
            {"drives", new ShowDrivesCommand(UserInterface) },
            {"dir", list_dir_command },
            {"listdir", list_dir_command },
            { "ListDir", list_dir_command },
            { "help", help_command },
            { "?", help_command },
            { "quit", quit_command },
            { "exit", quit_command },
            { "cd", new ChangeDirectoryCommand(UserInterface, this) },
            { "rm", del_dir_command },
            { "rmdir", del_dir_command},
            { "removedir", del_dir_command},
            { "rf", del_file_command },
            { "rfile", del_file_command},
            { "removefile", del_file_command},
        };
    }


    public void Start()
    {
        _UserInterface.WriteLine("Начало работы файлового менеджера.");

        do
        {
            var input = _UserInterface.ReadLine("> ", false);

            var args = input.Split(' ');
            var command_name = args[0];

            if (!Commands.TryGetValue(command_name, out var command))
            {
                _UserInterface.WriteLine($"Неизвестная команда {command_name}.");
                _UserInterface.WriteLine("Для справки введите help, для выхода quit");
                continue;
            }

            try
            {
                command.Execute(args/*[1..]*/);
            }
            catch (Exception error)
            {
                _UserInterface.WriteLine($"При выполнении команды {command_name} произошла ошибка:");
                _UserInterface.WriteLine(error.Message);
            }
        }
        while (_CanWork);


        _UserInterface.WriteLine("Логика файлового менеджера завершена. Всего наилучшего!");
    }

    public void Stop()
    {
        _CanWork = false;
    }
}
