public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        var ret = new List<int>();
        var str = "123456789";
        
        for (int length = 2; length <= str.Length; length++)
        {
            for (int left = 0; left <= str.Length - length; left++)
            {
                var subStr = str.Substring(left, length);
                int tmp = Int32.Parse(subStr);
                
                if (low <= tmp && tmp <= high)
                    ret.Add(tmp);
            }
        }
        
        return ret;
    }
}