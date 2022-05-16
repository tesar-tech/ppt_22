14 - test 02

## Komentář k úkolu 13

- Lehký problém s přidáváním revizí je ten, že datum revize (podle kterého se určuje možnost a nemožnost přidat úkon)
se určuje na serveru. Musíme si tedy vytvořené datum poslat při vytvoření revize zpět. Více v komentáři v post /revize a v souboru `RevizeModel.cs`
  - dalo by se to obejít tím, že po vytvoření revize se tam na klientu přidá aktuální datum. Nemožnost úkonu je ve 2 letech, takže pár nepřesných sekund skutečně není problém.
  navíc se nemožnost úkonu kontroluje ještě na serveru
- Kontrola na serveru probíhá v post /ukon, jednoduše se vytáhnou všechny revize k vybavení a zkontroluje se ta nejmladší.

//draft 😎

  - Přidejte tabulku pracovníků, kteří daný úkon provádí (jsou za něj zodpovědní).
    - Například: Radiologický asistent, který provedl CT vyšetření. Doktor, který při operaci využil elektrokauter.
  - Umožněte vypsat všechny lidi, kteří kdy provedli úkon na daném vybavení.
    - implementujte řazení dle času úkonu, dle jména pracovníka