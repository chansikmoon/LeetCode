public class MyCalendar {
    public class booking
    {
        public int start;
        public int end;
        
        public booking(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    
    List<int[]> calendar;
    List<booking> bookingList;
    
    public MyCalendar() {
        calendar = new List<int[]>();
        bookingList = new List<booking>();
    }
    
    public bool Book(int start, int end) {
        booking newBook = new booking(start, end - 1);
        
        int index = FindIndex(start);
        
        if (bookingList.Count > 0)
        {
            if (index == -1)
                return false;
            
            //    10 ------------- 19
            //              15 ------------24
            if (index < bookingList.Count && bookingList[index].start <= newBook.end)
                return false;
            
            if (index > 0 && newBook.start <= bookingList[index - 1].end)
                return false;
        }
        
        bookingList.Insert(index, newBook);
        return true;
    }
    
    private int FindIndex(int start)
    {
        int l = 0, r = bookingList.Count - 1;
        
        while (l <= r)
        {
            int mid = (l + r) / 2;
            if (bookingList[mid].start == start)
                return -1;
            else if (bookingList[mid].start > start)
                r = mid - 1;
            else 
                l = mid + 1;
        }
        
        return l;
    }
    
    private bool BruteForce(int start, int end)
    {
        foreach (int[] cal in calendar)
        {
            if (cal[0] < end && start < cal[1])
                return false;
        }
        
        calendar.Add(new int[]{start, end});
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 
 One of the solutions:
 public class MyCalendar {

    private class TreeNode
    {
        public TreeNode(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int Start{get;set;}
        public int End {get;set;}
        public TreeNode Left{get;set;}
        public TreeNode Right{get;set;}
    }
    TreeNode _root;
    
    public MyCalendar() {
        
    }
    
    public bool Book(int start, int end) {
        var newNode = new TreeNode(start, end);
        if (_root == null)
        {
            _root = newNode;
            return true;
        }
        else
        {
            var node =  _root;
            while (true)
            {
                if (newNode.End <= node.Start)
                {
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        return true;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else if (node.End <= newNode.Start)
                {
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        return true;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                else
                {
                    return false;
                }                
            }
        }
    }
}

 
 
 */