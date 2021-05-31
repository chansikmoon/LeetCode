public class Solution
{
    // TC: O(nlogn), n is the length of courses
    // SC: O(n)
    public int ScheduleCourse(int[][] courses)
    {
        Array.Sort(courses, (a, b) => a[1] - b[1]);

        var pq = new SortedSet<(int val, int index)>();

        int total = 0;
        int index = 0;
        // If the current course will already fit, we can just add it, 
        // or if the current course is a better fit than our longest course, then we can swap them.
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