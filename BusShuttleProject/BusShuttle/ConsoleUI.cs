namespace BusShuttle;

using Spectre.Console;


public class ConsoleUI{
    DataManager dataManager;
 
    public ConsoleUI(){
        dataManager  = new DataManager();

    }

    public void Show(){

        var mode = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Please select mode").AddChoices(new[]{"driver","manager"}));

        if (mode=="driver"){
            var selectedDriver = AnsiConsole.Prompt(new SelectionPrompt<Driver>().Title("Please select Driver").AddChoices(dataManager.Drivers));
            Console.WriteLine("You selected "+selectedDriver.Name+" as driver.");




            Loop selectedLoop = AnsiConsole.Prompt(new SelectionPrompt<Loop>().Title("Please select loop").AddChoices(dataManager.Loops));
            Console.WriteLine("You selected "+selectedLoop.Name+" Loop");
            string command; 

            do{
                Stop selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>().Title("Please select stop").AddChoices(selectedLoop.Stops));

                Console.WriteLine("You selected "+selectedStop.Name+ " stop.");

                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of people boarded: "));

                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);

                dataManager.AddNewPassengerData(data);

                command = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("What's Next?").AddChoices(new[]{"continue","end"}));
            

            }while(command !="end");

        }
    }
    
    public static string  AskForInput(string message){
        Console.Write(message);
        return Console.ReadLine();
    }
}