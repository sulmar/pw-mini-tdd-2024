## Ćwiczenie - Wiekowanie płatności

## Wprowadzenie

Dział księgowości potrzebuje aplikacji do wiekowania płatności, która umożliwi kategoryzację faktur na podstawie terminu ich płatności. "Wiekowanie płatności" to proces stosowany w księgowości do kategoryzacji niezapłaconych faktur w zależności od czasu, jaki upłynął od ich terminu płatności.  aktury są klasyfikowane do odpowiednich przedziałów czasowych (nazywanych często "bucketami"), co pozwala na szybką ocenę stanu należności i podejmowanie działań mających na celu przyspieszenie ich ściągania.



## Zadanie

Utwórz klasę _VendorAgingReport_, która umożliwi wygenerowane zestawienia na podstawie listy faktur:

- Przykład zestawienia
```
| Kategoria              | 0-30 dni | 31-60 dni | 61-90 dni | 91-180 dni | Powyżej 180 dni |
|------------------------|----------|-----------|-----------|------------|-----------------|
| Liczba faktur          | 15       | 10        | 5         | 2          | 1               |
| Łączna kwota [PLN]     | 20,000   | 15,000    | 8,000     | 4,000      | 2,000           |
| Procent ogólnej sumy   | 40%      | 30%       | 16%       | 8%         | 4%              |
```

```csharp
public class Invoice
{
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
}

```

Wymagania realizuj zgodnie z techniką **TDD** (_Test-driven-development_):

- **Red** - kod nieprzechodzący test
- **Green** - kod przechodzący test
- **Refactor** - refaktoryzacja kodu i testów



