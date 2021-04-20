/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution
{
    public IList<int> Preorder(Node root)
    {
        var ret = new List<int>();
        if (root == null)
            return ret;

        var st = new Stack<Node>();
        st.Push(root);

        while (st.Count > 0)
        {
            var curr = st.Pop();
            ret.Add(curr.val);
            for (int i = curr.children.Count - 1; i >= 0; i--)
                st.Push(curr.children[i]);
        }

        return ret;
    }

    public void Helper(Node root, List<int> ret)
    {
        if (root == null)
            return;

        ret.Add(root.val);

        foreach (var child in root.children)
            Helper(child, ret);
    }
}