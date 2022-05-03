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


## Seznam úkonů s vybavením

- Úkony na vybavení je nutné zaznamenat (například provedený CT scan)
- Vymyslete:
  - jaké vlastnosti se budou ukládat
  - s čím je to propojeno
  - jakým způsobem se to bude zaznamenávat
- Úkony implementujte (jak api tak klientsou část)
(celkem úmyslně je zadání vágní)

- Dále implementujte: 
  - Nelze provádět úkony na vybavení, které má revizi starší než 2 roky. 
  - Přidejte tabulku pracovníků, ktří daný úkon provádí (jsou za něj zodpovědní).
    - Například: Radiologický asistent, který provedl CT vyšetření. Doktor, který při operaci využil elektrokauter.
  - Umožněte vypsat všechny lidi, kteří kdy provedli úkon na daném vybavení. 
    - implementujte řazení dle času úkonu, dle jména pracovníka