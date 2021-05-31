
// https://stackoverflow.com/questions/5837572/generate-a-random-point-within-a-circle-uniformly/50746409#50746409
public class Solution
{
    private double radius;
    private double x_center;
    private double y_center;
    private Random rand;

    public Solution(double radius, double x_center, double y_center)
    {
        this.radius = radius;
        this.x_center = x_center;
        this.y_center = y_center;
        this.rand = new Random();
    }

    public double[] RandPoint()
    {
        double len = Math.Sqrt(rand.NextDouble()) * radius;
        double deg = rand.NextDouble() * 2 * Math.PI;
        double x = x_center + len * Math.Cos(deg);
        double y = y_center + len * Math.Sin(deg);
        return new double[] { x, y };
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(radius, x_center, y_center);
 * double[] param_1 = obj.RandPoint();
 */