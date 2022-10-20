namespace Domain;

public class Box
{
    public int Id { get; set; }
    public string Contents { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
   
    public double BoxDepth { get; set; }
    public double Weight { get; set; }



    public Box()
    {
        
    }
    
    public Box(int id, string contents, double width, double height, double boxDepth, double weight)
    {
        Id = id;

        if (!String.IsNullOrWhiteSpace(contents))
            Contents = contents;
        else Contents = "Empty Box";
        
        Width = width;
        Height = height;
        this.BoxDepth = boxDepth;
        Weight = weight;

      
    }
    
    
    
  
}