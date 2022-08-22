using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;


public class ShowFileInfoCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Вывод информации о файле";
    public ShowFileInfoCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Введите название файла для получения информации");
            return;
        }

        var file = args[1];

        if (File.Exists(file))
        {
            try
            {
                var fileInfo = new FileInfo(file);
                string[] info = { $"Название файла: {fileInfo.Name}",
                            $"Расположение файла: {fileInfo.DirectoryName}",
                            $"Расширение: {fileInfo.Extension}",
                            $"Размер: {fileInfo.Length} байт",
                            $"Создан: {fileInfo.CreationTime}",
                            $"Изменен: { fileInfo.LastWriteTime }",
                            };
                for (int i = 0; i < info.Length; i++)
                {
                    _UserInterface.WriteLine(info[i]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        else
        {
            _UserInterface.WriteLine($"Файл {file} не существует");
            return;
        }
    }
}