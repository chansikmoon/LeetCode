public class Solution
{
    public int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
    {
        int n = warehouse.Length;
        var heights = new int[n];
        heights[0] = warehouse[0];

        for (int i = 1; i < n; i++)
            heights[i] = Math.Min(heights[i - 1], warehouse[i]);

        var pq = new SortedSet<(int h, int index)>();
        for (int i = 0; i < boxes.Length; i++)
            pq.Add((boxes[i], i));

        int count = pq.Count;
        for (int i = n - 1; i >= 0; i--)
        {
            if (heights[i] >= pq.Min.h)
                pq.Remove(pq.Min);
        }

        return count - pq.Count;
    }
}