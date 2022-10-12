namespace Domain;

public class Box
{
    public int Id { get; set; }
    public string Contents { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
    public double Volume { get; private set; }
    public double Density { get; private set; }
    
    
    public Box(int id, string contents, double width, double height, double depth, double weight)
    {
        Id = id;
        Contents = contents;
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;

        CalculateVolume();
        CalculateDensity();
    }
    
    
    
    public double CalculateVolume()
    {
        Volume = Width * Height * Depth; 
        return Volume;
    }
    
    public double CalculateDensity()
    {
        if (Weight == 0)
        {
            throw new ArgumentException("Weight cannot be zero");
        }
        
        Density = Weight / Volume;
        return Density;
    }
}