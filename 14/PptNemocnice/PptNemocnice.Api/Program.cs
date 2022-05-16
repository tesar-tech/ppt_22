using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<NemocniceDbContext>(
    opt => opt.UseSqlite("FileName=Nemocnice.db")
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins(builder.Configuration["AllowedOrigins"])
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


app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec, NemocniceDbContext db, IMapper mapper) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec)) return Results.Problem("Parametr musi byt neprazdny");
    var kdeJeRetezec = db.Revizes.Where(x => x.Name.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.MapPost("/revize", (RevizeModel prichoziModel,NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;//vynuluju id, db si idčka ošéfuje sama
    prichoziModel.DateTime = DateTime.UtcNow;//datum pridame na serveru
    Revize ent = mapper.Map<Revize>(prichoziModel);//mapovaná na "databázový" typ
    db.Revizes.Add(ent);//přidání do db
    db.SaveChanges();//uložení db (v tuto chvíli se vytvoří id)
    return Results.Created("/revize", new RevizeCreatedResponseModel(ent.Id,ent.DateTime));
});

app.MapPost("/ukon", (UkonModel ukonModel, NemocniceDbContext db, IMapper mapper) =>
{
    ukonModel.Id = Guid.Empty;
   var posledniRevizeDatum=  db.Vybavenis.Include(x => x.Revizes)//vybavení včetně revizí
                .SingleOrDefault(x => x.Id == ukonModel.VybaveniId)?//konkrétní vybavení 
                .Revizes.OrderBy(x=>x.DateTime)//všechny revize seřazené od nejstarší
                .LastOrDefault()?.DateTime;//poslední revize (nejvyšší datum) a její datum
    if (posledniRevizeDatum == null || posledniRevizeDatum.Value.AddYears(2) < DateTime.UtcNow)//dvouroční ověření
        return Results.BadRequest("Nem;6e se p5idat úkon, pokud je revize starší než 2 roky");

    Ukon ent = mapper.Map<Ukon>(ukonModel);
    db.Ukons.Add(ent);
    db.SaveChanges();
    return Results.Created("/ukon", ent.Id);
});



app.MapControllers();


app.Run();

//record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}