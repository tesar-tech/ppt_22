namespace PptNemocnice.Shared;

public class RevizeModel
{
    public string Name { get; set; } = "";
    public Guid Id { get; set; }

    public Guid VybaveniId { get; set; }

    public DateTime DateTime { get; set; }
    //public static List<RevizeModel> NahodnySeznam(int v)
    //{
    //    List<RevizeModel> list = new();
    //    Random random = new();
    //    for (int i = 0; i < v - 1; i++)
    //    {
    //        var r = new RevizeModel { Id = Guid.NewGuid(), Name = VybaveniModel.RandomString(15, random) };
    //        list.Add(r);
    //    }
    //    return list;
    //}
}