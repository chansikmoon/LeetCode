public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        Dictionary<string, int> map = new Dictionary<string, int>();
        
        for (int i = 0; i <= s.Length - 10; i++)
        {
            string subDNA = s.Substring(i, 10);
            
            if (!map.ContainsKey(subDNA))
                map.Add(subDNA, 0);
            
            map[subDNA]++;
        }
        
        return map.Where(x => x.Value > 1).Select(x => x.Key).ToList();
    }
}