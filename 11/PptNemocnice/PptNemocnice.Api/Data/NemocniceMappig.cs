using AutoMapper;
using PptNemocnice.Shared;

namespace PptNemocnice.Api.Data;

public class NemocniceMappig:Profile
{

    public NemocniceMappig()
    {
        CreateMap<Vybaveni, VybaveniModel>().ReverseMap();
        CreateMap<Vybaveni, VybaveniSRevizemaModel>();
        CreateMap<Revize, RevizeModel>().ReverseMap();
    }

}
