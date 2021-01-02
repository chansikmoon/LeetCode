public class Solution {
    public bool CanFormArray(int[] arr, int[][] pieces) {
        var map = new Dictionary<int, int[]>();
        
        foreach (var piece in pieces)
            map.Add(piece[0], piece);
        
        var res = new int[arr.Length];
        int i = 0;
        
        foreach (int num in arr)
        {
            if (map.ContainsKey(num))
            {
                foreach (var p in map[num])
                    res[i++] = p;
            }
        }
        
        return arr.SequenceEqual(res);
    }
    
    private bool BruteForce(int[] arr, int[][] pieces)
    {
        var map = new Dictionary<int, int>();
        
        for (int i = 0; i < arr.Length; i++)
            map.Add(arr[i], i);
        
        foreach (var piece in pieces)
        {
            if (!map.ContainsKey(piece[0]))
                return false;
            
            int prevIndex = map[piece[0]];
            
            for (int i = 1; i < piece.Length; i++)
            {
                if (!map.ContainsKey(piece[i]) || map[piece[i]] != prevIndex + 1)
                    return false;
                
                prevIndex = map[piece[i]];
            }
        }
        
        return true;
    }
}