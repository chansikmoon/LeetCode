public class Solution {
    public int MinJumps(int[] arr) {
        var map = new Dictionary<int, List<int>>();
        int n = arr.Length, targetIndex = arr.Length - 1;
        
        if (n == 1)
            return 0;
        
        for (int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(arr[i]))
                map.Add(arr[i], new List<int>());
                
            map[arr[i]].Add(i);
        }
        
        var q = new Queue<int>();
        var visited = new bool[n];
        int ret = 0;
        q.Enqueue(0);
        visited[0] = true;
        
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                int currIndex = q.Dequeue();
                
                if (currIndex == targetIndex)
                    return ret;
                
                var next = map[arr[currIndex]];
                next.Add(currIndex-1);
                next.Add(currIndex+1);
                
                foreach (int nextIndex in next)
                {
                    if (nextIndex >= 0 && nextIndex < n && !visited[nextIndex])
                    {
                        visited[nextIndex] = true;
                        q.Enqueue(nextIndex);
                    }
                }
                
                /*
                This is essential. 
                In the case where each index has the same value, 
                I only go to the neighbor (the same value) once then I break all the edge by using: next.clear()
                */
                next.Clear();   
            }
            
            ret++;
        }
        
        return ret;
    }
}