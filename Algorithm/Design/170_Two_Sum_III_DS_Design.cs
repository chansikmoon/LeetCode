public class TwoSum {
    private Dictionary<int, int> map;
    /** Initialize your data structure here. */
    public TwoSum() {
        map = new Dictionary<int, int>();
    }
    
    /** Add the number to an internal data structure.. */
    public void Add(int number) {
        if (!map.ContainsKey(number))
            map.Add(number, 0);
        map[number]++;
    }
    
    /** Find if there exists any pair of numbers which sum is equal to the value. */
    public bool Find(int value) {
        foreach (var kvp in map)
        {
            int target = value - kvp.Key;
            if (target != kvp.Key)
            {
                if (map.ContainsKey(target)) return true;
            }
            else
            {
                if (kvp.Value > 1)
                    return true;
            }
        }
                
        return false;
    }
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */