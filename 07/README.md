# 07 - draft

 records, databáze, EF, REST client, 
přidání klienta v blazoru 

csharp
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7058") });

csharp
    [Inject] public HttpClient HttpClient { get; set; } = null!;
    List<VybaveniModel>? seznamVybaveni;

    protected override async Task OnInitializedAsync()
    {
        seznamVybaveni = await HttpClient.GetFromJsonAsync<List<VybaveniModel>>("vybaveni");
    }
Do api přidat cors: 

csharp
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod();
}));
//za  builder.Build()
app.UseCors();