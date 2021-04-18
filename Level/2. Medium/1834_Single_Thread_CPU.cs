public class Solution
{
    public int[] GetOrder(int[][] tasks)
    {
        int n = tasks.Length;
        var arr = new Task[n];

        for (int i = 0; i < n; i++)
            arr[i] = new Task(tasks[i], i);

        Array.Sort(arr, (a, b) => a.Enqueue.CompareTo(b.Enqueue));

        foreach (var t in arr)
            Console.WriteLine(t.Print());
        // https://stackoverflow.com/questions/42355955/c-comparing-two-objects-by-multiple-properties-in-sortedset
        var pq = new SortedSet<Process>(
            Comparer<Process>.Create((a, b) =>
            {
                var res = a.Time.CompareTo(b.Time);
                return res != 0 ? res : a.Index.CompareTo(b.Index);
            }));

        long currTime = 0;
        var ret = new List<int>();

        for (int i = 0; i < n; i++)
        {
            // Only add any enqueue time tasks that are prior to the current time
            // If currTime is less than the next task enqueue time, then get the next task from the pq and process it.
            while (currTime < arr[i].Enqueue && pq.Count > 0)
            {
                var pro = pq.Min;
                ret.Add(pro.Index);
                currTime += pro.Time;
                pq.Remove(pro);
            }

            pq.Add(new Process(arr[i].Process, arr[i].Index));
            currTime = Math.Max(currTime, (long)arr[i].Enqueue);
        }

        while (pq.Count > 0)
        {
            var pro = pq.Min;
            ret.Add(pro.Index);
            currTime += pro.Time;
            pq.Remove(pro);
        }

        return ret.ToArray();
    }
}

public class Process
{
    public int Time { get; set; }
    public int Index { get; set; }

    public Process(int p, int i)
    {
        Time = p;
        Index = i;
    }
}

public class Task
{
    public int Enqueue { get; set; }
    public int Process { get; set; }
    public int Index { get; set; }

    public Task(int[] task, int index)
    {
        Enqueue = task[0];
        Process = task[1];
        Index = index;
    }

    public string Print()
    {
        return string.Format("Enqueue: {0}, Process: {1}, Index: {2}", Enqueue, Process, Index);
    }
}