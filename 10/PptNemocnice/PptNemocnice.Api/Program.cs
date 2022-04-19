using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NemocniceDbContext>(
    opt => opt.UseSqlite("FileName=Nemocnice.db")
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:7132")
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
));

var app = builder.Build();
app.UseCors();

app.MapGet("/", () => "Hellou");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<VybaveniModel> seznam = VybaveniModel.GetTestList();
List<RevizeModel> seznamRevizi = RevizeModel.NahodnySeznam(1000);

app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr musi byt neprazdny");
    var kdeJeRetezec = seznamRevizi.Where(x => x.Name.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.MapGet("/vybaveni", (NemocniceDbContext db) =>
{
    return db.Vybavenis;
});

app.MapGet("/vybaveni/jensrevizi", (int c) =>
{
    return seznam.Where(x=>!x.NeedsRevision);
});



app.MapGet("/vybaveni/{Id}",(Guid Id) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null) return Results.NotFound("takováto entita neexistuje");
    return Results.Json(item);
});

app.MapPost("/vybaveni", (VybaveniModel prichoziModel,
    NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si idčka ošéfuje sama
    Vybaveni ent = mapper.Map<Vybaveni>(prichoziModel);//mapovaná na "databázový" typ
    db.Vybavenis.Add(ent);//přidání do db
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoří id)

    return Results.Created("/vybaveni",ent.Id);
});

app.MapPut("/vybaveni", (VybaveniModel prichoziModel) =>
{
    var staryZaznam = seznam.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (staryZaznam == null) return Results.NotFound("Tento záznam není v seznamu");
    int ind = seznam.IndexOf(staryZaznam);
    seznam.Insert(ind, prichoziModel);
    seznam.Remove(staryZaznam);
    return Results.Ok();
});


app.MapDelete("/vybaveni/{Id}",(Guid Id ) =>
{
    var item = seznam.SingleOrDefault(x=> x.Id == Id);
    if (item == null) 
        return Results.NotFound("Tato položka nebyla nalezena!!");
    seznam.Remove(item);
    return Results.Ok();
}
);


app.Run();

//record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}