public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var q = new Queue<int>();
        var visit = new HashSet<int>();
        q.Enqueue(0);
        visit.Add(0);

        while (q.Count > 0)
        {
            int curr = q.Dequeue();
            foreach (int next in rooms[curr])
            {
                if (!visit.Contains(next))
                {
                    q.Enqueue(next);
                    visit.Add(next);

                    if (visit.Count == rooms.Count)
                        return true;
                }
            }
        }

        return visit.Count == rooms.Count;
    }

    private bool DFS(IList<IList<int>> rooms)
    {
        var visit = new HashSet<int>();
        visit.Add(0);
        Helper(rooms, visit, 0);

        return rooms.Count == visit.Count;
    }

    private void Helper(IList<IList<int>> rooms, HashSet<int> visit, int curr)
    {
        visit.Add(curr);

        foreach (int next in rooms[curr])
        {
            if (!visit.Contains(next))
                Helper(rooms, visit, next);
        }
    }

    private bool bruteforce(IList<IList<int>> rooms)
    {
        var map = new HashSet<int>[rooms.Count];

        for (int i = 0; i < rooms.Count; i++)
            map[i] = new HashSet<int>();

        for (int i = 0; i < rooms.Count; i++)
        {
            for (int j = 0; j < rooms[i].Count; j++)
                map[i].Add(rooms[i][j]);
        }

        var visit = new bool[rooms.Count];
        var q = new Queue<int>();
        q.Enqueue(0);

        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                int curr = q.Dequeue();

                foreach (int next in map[curr])
                {
                    if (!visit[next])
                        q.Enqueue(next);
                }

                visit[curr] = true;
            }
        }

        return visit.All(x => x);
    }
}