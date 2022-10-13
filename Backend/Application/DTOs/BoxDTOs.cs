namespace Application.DTOs;

public class PostBoxDTO
{
    
    public string Contents { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public double Density { get; set; }

}

public class PartialUpdateBoxDTO
{
    public int Id { get; set; }
    public string? Contents { get; set; }
    public double? Width { get; set; }
    public double? Height { get; set; }
    public double? Depth { get; set; }
    public double? Weight { get; set; }

}