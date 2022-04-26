using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PptNemocnice.Shared;
public class VybaveniSRevizemaModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public int PriceCzk { get; set; }
    public DateTime BoughtDateTime { get; set; }

    public List<RevizeModel> Revizes { get; set; } = new();

}


