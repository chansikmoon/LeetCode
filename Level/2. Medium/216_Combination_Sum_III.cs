public class Solution {
    private int[] arr;
    private int k;
    private int n;
    
    public IList<IList<int>> CombinationSum3(int k, int n) {
        this.arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        this.k = k;
        this.n = n;
        
        var ret = new List<IList<int>>();
        Backtracking(ret, new List<int>(), 0);
        return ret;
    }
    
    private void Backtracking(List<IList<int>> ret, List<int> list, int idx) 
    {
        if (list.Count >= this.k) {
            if (list.Sum() == this.n) {
                ret.Add(new List<int>(list));
            }
            
            return;
        }
        
        for (; idx < 9; idx++) {
            list.Add(this.arr[idx]);
            Backtracking(ret, list, idx + 1);
            list.RemoveAt(list.Count - 1);
        }
    }
}