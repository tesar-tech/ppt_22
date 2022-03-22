using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PptNemocnice.Shared;
public class VybaveniModel
{


    public Guid Id { get; set; }

    [Required, MinLength(5, ErrorMessage = "Délka u pole \"{0}\" musí být alespoň {1} znaků")]
    [Display(Name = "Název")]
    public string Name { get; set; } = "";

    [Display(Name = "Cena")]
    [Range(1, 10_000_000, ErrorMessage = "{0} musí být v rozsahu {1} až {2} ")]
    public int PriceCzk { get; set; }
    public DateTime BoughtDateTime { get; set; }
    public DateTime LastRevision { get; set; }

    [JsonIgnore]
    public bool NeedsRevision => DateTime.Now - LastRevision > TimeSpan.FromDays(365*2);

    public bool IsInEditMode { get; set; }
    public static List<VybaveniModel> GetTestList()
    {
        List<VybaveniModel> list = new();
        Random rnd = new();
        for (int i = 0; i < 20; i++)
        {
            VybaveniModel model = new()
            {
                Id = Guid.NewGuid(),
                Name = RandomString(rnd.Next(5, 25), rnd),
                PriceCzk = rnd.Next(5000, 10_000_000),
                BoughtDateTime = DateTime.Now.AddDays(-rnd.Next(3*365, 20 * 365)),
                LastRevision = DateTime.Now.AddDays(-rnd.Next(0, 3 * 365)),
            };

            //model.

            list.Add(model);
        }
        return list;

    }

    public void MapTo(VybaveniModel? to)
    {
        if (to == null) return;
        to.BoughtDateTime = BoughtDateTime;
        to.LastRevision = LastRevision;
        to.Name = Name;
        to.PriceCzk = PriceCzk;
    }

    public VybaveniModel Copy()
    {
        VybaveniModel to = new();
        to.BoughtDateTime = BoughtDateTime;
        to.LastRevision = LastRevision;
        to.IsInEditMode = IsInEditMode;
        to.Name = Name;
        to.PriceCzk = PriceCzk;
        return to;
    }
    public static string RandomString(int length,Random rnd)=>
        new (Enumerable.Range(0, length).Select(_ => (char)rnd.Next('a', 'z')).ToArray());


}


