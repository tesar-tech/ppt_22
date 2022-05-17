namespace PptNemocnice.Api.Data;

public class Pracovnik
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public List<Ukon> Ukons { get; set; } = new();

}
