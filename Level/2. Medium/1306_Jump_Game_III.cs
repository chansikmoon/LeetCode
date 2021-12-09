public class Solution {
    public bool CanReach(int[] arr, int start) {
        return DFS(arr, new bool[arr.Length], start);
    }
    
    private bool DFS(int[] arr, bool[] visited, int index)
    {
        if (index < 0 || index >= arr.Length || visited[index])
            return false;
        
        if (arr[index] == 0)
            return true;
        
        visited[index] = true;
        var ret = DFS(arr, visited, index + arr[index]) || DFS(arr, visited, index - arr[index]);
        visited[index] = false;
        
        return ret;
    }
}