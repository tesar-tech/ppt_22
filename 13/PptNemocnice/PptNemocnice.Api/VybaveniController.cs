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

    [HttpGet("{id}")]//vybaveni
    public ActionResult<VybaveniDetailModel> GetOneVybaveni( Guid id)
    {
        var item = _db.Vybavenis.Include(x => x.Revizes).Include(x => x.Ukons).SingleOrDefault(x => x.Id == id);
        if (item == null) return NotFound("takováto entita neexistuje");
        return _mapper.Map<VybaveniDetailModel>(item);
    }

    [HttpPost]
    public ActionResult<VybaveniDetailModel> AddVybaveni(VybaveniModel prichoziModel)
    {
        prichoziModel.Id = Guid.Empty;//vynuluju id, db si idčka ošéfuje sama
        Vybaveni ent = _mapper.Map<Vybaveni>(prichoziModel);//mapovaná na "databázový" typ
        _db.Vybavenis.Add(ent);//přidání do db
        _db.SaveChanges();//uložení db (v tuto chvíli se vytvoří id)

        return Created("/vybaveni", ent.Id);
    }

    [HttpPut]
    public ActionResult EditVybaveni(VybaveniModel prichoziModel)
    {
        Vybaveni? staryZaznam = _db.Vybavenis.SingleOrDefault(x => x.Id == prichoziModel.Id);
        if (staryZaznam == null) return NotFound("Tento záznam není v seznamu");
        _mapper.Map(prichoziModel, staryZaznam);
        _db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public ActionResult DeleteVybaveni(Guid Id)
    {
        var item = _db.Vybavenis.SingleOrDefault(x => x.Id == Id);
        if (item == null)
            return NotFound("Tato položka nebyla nalezena!!");
        _db.Remove(item);
        _db.SaveChanges();
        return Ok();
    }
}
