// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

class PeekingIterator {
    private IEnumerator<int> iterator;
    private bool hasNext;
    // iterators refers to the first element of the array.
    public PeekingIterator(IEnumerator<int> iterator) {
        // initialize any member here.
        this.iterator = iterator;
        this.hasNext = true;
    }
    
    // Returns the next element in the iteration without advancing the iterator.
    public int Peek() {
        return this.iterator.Current;
    }
    
    // Returns the next element in the iteration and advances the iterator.
    public int Next() {
        int ret = this.iterator.Current;
        this.hasNext = this.iterator.MoveNext();
        return ret;
    }
    
    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext() {
		return this.hasNext;
    }
}