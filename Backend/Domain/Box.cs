namespace Domain;

public class Box
{
    public int Id { get; set; }
    public string Contents { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }



    public Box()
    {
        
    }
    
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

      
    }
    
    
    
  
}