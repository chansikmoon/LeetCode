public class MovingAverage {
    public Queue<int> q = new Queue<int>();
    public int size = 0;
    /** Initialize your data structure here. */
    public MovingAverage(int size) {
        this.size = size;
    }
    
    public double Next(int val) {
        if (q.Count >= this.size)
            q.Dequeue();
        q.Enqueue(val);
        return (double) q.Sum() / (double) q.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */