public class Solution {
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill) {
        var map = new Dictionary<int, HashSet<int>>();
        
        for (int i = 0; i < pid.Count; i++)
        {
            if (!map.ContainsKey(ppid[i]))
                map.Add(ppid[i], new HashSet<int>());
            
            map[ppid[i]].Add(pid[i]);    
        }
        
        var q = new Queue<int>();
        q.Enqueue(kill);
        var ret = new HashSet<int>();
        
        while (q.Count > 0)
        {
            int id = q.Dequeue();
            ret.Add(id);
            
            if (map.ContainsKey(id))
            {
                foreach (var child in map[id])
                {
                    if (!ret.Contains(child))
                        q.Enqueue(child);
                }
            }
        }
        
        return ret.ToList();
    }
}