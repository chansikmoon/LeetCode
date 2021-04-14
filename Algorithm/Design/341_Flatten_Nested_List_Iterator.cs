/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    private List<int> list { get; set; }
    private int currIndex { get; set; }
    
    public NestedIterator(IList<NestedInteger> nestedList) {
        list = new List<int>();
        currIndex = 0;
        FlattenNestedList(nestedList);
    }
    
    private void FlattenNestedList(IList<NestedInteger> nestedList) {
        foreach (var nl in nestedList)
        {
            if (nl.IsInteger())
                list.Add(nl.GetInteger());
            else
                FlattenNestedList(nl.GetList());
        }
    }
    

    public bool HasNext() {
        return currIndex < list.Count;
    }

    public int Next() {
        return list[currIndex++];
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */