namespace BusShuttle;

public class Reporter{
    public static Stop FindBusiestStop(List<PassengerData> data){
        //build a dictionary 
        Dictionary<string, int> passengerCountPerStop = new Dictionary<string, int>();

        foreach (var piece in data){
            if (!passengerCountPerStop.ContainsKey(piece.Stop.Name)){
                passengerCountPerStop.Add(piece.Stop.Name,0);
            }
            passengerCountPerStop[piece.Stop.Name] += piece.Boarded;
        }

        //find highest

        String highestStop = "";
        int highest = 0;

        foreach (var stopCountPair in passengerCountPerStop){
            if (stopCountPair.Value > highest){
                highest = stopCountPair.Value;
                highestStop=stopCountPair.Key;
            }
        }

        return new Stop(highestStop);
    
    }
}