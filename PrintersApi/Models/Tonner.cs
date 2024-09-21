public class Tonner
{
    public int Id { get; set; }
    public string? Printer { get; set; }
    public string? Tipo { get; set; }
    public string? Cor { get; set; }
    public ICollection<Selb>? Selbs { get; set; }
}