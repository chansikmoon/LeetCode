public class Logger {
    Dictionary<string, int> cache = null;
    /** Initialize your data structure here. */
    public Logger() {
        cache = new Dictionary<string, int>();
    }
    
    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message) {
        if (!cache.ContainsKey(message))
        {
            cache.Add(message, timestamp);
            return true;
        }
        
        if ((timestamp - cache[message]) >= 10)
        {
            cache[message] = timestamp;
            return true;
        }
        
        return false;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */