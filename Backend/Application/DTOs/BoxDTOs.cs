namespace Application.DTOs;

public class PostBoxDTO
{
    
    public string Contents { get; set; }
    public double XWidth { get; set; }
    public double ZHeight { get; set; }
    public double YLength { get; set; }
    public double Weight { get; set; }


}

public class PartialUpdateBoxDTO
{
    public int Id { get; set; }
    public string? Contents { get; set; }
    public double? XWidth { get; set; }
    public double? ZHeight { get; set; }
    public double? YLength { get; set; }
    public double? Weight { get; set; }

}