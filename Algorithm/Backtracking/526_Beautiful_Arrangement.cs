public class Solution {
    public int CountArrangement(int n) {
        return Helper(new bool[n+1], 1, n);
    }
    
    public int Helper(bool[] visited, int index, int n)
    {
        if (index > n)
            return 1;
        
        int ret = 0;
        
        for (int num=1;num<=n;num++)
        {
            if (visited[num])
                continue;
            if (num%index!=0 && index%num!=0)
                continue;
            visited[num]=true;
            ret+=Helper(visited,index+1,n);
            visited[num]=false;
        }
        
        return ret;
    }
}