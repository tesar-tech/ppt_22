# 12 Kontrolery, úkony

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


## dú: Úkony

- Vytvořte funkcionalitu úkonů.
- Úkon je proveden s vybavením (například provedený CT scan) a je nutné jej zaznamenávat.
- Bude možné se podívat na úkony provedené s každým vybavním.

- Vymyslete:
  - jaké vlastnosti se budou ukládat. Seznam úkonů je důležitý například pro pojišťovnu.
  - s čím je to propojeno
  - jakým způsobem se to bude zaznamenávat  (jak bude fungovat UI)
- Úkony implementujte (jak api tak klientsou část)
