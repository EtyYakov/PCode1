//fib bundle -- output 'd:/folder/bundleFile.txt'

using fib;
using System.CommandLine;
using System.IO;

var bundleOptionOutput= new Option< FileInfo>("--output","file path and name");

var bundleOptionLang = new Option<FileInfo>("--langrages", "langrages");

var bundleOptionNote = new Option<FileInfo>("--note", "to write the file path");

var bundleOptionSort = new Option<FileInfo>("--sort", "to sort the files by names");

var bundleOptionSpace = new Option<FileInfo>("--space", "to remove spaces");

var bundleOptionAuthor = new Option<FileInfo>("--author", "the author");





var bundleCommand = new Command("bundle", "Bundle code files to a single file");

bundleCommand.AddOption(bundleOptionOutput);
bundleCommand.AddOption(bundleOptionLang);
bundleCommand.AddOption(bundleOptionNote);
bundleCommand.AddOption(bundleOptionSort);
bundleCommand.AddOption(bundleOptionSpace);
bundleCommand.AddOption(bundleOptionAuthor);

bundleCommand.SetHandler((output, lang, note,sort,space, author) =>
{
    try {
        fibClass f=new fibClass();
        string result = "";
        string[] langriges = lang.Name.Split(" ");
        string currentPath = Environment.CurrentDirectory;
        string[] dirs = Directory.GetFiles(currentPath);
        string allFiles = "";

        if (sort!=null&&sort.Name=="no")
        {
            dirs = dirs;
        }
        else
        {
            Array.Sort(dirs);
        }
        int lastDotIndex = output.Name.LastIndexOf('.');


        if (lastDotIndex != -1 && lastDotIndex < output.Name.Length - 1)
            result = output.Name.Substring(lastDotIndex + 1);
        string myNote = "";
        string mySpace = "";
        string myAuthor= "";

        if (note!=null)
        {
            myNote = note.Name;
        }
        if (space != null)
        {
            mySpace = space.Name;
        }
        if (author != null)
        {
            myAuthor = author.Name;
        }



        allFiles = f.resturnTowrite(dirs, langriges, myNote, result, mySpace, myAuthor);



        File.WriteAllText(output.FullName, allFiles);
        Console.WriteLine("file was created");
    }
    catch(DirectoryNotFoundException ex)
    {
        Console.WriteLine("Error: The path is invalid");
    }
},bundleOptionOutput, bundleOptionLang, bundleOptionNote, bundleOptionSort,bundleOptionSpace,bundleOptionAuthor);

var create_rsp = new Command("create-rsp", "create rsp file");
create_rsp.SetHandler(() =>
{
    Console.WriteLine("enter output file name");
    string fileName= Console.ReadLine();
    Console.WriteLine("enter the langrages");
    string langrages = Console.ReadLine();
    Console.WriteLine("note?");
    string note = Console.ReadLine();
    Console.WriteLine("sort?");
    string sort = Console.ReadLine();
    Console.WriteLine("remove spaces?");
    string space = Console.ReadLine();
    Console.WriteLine("write the authon name");
    string author = Console.ReadLine();
    //string path=Directory.GetCurrentDirectory();


    string allCommands = "--output\n";
    allCommands += fileName + "\n";
    allCommands += "--langrages\n";
    allCommands += langrages + "\n";
    allCommands += "--note\n";
    allCommands += note + "\n";
    allCommands += "--sort\n";
    allCommands += sort + "\n";
    allCommands += "--space\n";
    allCommands += space + "\n";
    allCommands += "--author\n";
    allCommands += author + "\n";

    string path = "C:\\Users\\אתי\\Documents\\PCode\\files\\response.rsp";
    File.WriteAllText(path, allCommands);
    Console.WriteLine("file was created");

});

var rootCommand = new RootCommand("Root command for file bundle CLI");

rootCommand.AddCommand(bundleCommand);
rootCommand.AddCommand(create_rsp);

rootCommand.InvokeAsync(args);