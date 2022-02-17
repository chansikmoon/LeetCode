public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var ret = new List<IList<int>>();
        Backtracking(ret, new List<int>(), candidates, target, 0);
        return ret;
    }
    
    public void Backtracking(List<IList<int>> ret, List<int> list, int[] cand, int target, int i)
    {
        int sum = list.Sum();
        if (sum >= target)
        {
            if (sum == target)
                ret.Add(new List<int>(list));
            return;
        }
        
        for (; i < cand.Length; i++)
        {
            list.Add(cand[i]);
            Backtracking(ret, list, cand, target, i);
            list.RemoveAt(list.Count - 1);
        }
    }
}