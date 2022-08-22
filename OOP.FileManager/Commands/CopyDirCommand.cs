using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;
public class CopyDirCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    public override string Description => "Копирование каталога в новую директорию";

    public CopyDirCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;
    public override void Execute(string[] args)
    {
        if (args.Length != 3 || string.IsNullOrWhiteSpace(args[2]))
        {
            _UserInterface.WriteLine("Для копирования папки необходимо ввести ее название и путь для копирования");
            return;
        }

        var source_dir = new DirectoryInfo(args[1]);
        var dest_dir = args[2];

        // Проверка на существование директории
        if (!source_dir.Exists)
        {
            _UserInterface.WriteLine($"Копируемая директория не существует: {source_dir.FullName}");
            return;
        }
        else
        {
            // Создаем конечную папку (если её не существует)
            Directory.CreateDirectory(dest_dir);

            // Копируем все вложенные файлы в ориджин папке
            foreach (FileInfo file in source_dir.GetFiles())
            {
                string targetFilePath = Path.Combine(dest_dir, file.Name);
                file.CopyTo(targetFilePath);
            }
            _UserInterface.WriteLine($"Папка {source_dir} скопирована в {dest_dir}");
        }
    }
}
