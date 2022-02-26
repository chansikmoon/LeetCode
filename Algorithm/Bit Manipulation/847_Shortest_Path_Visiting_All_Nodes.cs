public class Solution {
    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length;
        
        var q = new Queue<Context>();
        var _set = new HashSet<Context>();
        
        for (int i = 0; i < n; i++) {
            int tmp = (1 << i);
            _set.Add(new Context(tmp, i, 0));
            q.Enqueue(new Context(tmp, i, 1));
        }
        
        while (q.Count > 0) {
            var curr = q.Dequeue();
            
            if (curr.BitMask == (1 << n) - 1) {
                return curr.Cost - 1;
            }
            else {
                var neighbors = graph[curr.Current];
                
                foreach (int neighbor in neighbors) {
                    int bitMask = curr.BitMask;
                    bitMask |= (1 << neighbor);
                    
                    var cost = new Context(bitMask, neighbor, 0);
                    if (_set.Add(cost)) {
                        q.Enqueue(new Context(bitMask, neighbor, curr.Cost + 1));
                    }
                }
            }
        }
        
        return -1;
    }
}

public class Context {
    public int BitMask { get; set; }
    public int Current { get; set; }
    public int Cost { get; set; }
    
    public Context(int bitMask, int current, int cost) {
        BitMask = bitMask;
        Current = current;
        Cost = cost;
    }

    public override bool Equals(object obj) {
        return Equals(obj as Context);
    }
    
    public bool Equals(Context other) {
        return other != null && 
            BitMask == other.BitMask &&
            Current == other.Current &&
            Cost == other.Cost;
    }
        
    
    public override int GetHashCode() {
        return 1331 * BitMask + 7193 * Current + 727 * Cost;
    }
    
}