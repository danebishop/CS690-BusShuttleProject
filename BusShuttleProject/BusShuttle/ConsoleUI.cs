//need this to be in same namespace as program
namespace BusShuttle;

//this needs to be here since we are using these pakages - added auto 
using Spectre.Console;



//create a console UI class 
public class ConsoleUI{
    FileSaver fileSaver;

    List<Loop> loops;
    List<Stop> stops;
    List<Driver> drivers; 

    //move filesaver into here from main 
    public ConsoleUI(){
        fileSaver =  new FileSaver("passenger-data.txt");

        //makign a new list of 'Loops' called loops, this is all posssible loops, assinging each one to the doman of loops
        loops = new List <Loop>();
        loops.Add(new Loop ("Red"));
        loops.Add(new Loop ("Green"));
        loops.Add(new Loop ("Blue"));
        loops.Add(new Loop ("Purple"));

        //making a list of stops and assigning each to the domain / class of stops
        stops = new List<Stop>();
        stops.Add(new Stop("Music"));
        stops.Add(new Stop("Tower"));
        stops.Add(new Stop("Oakwood"));
        stops.Add(new Stop("Anthony"));
        stops.Add(new Stop("Letterman"));

        //now adding various stops to the loops that may contain it, possible for a stop to exist in more than one loop
        //assigning stops to 1st loop, Red loop - first adding 1st stop on list 
        loops[0].Stops.Add(stops[0]);
        loops[0].Stops.Add(stops[1]);
        loops[0].Stops.Add(stops[2]);
        loops[0].Stops.Add(stops[3]);
        //Letterman not on red line so not added 


        drivers = new List<Driver>();
        drivers.Add(new Driver("Big Mike"));
        drivers.Add(new Driver("Fat Jimmy"));

    }

    //this is main area 
    public void Show(){
        //below was first phase 
        //string mode = AskForInput("Please select mode (driver OR manager)?");

        //here is the code we added with spectre console to ask for selection instead of asking user to input choice
        var mode = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Please select mode").AddChoices(new[]{"driver","manager"}));

        if (mode=="driver"){
            //now prompt diver to select who they are 
            var selectedDriver = AnsiConsole.Prompt(new SelectionPrompt<Driver>().Title("Please select Driver").AddChoices(drivers));
            Console.WriteLine("You selected "+selectedDriver.Name+" as driver.");




            // remember Loop is a class so we are telling selection to select/accept loop arguments in <> and then reference list of loops called
            //"loops" we just instantiated above
            Loop selectedLoop = AnsiConsole.Prompt(new SelectionPrompt<Loop>().Title("Please select loop").AddChoices(loops));
            Console.WriteLine("You selected "+selectedLoop.Name+" Loop");
            string command; 

            do{
                //not askign for stop name anymore, since they selected loop at start, so now present them with lsit of possible stops
                //string stopName = AskForInput("Enter stop name:");
                Stop selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>().Title("Please select stop").AddChoices(selectedLoop.Stops));

                //confirm correct stop selected 
                Console.WriteLine("You selected "+selectedStop.Name+ " stop.");



                int boarded = int.Parse(AskForInput("Enter number of people boarded: "));


                //putting all data into passenger data class since it has all the info 
                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);


                //now we should be able to just pass that one class to be added to txt file? 
                //fileSaver.AppendLine(selectedStop+":"+boarded);
                fileSaver.AppendData(data);

                //original - we add spectre selection instead
                //command = AskForInput("Enter command (end OR continue): ");
                command = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("What's Next?").AddChoices(new[]{"continue","end"}));
                

            }while(command !="end");

        }
    }
    
    public static string  AskForInput(string message){
        //this is a funciton to submit a message and get an input back 
        Console.Write(message);
        return Console.ReadLine();
    }
}