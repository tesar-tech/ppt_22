# 13 Logging
//DRAFT

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


## Doktoři

- Dále implementujte: 
  - Nelze provádět úkony na vybavení, které má revizi starší než 2 roky. 
  - Přidejte tabulku pracovníků, ktří daný úkon provádí (jsou za něj zodpovědní).
    - Například: Radiologický asistent, který provedl CT vyšetření. Doktor, který při operaci využil elektrokauter.
  - Umožněte vypsat všechny lidi, kteří kdy provedli úkon na daném vybavení. 
    - implementujte řazení dle času úkonu, dle jména pracovníka