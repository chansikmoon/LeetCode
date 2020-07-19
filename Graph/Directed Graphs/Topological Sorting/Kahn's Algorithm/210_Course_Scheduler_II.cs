public class Solution {
    public int[] FindOrder(int n, int[][] prs) {
        List<int>[] graph = new List<int>[n];
        List<int> retval = new List<int>();
        int[] indegree = new int[n];
        Queue<int> q = new Queue<int>();
        
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();
        
        foreach (var pr in prs)
        {
            graph[pr[1]].Add(pr[0]);
            indegree[pr[0]]++;
        }

        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
                q.Enqueue(i);
        }

        while (q.Count > 0)
        {
            int pre = q.Dequeue();
            retval.Add(pre);

            for (int i = 0; i < graph[pre].Count; i++)
            {
                if (--indegree[graph[pre][i]] == 0)
                    q.Enqueue(graph[pre][i]);
            }
        }

        return retval.Count == n ? retval.ToArray() : new int[0];
    }
}