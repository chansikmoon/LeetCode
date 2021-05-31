public class SeatManager
{
    SortedSet<int> pq = null;

    public SeatManager(int n)
    {
        pq = new SortedSet<int>();

        for (int i = 1; i <= n; i++)
            pq.Add(i);
    }

    public int Reserve()
    {
        int minSeat = pq.Min;
        pq.Remove(pq.Min);
        return minSeat;
    }

    public void Unreserve(int seatNumber)
    {
        pq.Add(seatNumber);
    }
}

/**
 * Your SeatManager object will be instantiated and called as such:
 * SeatManager obj = new SeatManager(n);
 * int param_1 = obj.Reserve();
 * obj.Unreserve(seatNumber);
 */