public class MovieRentingSystem {
    private Dictionary<int, SortedSet<(int price, int shop)>> Movies; // movieId, <price, shop>
    private Dictionary<(int movie, int shop), int> MovieShopToPrice; // <movie, shop> price
    private Dictionary<int, HashSet<int>> Rented;
    private SortedSet<(int price, int shop, int movie)> CheapestRentedMovies;
    
    public MovieRentingSystem(int n, int[][] entries) {
        Movies = new Dictionary<int, SortedSet<(int, int)>>();
        MovieShopToPrice = new Dictionary<(int, int), int>();
        Rented = new Dictionary<int, HashSet<int>>();
        CheapestRentedMovies = new SortedSet<(int price, int shop, int movie)>();
        
        foreach (var entry in entries)
        {
            (int shop, int movie, int price) val = (entry[0], entry[1], entry[2]);
            if (!Movies.ContainsKey(val.movie))
                Movies.Add(val.movie, new SortedSet<(int price, int shop)>());
            
            Movies[val.movie].Add((val.price, val.shop));
                
            MovieShopToPrice.Add((val.movie, val.shop), val.price);
        }
    }
    
    public IList<int> Search(int movie) {
        if (Movies.ContainsKey(movie))
            return Movies[movie].Take(5).Select(x => x.shop).ToList();
        return new List<int>();
    }
    
    public void Rent(int shop, int movie) {
        if (!Movies.ContainsKey(movie))
            return;
        
        if (!Rented.ContainsKey(movie))
            Rented.Add(movie, new HashSet<int>());
        Rented[movie].Add(shop);
        
        int price = MovieShopToPrice[(movie, shop)];
        CheapestRentedMovies.Add((price, shop, movie));
        Movies[movie].Remove((price, shop));
    }
    
    public void Drop(int shop, int movie) {
        Rented[movie].Remove(shop);
        int price = MovieShopToPrice[(movie, shop)];
        CheapestRentedMovies.Remove((price, shop, movie));
        Movies[movie].Add((price, shop));
    }
    
    public IList<IList<int>> Report() {
        return CheapestRentedMovies
            .Take(5)
            .Select(rent => new int[] {rent.shop, rent.movie} as IList<int>)
            .ToList();
    }
}

/**
 * Your MovieRentingSystem object will be instantiated and called as such:
 * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
 * IList<int> param_1 = obj.Search(movie);
 * obj.Rent(shop,movie);
 * obj.Drop(shop,movie);
 * IList<IList<int>> param_4 = obj.Report();
 */