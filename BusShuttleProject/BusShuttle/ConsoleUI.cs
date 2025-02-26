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

        }else if (mode == "manager"){
            string command; 

            do{
                command = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("What do you want to do?").AddChoices(new[]{"add stop","delete stop","list stops","end"}));

                if (command == "add stop"){
                    var newStopName = AnsiConsole.Prompt(new TextPrompt<string>("Enter new stop name:"));
                    dataManager.AddStop(new Stop(newStopName));

                }else if (command =="delete stop"){
                    Stop selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>().Title("Please select stop").AddChoices(dataManager.Stops));
                    dataManager.RemoveStop(selectedStop);
                    
                }else if (command =="list stops"){
                    var stopTable = new Table();
                    
                    stopTable.AddColumn("Stops");
                    
                    foreach ( var stop in dataManager.Stops){
                        stopTable.AddRow(stop.Name);
                    }
                    
                    AnsiConsole.Write(stopTable);
                
                }

            

            }while(command !="end");

        }
    }
    
    public static string  AskForInput(string message){
        Console.Write(message);
        return Console.ReadLine();
    }
}