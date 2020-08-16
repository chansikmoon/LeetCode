public class Solution {
    public IList<int> GetRow(int rowIndex) {
        return DPSolution(rowIndex);
        
        List<int> list = new List<int>(){1};
        if (rowIndex == 0) return list;
        list.Add(1);
        if (rowIndex == 1) return list;
        
        return Traverse(list, 1, rowIndex);
    }
    
    private List<int> Traverse(List<int> list, int k, int target)
    {
        if (k == target) return list;
        
        List<int> nextList = new List<int>();
        
        nextList.Add(1);
        for (int i = 1; i < list.Count; i++)
            nextList.Add(list[i] + list[i - 1]);
        nextList.Add(1);
        
        return Traverse(nextList, k + 1, target);
    }
    
    private List<int> DPSolution(int rowIndex)
    {
        List<int> list = new List<int>();
        for (int i = 0; i <= rowIndex; i++)
            list.Add(1);
        
        for (int i = 0; i < rowIndex; i++)
            for (int j = i; j > 0; j--)
                list[j] = list[j] + list[j-1];
        
        return list;
    }
}