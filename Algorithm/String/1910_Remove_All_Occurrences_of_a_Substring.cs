public class Solution {
    public string RemoveOccurrences(string s, string part) {
        int index = s.IndexOf(part);
        while (index >= 0)
        {
            s = s.Remove(index, part.Length);
            index = s.IndexOf(part);
        }
        
        return s;
    }
}