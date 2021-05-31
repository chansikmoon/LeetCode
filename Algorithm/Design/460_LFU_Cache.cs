public class BruteForceLFUCache
{
    private Dictionary<int, (int f, int t)> freq;
    private Dictionary<int, int> map;
    private int CAP = 0;
    private int time = 0;

    public BruteForceLFUCache(int capacity)
    {
        freq = new Dictionary<int, (int f, int t)>();
        map = new Dictionary<int, int>();
        CAP = capacity;
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key))
            return -1;

        int f = freq[key].f + 1;
        freq[key] = (f, time++);

        return map[key];
    }

    public void Put(int key, int value)
    {
        if (!map.ContainsKey(key) && map.Count >= CAP)
        {
            var removeKey = GetLeastFreq();
            freq.Remove(removeKey);
            map.Remove(removeKey);

            if (map.Count == CAP)
                return;
        }

        if (!map.ContainsKey(key))
            map.Add(key, 0);

        map[key] = value;

        if (!freq.ContainsKey(key))
            freq.Add(key, (1, time++));
        else
        {
            int f = freq[key].f + 1;
            freq[key] = (f, time++);
        }
    }

    private int GetLeastFreq()
    {
        int min = Int32.MaxValue, minTime = Int32.MaxValue, ret = 0;

        foreach (var kvp in freq)
        {
            if (min > kvp.Value.f ||
                (min == kvp.Value.f && minTime > kvp.Value.t))
            {
                ret = kvp.Key;
                min = kvp.Value.f;
                minTime = kvp.Value.t;
            }
        }

        return ret;
    }
}

public class LFUCache
{
    private Dictionary<int, int> val;       // key, val
    private Dictionary<int, int> counts;    // key, freq
    private Dictionary<int, List<int>> LRU; // freq, List<int> key
    private int capacity;
    private int minCount;

    public LFUCache(int capacity)
    {
        val = new Dictionary<int, int>();
        counts = new Dictionary<int, int>();
        LRU = new Dictionary<int, List<int>>();
        LRU.Add(1, new List<int>());
        this.capacity = capacity;
        minCount = -1;
    }

    public int Get(int key)
    {
        if (!val.ContainsKey(key))
            return -1;

        int prevCount = counts[key];
        counts[key]++;

        LRU[prevCount].Remove(key);

        if (minCount == prevCount && LRU[prevCount].Count == 0)
            minCount++;

        if (!LRU.ContainsKey(prevCount + 1))
            LRU.Add(prevCount + 1, new List<int>());

        LRU[prevCount + 1].Add(key);

        return val[key];
    }

    public void Put(int key, int value)
    {
        if (capacity <= 0)
            return;

        if (val.ContainsKey(key))
        {
            val[key] = value;
            Get(key);
            return;
        }

        if (val.Count >= capacity)
        {
            val.Remove(LRU[minCount][0]);
            LRU[minCount].RemoveAt(0);
        }

        val.Add(key, value);
        minCount = 1;
        counts.Add(key, minCount);
        LRU[1].Add(key);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */