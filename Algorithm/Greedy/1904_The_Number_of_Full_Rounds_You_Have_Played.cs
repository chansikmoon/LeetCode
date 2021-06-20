public class Solution {
    public int NumberOfRounds(string startTime, string finishTime) {
        int start = ConvertToTotalMinute(startTime);
        int end = ConvertToTotalMinute(finishTime);
        if (end < start)
            end += 24 * 60;
        
        // floor finish time
        // ceiling start time => 1 ~ 14 => 15 and so on
        return Math.Max(0, end / 15 - (start + 14) / 15);
    }
    
    private int ConvertToTotalMinute(string time)
    {
        var splits = time.Split(':');
        return Int32.Parse(splits[0]) * 60 + Int32.Parse(splits[1]);
    }
}