using System;
using System.Text.RegularExpressions;

public class Viewer
{
    public static void Show(string text)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO VISUALIZAÇÃO");
        Console.WriteLine("-----------");

        Replace(text);

        // Console.BackgroundColor = ConsoleColor.White;
        // Console.ForegroundColor = ConsoleColor.Black;
        // Console.WriteLine("-----------");
        // Console.WriteLine("Precione qualquer tecla para voltar ao menu");
        // Console.ReadKey();
        
        Menu.Show();
    }

    public static void Replace(string text)
    {
        var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
        
        var words = text.Split(' ');

        for(var i = 0; i < words.Length; i++)
        {
            if(strong.IsMatch(words[i]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(
                    words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                    )
                );

                Console.Write(" ");
            }
            else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
        }

       
    }

    public static void Abrir()
    {
    
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Digite o caminho do arquivo abaixo:");
        string path = Console.ReadLine();

        using(var File = new StreamReader(path))
        {
            string text = File.ReadToEnd();
            Console.WriteLine(text);
        }

        Console.WriteLine("");
        Console.WriteLine("-----------");
        Console.WriteLine("Precione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.ReadLine();
        Menu.Show();
    }
}