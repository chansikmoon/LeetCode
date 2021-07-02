public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var adjList = new Dictionary<string, SortedSet<(string, int)>>();
        int index = 0;
        foreach (var ticket in tickets)
        {
            var u = ticket[0];
            var v = ticket[1];
            
            if (!adjList.ContainsKey(u))
                adjList.Add(u, new SortedSet<(string str, int idx)>(
                    Comparer<(string str, int idx)>
                    .Create((a,b) =>
                            {
                                var res = a.str.CompareTo(b.str);
                                return res != 0 ? res : a.idx.CompareTo(b.idx);
                            })));
        
            adjList[u].Add((v, index++));
        }
        
        var ll = new LinkedList<string>();
        EulerianCircuit(adjList, "JFK", ll);
        
        var ret = new List<string>();
        foreach (var location in ll)
            ret.Add(location);
        
        return ret;
    }
    
    private void EulerianCircuit(
        Dictionary<string, SortedSet<(string str, int)>> adjList, 
        string departure, 
        LinkedList<string> ll)
    {
        while (adjList.ContainsKey(departure) && adjList[departure].Count > 0)
        {
            var min = adjList[departure].Min;
            var dest = min.str;
            adjList[departure].Remove(min);
            EulerianCircuit(adjList, dest, ll);
        }
        
        ll.AddFirst(departure);
    }
}