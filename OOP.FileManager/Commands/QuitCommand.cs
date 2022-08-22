using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.FileManager;
using OOP.FileManager.Commands.Base;

namespace FileManager.Commands;

public class QuitCommand : FileManagerCommand
{
    private readonly FileManagerCoreLogic _FileManager;

    public override string Description => "Выход";

    public QuitCommand(FileManagerCoreLogic FileManager) => _FileManager = FileManager;

    public override void Execute(string[] args)
    {
        _FileManager.Stop();
    }
}
