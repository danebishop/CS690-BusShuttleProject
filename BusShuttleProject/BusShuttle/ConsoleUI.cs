//need this to be in same namespace as program
namespace BusShuttle;


//create a console UI class 
public class ConsoleUI{
    FileSaver fileSaver;

    //move filesaver into here from main 
    public ConsoleUI(){
        fileSaver =  new FileSaver("passenger-data.txt");
    }

    //this is main area 
    public void Show(){
        string mode = AskForInput("Please select mode (driver OR manager)?");

        if (mode=="driver"){

            string command; 

            do{
                string stopName = AskForInput("Enter stop name:");

                int boarded = int.Parse(AskForInput("Enter number of people boarded: "));

                fileSaver.AppendLine(stopName+":"+boarded);

                command = AskForInput("Enter command (end OR continue): ");

            }while(command !="end");

        }
    }
    
    public static string  AskForInput(string message){
        //this is a funciton to submit a message and get an input back 
        Console.Write(message);
        return Console.ReadLine();
    }
}