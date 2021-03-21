public class Passenger
{
    private int id { get; set; }
    private string startStation { get; set; }
    private string endStation { get; set; }
    private int time { get; set; }

    public Passenger(int id)
    {
        this.id = id;
    }

    public void AddStartInfo(string startStation, int time)
    {
        this.startStation = startStation;
        this.time = -time;
    }

    public void AddEndInfo(string endStation, int time)
    {
        this.endStation = endStation;
        this.time += time;
    }

    public string GetStartStationName()
    {
        return this.startStation;
    }

    public string GetEndStationName()
    {
        return this.endStation;
    }

    public int GetTime()
    {
        return this.time;
    }
}

public class Route
{
    private Dictionary<string, List<int>> endStations { get; set; }

    public Route()
    {
        this.endStations = new Dictionary<string, List<int>>();
    }

    public void AddRoute(Passenger p)
    {
        var endStation = p.GetEndStationName();
        int time = p.GetTime();
        if (!this.endStations.ContainsKey(endStation))
            this.endStations.Add(endStation, new List<int>());

        this.endStations[endStation].Add(time);
    }

    public double GetAverageTime(string station)
    {
        double count = this.endStations[station].Count;
        if (count == 0)
            return 0.0;

        int sum = this.endStations[station].Sum();
        return sum / count;
    }
}

public class UndergroundSystem
{
    private Dictionary<int, Passenger> passengersMap;
    private Dictionary<string, Route> stationsMap;

    public UndergroundSystem()
    {
        this.passengersMap = new Dictionary<int, Passenger>();
        this.stationsMap = new Dictionary<string, Route>();
    }

    public void CheckIn(int id, string stationName, int t)
    {
        this.passengersMap.Add(id, new Passenger(id));
        this.passengersMap[id].AddStartInfo(stationName, t);
    }

    public void CheckOut(int id, string stationName, int t)
    {
        var passenger = this.passengersMap[id];
        var startStation = passenger.GetStartStationName();
        passenger.AddEndInfo(stationName, t);

        if (!this.stationsMap.ContainsKey(startStation))
            this.stationsMap.Add(startStation, new Route());

        this.stationsMap[startStation].AddRoute(passenger);

        this.passengersMap.Remove(id);
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        return this.stationsMap[startStation].GetAverageTime(endStation);
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */