using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";
string choice;
do{
    Console.WriteLine("Media Library");
    Console.WriteLine("Please choose from the options below or any other key to exit");

    Console.WriteLine("1. Add Movie");
    Console.WriteLine("2. View Movie List");
    choice = Console.ReadLine();

    if (choice == "1") 
    {
        Movie movie = new Movie();
        Console.WriteLine("Enter movie title: ");
        movie.title = Console.ReadLine();
        
        Console.WriteLine("Enter a genre (or done to quit)");
        List<string> genres = Console.ReadLine();
        
        
        Console.WriteLine("Enter movie director: ");
        movie.director = Console.ReadLine();

        Console.WriteLine("Enter running time (h:m:s)");
        movie.runningTime = TimeSpan.Parse(Console.ReadLine()); 
        
    }
    if (choice == "2") 
    {
        
    }
} while (choice == "1" || choice == "2");

//if 

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);
MovieFile movieFile = new MovieFile(scrubbedFile);

logger.Info("Program ended");
