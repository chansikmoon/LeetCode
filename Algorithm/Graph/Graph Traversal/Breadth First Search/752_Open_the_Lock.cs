public class Solution {
    public int OpenLock(string[] deadends, string target) {
        HashSet<string> ddset = new HashSet<string>(deadends);
        HashSet<string> visited = new HashSet<string>();
        Queue<string> q = new Queue<string>();
        
        string init = "0000";
        if (ddset.Contains(init))
            return -1;
        
        q.Enqueue(init);
        visited.Add(init);
        int count = 0;
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            for (int i = 0; i < size; i++)
            {
                string cur = q.Dequeue();
                // Console.WriteLine(cur);
                List<string> neighbors = GetNeighbors(cur);
                foreach (string neighbor in neighbors)
                {
                    if (neighbor == target)
                        return ++count;
                    if (visited.Contains(neighbor))
                        continue;
                    if (!ddset.Contains(neighbor))
                    {
                        q.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
            count++;
        }
        
        return -1;
    }
    
    private List<string> GetNeighbors(string cur)
    {
        List<string> retval = new List<string>();
        
        for (int i = 0; i < 4; i++)
        {
            StringBuilder sb = new StringBuilder(cur);
            
            int digit = cur[i] - '0';
            // Console.WriteLine(digit);
            
            sb[i] = Convert.ToChar((cur[i] - '0' + 1) % 10 + '0');
            // Console.WriteLine(digit + " plus: " + sb[i]);
            retval.Add(sb.ToString());
            // Console.WriteLine(sb.ToString());
            
            sb[i] = Convert.ToChar((cur[i] - '0' - 1 + 10) % 10 + '0');
            // Console.WriteLine(digit + " neg: " + sb[i]);
            retval.Add(sb.ToString());
            // Console.WriteLine(sb.ToString());
        }
        
        return retval;
    }
}