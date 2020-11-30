public class Solution {
    public bool CanReach(int[] arr, int start) {
        return DFS(arr, start, new bool[arr.Length]);
    }
    
    public bool DFS(int[] arr, int start, bool[] visited)
    {
        if (start < 0 || start >= arr.Length || visited[start])
            return false;
        if (arr[start] == 0) 
            return true;
        visited[start] = true;
        
        bool ret = DFS(arr, start + arr[start], visited) || DFS(arr, start - arr[start], visited);
        
        return ret;
    }
}