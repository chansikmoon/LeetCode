/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public TreeNode Str2tree(string s)
    {
        var st = new Stack<TreeNode>();

        for (int r = 0, l = r; r < s.Length; r++, l = r)
        {
            char c = s[r];
            if (c == ')')
                st.Pop();
            else if (c != '(')
            {
                while (r + 1 < s.Length && s[r + 1] >= '0' && s[r + 1] <= '9')
                    r++;

                var newNode = new TreeNode(Int32.Parse(s.Substring(l, r - l + 1)));
                if (st.Count > 0)
                {
                    var parent = st.Peek();
                    if (parent.left != null)
                        parent.right = newNode;
                    else
                        parent.left = newNode;
                }

                st.Push(newNode);
            }
        }

        return st.Count == 0 ? null : st.Peek();
    }

    private TreeNode Recursion(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return null;

        int val = 0, l = 0, r = 0, bal = 1, sign = 1, n = s.Length;

        while (l < n && s[l] != '(')
        {
            if (s[l] == '-')
                sign = -1;
            else
                val = val * 10 + (s[l] - '0');
            l++;
        }

        val *= sign;
        r = l + 1;
        if (r >= n)
            return new TreeNode(val);

        while (bal != 0)
        {
            if (s[r] == '(')
                bal++;
            else if (s[r] == ')')
                bal--;
            r++;
        }

        var leftSub = Recursion(s.Substring(l + 1, Math.Max(r - l - 2, 0)));
        var rightSub = r >= n ? null : Recursion(s.Substring(r + 1, Math.Max(n - r - 2, 0)));
        return new TreeNode(val, leftSub, rightSub);
    }
}