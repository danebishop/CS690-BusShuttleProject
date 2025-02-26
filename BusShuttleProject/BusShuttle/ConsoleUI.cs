//need this to be in same namespace as program

namespace BusShuttle;

//this needs to be here since we are using these pakages - added auto 

using Spectre.Console;



//create a console UI class 
public class ConsoleUI{
    FileSaver fileSaver;

    //move filesaver into here from main 
    public ConsoleUI(){
        fileSaver =  new FileSaver("passenger-data.txt");
    }

    //this is main area 
    public void Show(){
        //below was first phase 
        //string mode = AskForInput("Please select mode (driver OR manager)?");

        //here is the code we added with spectre console to ask for selection instead of asking user to input choice
        var mode = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Please select mode").AddChoices(new[]{"driver","manager"}));

        if (mode=="driver"){

            string command; 

            do{
                string stopName = AskForInput("Enter stop name:");

                int boarded = int.Parse(AskForInput("Enter number of people boarded: "));

                fileSaver.AppendLine(stopName+":"+boarded);

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