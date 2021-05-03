public class Solution
{
    public int ScheduleCourse(int[][] courses)
    {
        Array.Sort(courses, (a, b) => a[1] - b[1]);

        var pq = new SortedSet<(int val, int index)>();

        int total = 0;
        int index = 0;
        foreach (var c in courses)
        {
            int dur = c[0], end = c[1];

            if (total + dur <= end)
            {
                total += dur;
                pq.Add((dur, index));
            }
            else if (pq.Count > 0 && pq.Max.val > dur)
            {
                total += dur - pq.Max.val;
                pq.Remove(pq.Max);
                pq.Add((dur, index));
            }
            index++;
        }

        return pq.Count;
    }
}