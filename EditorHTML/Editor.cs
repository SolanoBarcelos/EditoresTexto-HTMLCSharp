using System;
using System.Text;

public static class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO EDITOR");
        Console.WriteLine("-----------");
        
        start();        
    }

    public static void start()
    {
        var file = new StringBuilder();

        do 
        {
            file.Append(Console.ReadLine());
            file.Append(Environment.NewLine);
        }
        while(Console.ReadKey().Key != ConsoleKey.Escape);

        Console.WriteLine("-----------");
        Console.WriteLine("  Deseja salvar o arquivo?");
        Viewer.Show(file.ToString());
    }
}