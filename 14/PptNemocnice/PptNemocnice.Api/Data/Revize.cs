namespace PptNemocnice.Api.Data;

public class Revize
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public Guid VybaveniId { get; set; }
    public Vybaveni Vybaveni { get; set; } = null!;

}
