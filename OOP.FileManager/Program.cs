using OOP.FileManager;


Console.Title = "File Manager v2.0"; // Название окна
Console.BackgroundColor = ConsoleColor.Black; // Цвет окна
Console.ForegroundColor = ConsoleColor.DarkGreen; // Цвет шрифта

ConsoleUI console_ui = new();

FileManagerCoreLogic manager = new(console_ui); 

manager.Start();






Console.WriteLine("Программа завершена.");
Console.ReadLine();