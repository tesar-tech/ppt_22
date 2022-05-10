using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;

namespace PptNemocnice.Api;

[ApiController]
[Route("[controller]")]
public class VybaveniController:ControllerBase
{

    private readonly NemocniceDbContext _db;
    private readonly IMapper _mapper;

    public VybaveniController(IMapper mapper, NemocniceDbContext db)
    {
        _mapper = mapper;
        _db = db;
    }



    [HttpGet]//vybaveni
    public ActionResult<List<VybaveniModel>> GetVybaveni()
    {
       
        var ents = _db.Vybavenis.Include(x => x.Revizes);

        List<VybaveniModel> models = new();
        foreach (var ent in ents)
        {
            var vybModel = _mapper.Map<VybaveniModel>(ent);
            ent.Revizes.OrderBy(x => x.DateTime);
            vybModel.LastRevision = ent.Revizes.OrderByDescending(x => x.DateTime).FirstOrDefault()?.DateTime;
            models.Add(vybModel);
        }
        return models;
    }


    //vybaveni/a98179b3-9744-43d8-9655-a8793b5752a7
    //[HttpGet("detail/{id}")]//vybaveni/detail/a98179b3-9744-43d8-9655-a8793b5752a7
    //[HttpGet(Name ="prvni")]//vybaveni/prvni
}
