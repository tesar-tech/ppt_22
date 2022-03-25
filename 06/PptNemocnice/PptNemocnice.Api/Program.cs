using PptNemocnice.Shared;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<VybaveniModel> seznam = VybaveniModel.GetTestList();

app.MapGet("/vybaveni", () =>
{
    return seznam;
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

app.MapPost("/vybaveni", (VybaveniModel prichoziModel) =>
{
    prichoziModel.Id = Guid.NewGuid();
    seznam.Insert(0, prichoziModel);
    return prichoziModel.Id;
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