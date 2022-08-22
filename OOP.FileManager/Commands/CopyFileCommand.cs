using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;

public class CopyFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Копирование файла в другой каталог";
    public CopyFileCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

    public override void Execute(string[] args)
    {
        if (args.Length != 3 || string.IsNullOrWhiteSpace(args[2]))
        {
            _UserInterface.WriteLine("Для копирования файла необходимо ввести ее название и путь для копирования");
            return;
        }

        var source_file = args[1];
        var target_file_path = args[2];

        if (File.Exists(source_file))
        {
            try
            {
                File.Copy(source_file, target_file_path, true); // параметр true разрешает перезапись файла, если он уже существует
                _UserInterface.WriteLine($"Файл {source_file} скопирован");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        else
        {
            _UserInterface.WriteLine($"Файл {source_file} не существует");
            return;
        }
    }
}
