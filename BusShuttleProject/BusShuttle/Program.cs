namespace BusShuttle;

using System.IO;//Need to include this since we are using a file 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select mode (driver OR manager)?");
        string mode = Console.ReadLine();

        if (mode=="driver"){

            string command; 

            do{
                    
                Console.Write("Enter stop name:");
                string stopName = Console.ReadLine();

                Console.Write("Enter number of people boarded: ");
                int boarded = int.Parse(Console.ReadLine());

                File.AppendAllText("passenger-data.txt", stopName+":"+boarded+Environment.NewLine);

                Console.Write("Enter command (end OR continue): ");
                command = Console.ReadLine();

            }while(command !="end");
        }

    }
}
