namespace Domain;

public class Box
{
    public int Id { get; set; }
    public string Contents { get; set; }

    public double Width
    {
        get { return Width; }
        set
        { Weight = value;
            CalculateVolume();
            CalculateDensity();
        }
    }

    public double Height
    {
        get { return Height; }
        set
        { Height = value;
            CalculateVolume();
            CalculateDensity();
        }
    }

    public double Depth
    {
        get { return Depth; }
        set
        { Depth = value;
            CalculateVolume();
            CalculateDensity();
        } 
    }
    public double Weight
    {
        get { return Weight; }
        set
        { Weight = value;
            CalculateDensity();
        } 
    }
    public double Volume { get; private set; }
    public double Density { get; private set; }
    
    
    public Box(int id, string contents, double width, double height, double depth, double weight)
    {
        Id = id;

        if (!String.IsNullOrWhiteSpace(contents))
            Contents = contents;
        else Contents = "Empty Box";
        
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