# Cv 01 - hádání čísel

V přiložené složce je Blazor projekt s hádáním čísel.

Oproti tomu, co jsme dodělali na cvičeních je v kódu něco navíc:

- Při zadávání čísel je možné vstup "odeslat" pomocí stisknutí klávesy Enter.
- Klávesa "N" vytvoří novou hru (zavolá metodu `Reset`)
- Po kliknutí na modrý čtverec se objeví správné řešení.
- Na začátku stránky je použita komponenta `PageTitle`, jedná se pouze o nastavení [titulku stránky](https://www.w3schools.com/TAGS/tag_title.asp).

Prozkoumejte aktuální implementaci a přidejte tuto funkcionalitu (možných řešení je spousta):

- Barva status textu se změní podle toho, jestli je hádané číslo menší nebo větší než číslo myšlené. 
- Přidejte historii zadaných čísel. Nějakým způsobem zobrazte všechny čísla, která uživatel doposud zadal. Při restartu se smaže i historie
