public class Solution {
    public bool JudgePoint24(int[] nums) {
        List<double> list = new List<double>();
        
        foreach (int num in nums)
            list.Add((double) num);
        
        return DFS(list);
    }
    
    private bool DFS(List<double> list)
    {
        if (list.Count == 1)
        {
            if (Math.Abs(list[0] - 24.0) < 0.001)
                return true;
            return false;
        }
        
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                foreach (double c in GetPossibleResults(list[i], list[j]))
                {
                    List<double> nextList = new List<double>();
                    nextList.Add(c);
                    
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (k == i || k == j) continue;
                        nextList.Add(list[k]);
                    }
                    
                    if (DFS(nextList)) return true;
                }
            }
        }
        
        return false;
    }
    
    private List<double> GetPossibleResults(double a, double b)
    {
        List<double> ret = new List<double>();
        ret.Add(a + b);
        ret.Add(a - b);
        ret.Add(b - a);
        ret.Add(a * b);
        ret.Add(a / b);
        ret.Add(b / a);
        return ret;
    }
}