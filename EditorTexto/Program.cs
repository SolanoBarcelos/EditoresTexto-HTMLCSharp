using System.IO;

Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que você deseja?");
    Console.WriteLine("1 - Abrir um arquivo");
    Console.WriteLine("2 - Criar um novo arquivo");
    Console.WriteLine("0 - Sair");

    int opcao = Convert.ToInt32(Console.ReadLine());

    switch(opcao)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
    }
}

static void Abrir()
{
    
    Console.Clear();
    Console.WriteLine("Digite o caminho do arquivo abaixo:");
    string path = Console.ReadLine();

    using(var File = new StreamReader(path))
    {
        string text = File.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();

}

static void Editar()
{

    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo:");
    Console.WriteLine("Pressione ESC pra sair");
    Console.WriteLine("------------");

    string text = "";

    do 
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while(Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
    
}

static void Salvar( string text)
{
    Console.Clear();
    Console.WriteLine("Qual o caminho deseja salvar?");
    var path = Console.ReadLine();

    using(var file = new StreamWriter(path))
    {
        file.Write(text);
    }  

    Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    Console.ReadLine();
    Menu();  

}