namespace BusShuttle;

using System.IO;//Need to include this since we are using a file 

//create a new class to save the file 
public class FileSaver{
    string fileName;

    public FileSaver(string fileName){
        this.fileName = fileName;
        if (!File.Exists(this.fileName)){
            File.Create(this.fileName).Close();
        }
    }

    //making a new funciton to just append a line to the file 
    public void AppendLine(string line){
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }

    public void AppendData(PassengerData data){
        File.AppendAllText(this.fileName, data.Driver + ":" + data.Loop + ":" + data.Stop + ":" + data.Boarded + Environment.NewLine);
    }

}