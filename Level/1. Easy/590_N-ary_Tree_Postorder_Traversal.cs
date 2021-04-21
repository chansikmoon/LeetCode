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
    public IList<int> Postorder(Node root)
    {
        var ret = new List<int>();
        if (root == null)
            return ret;

        var st = new Stack<Node>();
        st.Push(root);

        while (st.Count > 0)
        {
            var curr = st.Pop();

            for (int i = 0; i < curr.children.Count; i++)
                st.Push(curr.children[i]);

            ret.Add(curr.val);
        }
        // Helper(root, ret);
        ret.Reverse();

        return ret;
    }

    private void Helper(Node root, List<int> ret)
    {
        if (root == null)
            return;

        foreach (var child in root.children)
            Helper(child, ret);

        ret.Add(root.val);
    }
}