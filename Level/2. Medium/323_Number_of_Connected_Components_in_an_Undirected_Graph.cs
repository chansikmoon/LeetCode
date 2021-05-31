public class Solution
{
    public int CountComponents(int n, int[][] edges)
    {
        var uf = new UnionFind(n);

        foreach (var edge in edges)
            uf.Unite(edge[0], edge[1]);

        return uf.Component;
    }
}

public class UnionFind
{
    private int[] parent;
    private int[] size;
    private int component;

    public int Component
    {
        get
        {
            return component;
        }
    }

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];
        component = n;

        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    private int Find(int x)
    {
        while (x != parent[x])
            x = parent[x];
        return x;
    }

    public void Unite(int a, int b)
    {
        a = Find(a);
        b = Find(b);

        if (a == b)
            return;

        if (size[a] < size[b])
        {
            int tmp = size[a];
            size[a] = size[b];
            size[b] = tmp;
        }

        size[a] += size[b];
        size[b] = 0;
        parent[b] = a;
        component--;
    }
}