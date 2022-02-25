public class Solution {
    public int CompareVersion(string version1, string version2) {
        var v1 = SplitIntoIntList(version1);
        var v2 = SplitIntoIntList(version2);
        
        int i = 0, j = 0;
        
        while (i < v1.Count && j < v2.Count)
        {
            if (v1[i] < v2[j])
                return -1;
            else if (v1[i] > v2[j])
                return 1;
            
            i++;
            j++;
        }
        
        while (i < v1.Count && j == v2.Count)
        {
            if (v1[i++] > 0)    
                return 1;
        }
        
        while (j < v2.Count && i == v1.Count)
        {
            if (v2[j++] > 0)    
                return -1;
        }
        
        return 0;
    }
    
    private List<int> SplitIntoIntList(string v)
    {
        var splits = v.Split('.');
        var ret = new List<int>();
        
        foreach (var split in splits)
        {
            int num = 0;
            
            for (int i = 0; i < split.Length; i++)
                num = num * 10 + split[i] - '0';
            
            ret.Add(num);
        }
        
        return ret;
    }
}