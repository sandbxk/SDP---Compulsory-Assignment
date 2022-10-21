namespace Domain;

public class Box
{
    public int Id { get; set; }
    public string Contents { get; set; }
    public double XWidth { get; set; }
    public double ZHeight { get; set; }
    public double YLength { get; set; }
    public double Weight { get; set; }



    public Box()
    {
        
    }
    
    public Box(int id, string contents, double xWidth, double zHeight, double yLength, double weight)
    {
        Id = id;

        if (!String.IsNullOrWhiteSpace(contents))
            Contents = contents;
        else Contents = "Empty Box";
        
        XWidth = xWidth;
        ZHeight = zHeight;
        YLength = yLength;
        Weight = weight;

      
    }
    
    
    
  
}