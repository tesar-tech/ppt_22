# 08 - Konzumace API (DELETE, POST, PUT), HttpClient, async/await

## Http klient a DELETE

- Na stránce `Vybaveni.razor` změňte akci, která se odehrává po zavolání callbacku `DeleteItemCallBack`.
- Zavolejte metodu `DeleteVybaveni`. Přijme právě položku, kterou má smazat.
- Na Http klientovy existuje metoda `DeleteAsync`
  - Zadejte ji cestu, včetně parametrů, které api očekává
  - Jejím výstupem je `HttpResponseMessage` s propertou `IsSuccessStatusCode`, použijte ji a v případě úspěšného smazání (skrz api) odstraňte položku ze seznamu na klientovi.

## Http klient - PUT

- V principu jsou akce POST a PUT dosti podobné. Posílá se celý model.
- Volá se na callbacku `EditDoneCallback`.
- Model specifikujete v druhém parametru metody `PutAsJsonAsync`.
- Nyní nemáme mechanismus, který by při chybě na straně api vrátil provedené změny
  - Stačilo by uživatele informovat a doporučit obnovení stránky.

## Http klient a POST

- V případě POSTu je nutné vyzvednout přichozí ID nově vytvořené entity a přiřadit ho.
  - (Id musíme mít, kdybychom ho chtěli třeba rovnou smazat)
- `PostAsJsonAsync`  také vrací `HttpResponseMessage` a krom status kódu má ještě vlastnost `Content`.
  - Content obsahuje metodu pro čtení JSONu a převedení na požadovaný typ (`ReadFromJsonAsync`).
  - Formát je generický parametr (špičaté závorky)

## Domácí úloha - Endpoint vybaveni/{Id}

Tento endpoint využijeme na nové stránce, která bude zobrazovat podrobnější detail jednoho vybavení.
Aktuálně žádný takový detail nemáme, ten doplníme posléze. Bude to seznam oprav, které připadají k danému vybavení. Teď na stránce pouze vypíšeme vlastnosti jednoho vybavení (jméno, cenu,...)

[route parameters](https://blazor-university.com/routing/route-parameters/)

- Přidejte stránku s názvem `VybaveniDetail`.
  - route nastavte na "/vybaveni/{Id:guid}", nezapomeňte na direktivu `page`
  - přidejte parametr `Id`, parametr bude nastaven právě z routy.
- Do tabulky přidejte odkaz, který bude odkazovat na stránku detailu daného Id.

## Stránka detailu

- Na stránce vytvoříme jednoduchý grid, který zobrazí všechny detaily.

    ```html
    <div class="grid grid-cols-2"> 
    <div>Název</div>
    <div>@item.Name</div>
    </div>
    ```

- Nepoužíváme zde tabulku jako takovou (table). Nemusíme specifikovat řádky (tr), ani jednotlivé buňky (td). Stačí pouze říct, že aktuální div je grid a že má 2 sloupce. Vnitřní elementy podle toho přeskládá. V mnohém se HTML grid podobá tomu v XAML.
  - grid není tak ukecaný a je více přizpůsobivý.
- V metodě `OnInitializedAsync` načtěte data z API.
