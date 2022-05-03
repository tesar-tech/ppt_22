# 12 Kontrolery, logging

## Přidání controlleru

- aktuálně máme všechny endopinty v Program.cs (minimal API)
- je vhodné je lépe uspořádat
- jedním z uspořádáním mohou být tradiční kontrolery.

### GET /vybaveni do kontroleru.

- Vytvořte ve složce `Controllers` třídu `VybaveniController` (je dobré zachovat jmené)
- Bude dědit z třídy `ControllerBase`
- Dekorujte jí atributy `[ApiController]` `[Route("[controller]")]`
- Vytvořte metodu `GetAllVybaveni` (na názvu nezáleží).
  - je veřejná
  - vrací seznam `VybaveniModel` 
  - má atribut `[HttpGet]`
  - vložte kód do z endpointu `Program.cs`, patřičně ho upravte.
  - `db` a `mapper` se injektují v konstuktoru
    - vytvořte si tedy private readonly proměnné
      - (dle konvence budou uvození _podtržítkem)

- Změny dozná i `Program.c`s (api),
  - přidejte do servis kontrollery (`AddController`)
  - před spuštěním apliace se musí namapovat (`MapControllers`)

- Předělejte endpointy pro vybavení nebo revize do kontrolerů. 

## Logging

- Způsob jakým zachytit, co se v aplikaci děje
- Už ho používáte -> jsou to ty výpisy v konzoli
- Využívá se asp.net core logging, ale existují i jiné (NLog,Log4Net, Serilog)
- Konzole je jedna z "výevek" (sink), ostatní můžou být: databáze, soubor, debug okno ve vs, Azure Blob storage, Azure app insights,..
- Logger už je přidátn (jako spoustu defaultních věcí v `WebApplication.CreateBuilder(args);`)
- Využití: 

  ```chsarp
  _logger.LogWarning("varování, právě jsem něco zalogoval 🚨")
  ```

- Různé úrovně (trace, debug, info, warning, error, critical)
- Nastavení v appsetting.
- Vytvořte log v kontrolerech. Například -> "Byla přidána revize.."

## dú: Úkony

- Vytvořte funkcionalitu úkonů.
- Úkon je proveden s vybavením (například provedený CT scan) a je nutné jej zaznamenávat.
- Bude možné se podívat na úkony provedené s každým vybavním.

- Vymyslete:
  - jaké vlastnosti se budou ukládat. Seznam úkonů je důležitý například pro pojišťovnu.
  - s čím je to propojeno
  - jakým způsobem se to bude zaznamenávat  (jak bude fungovat UI)
- Úkony implementujte (jak api tak klientsou část)
