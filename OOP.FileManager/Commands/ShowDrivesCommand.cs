using OOP.FileManager.Commands.Base;

namespace OOP.FileManager.Commands;

public class ShowDrivesCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Вывод списка подключенных дисков";

    public ShowDrivesCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

    public override void Execute(string[] args)
    {
        var drives = DriveInfo.GetDrives();

        _UserInterface.WriteLine($"В файловой системе существует дисков: {drives.Length}");

        foreach (var drive in drives)
            _UserInterface.WriteLine($"    {drive.Name}");
    }
}
