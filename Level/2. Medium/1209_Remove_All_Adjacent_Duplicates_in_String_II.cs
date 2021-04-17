public class Solution {
    public string RemoveDuplicates(string s, int k) {
        var list = new List<Tuple<int, char>>();
        list.Add(new Tuple<int, char>(0, '#'));
        
        foreach (char c in s)
        {
            int freq = list.Last().Item1 + 1;
            
            if (list.Last().Item2 != c)
                list.Add(new Tuple<int, char>(1, c));
            else 
            {
                list.Add(new Tuple<int, char>(freq, c));
                
                if (freq == k)
                    list.RemoveRange(list.Count-k, k);
            }
        }
        
        list.RemoveAt(0);
        var sb = new StringBuilder();
        
        foreach (var t in list)
            sb.Append(t.Item2);
        
        return sb.ToString();
    }
}