public class Printer 
{
    public int Id { get; set; }
    public string? Ip { get; set; }
    public string? Local { get; set; }
    public string? Setor { get; set; }
    public string? Senha { get; set; }
    public string? Nome { get; set; }
    public ICollection<Selb>? Selbs { get; set; }
}