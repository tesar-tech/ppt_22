namespace PptNemocnice.Shared;
public class VybaveniModel
{

    public string Name { get; set; } = "";
    public double PriceCzk { get; set; }
    public DateTime BoughtDateTime { get; set; }
    public DateTime LastRevision { get; set; }

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
    public static string RandomString(int length,Random rnd)=>
        new (Enumerable.Range(0, length).Select(_ => (char)rnd.Next('a', 'z')).ToArray());
}


