using System.ComponentModel.DataAnnotations;

namespace PptNemocnice.Api.Data;

public class Vybaveni
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public int PriceCzk { get; set; }
    public DateTime BoughtDateTime { get; set; }
    public DateTime LastRevision { get; set; }
}
