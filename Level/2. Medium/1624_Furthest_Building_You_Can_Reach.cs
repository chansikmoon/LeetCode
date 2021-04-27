public class Solution
{
    public int FurthestBuilding(int[] a, int bricks, int ladders)
    {
        var pq = new SortedSet<(int delta, int index)>();

        for (int i = 1; i < a.Length; i++)
        {
            int diff = a[i] - a[i - 1];

            if (diff > 0)
                pq.Add((diff, i));

            if (pq.Count > ladders)
            {
                int min = pq.Min.delta;
                bricks -= min;
                pq.Remove(pq.Min);
            }
            if (bricks < 0)
                return i - 1;
        }

        return a.Length - 1;
    }
}