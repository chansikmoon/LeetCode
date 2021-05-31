public class MyCircularQueue
{
    private List<int> q;
    private int max;
    public MyCircularQueue(int k)
    {
        q = new List<int>();
        max = k;
    }

    public bool EnQueue(int value)
    {
        if (q.Count < max)
        {
            q.Add(value);
            return true;
        }

        return false;
    }

    public bool DeQueue()
    {
        if (q.Count == 0)
            return false;
        q.RemoveAt(0);
        return true;
    }

    public int Front()
    {
        return q.Count > 0 ? q[0] : -1;
    }

    public int Rear()
    {
        return q.Count > 0 ? q[q.Count - 1] : -1;
    }

    public bool IsEmpty()
    {
        return q.Count == 0;
    }

    public bool IsFull()
    {
        return q.Count == max;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */