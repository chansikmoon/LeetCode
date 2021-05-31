/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        var ret = new List<IList<int>>();
        if (root == null)
            return ret;

        var q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int size = q.Count;
            ret.Add(new List<int>());

            while (size-- > 0)
            {
                var curr = q.Dequeue();
                ret.Last().Add(curr.val);

                foreach (var child in curr.children)
                    q.Enqueue(child);
            }
        }

        return ret;
    }
}