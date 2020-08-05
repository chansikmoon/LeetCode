public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        for (int i = 0; i < sources.Length; i++)
        {
            if (S.Substring(indexes[i], sources[i].Length) == sources[i])
            {
                map.Add(indexes[i], i);
            }
        }
      
        StringBuilder sb = new StringBuilder();
      
        for (int i = 0; i < S.Length; i++)
        {
            if (map.ContainsKey(i))
            {
                sb.Append(targets[map[i]]);
                i += sources[map[i]].Length - 1 ;
            }
            else
            {
                sb.Append(S[i]);
            }
        }
      
        return sb.ToString();
    }
}