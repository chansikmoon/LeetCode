public class SnapshotArray {
    private Dictionary<int, int>[] snapMapArray;
    private int snapID;

    public SnapshotArray(int length) {
        snapMapArray = new Dictionary<int, int>[length];
    }
    
    public void Set(int index, int val) {
        if (snapMapArray[index] == null)
            snapMapArray[index] = new Dictionary<int, int>();
        
        if (!snapMapArray[index].ContainsKey(snapID))
            snapMapArray[index].Add(snapID, val);
        
        snapMapArray[index][snapID] = val;
    }
    
    public int Snap() {
        return snapID++;
    }
    
    public int Get(int index, int snap_id) {
        if (snapMapArray[index] == null)
            return 0;
        
        if (snapMapArray[index].ContainsKey(snap_id))
            return snapMapArray[index][snap_id];
        
        while (!snapMapArray[index].ContainsKey(snap_id) && snap_id != -1)
            snap_id--;
        
        return snap_id == -1 ? 0 : snapMapArray[index][snap_id];
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */