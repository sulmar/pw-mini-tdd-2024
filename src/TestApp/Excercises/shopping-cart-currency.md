## Ćwiczenie - Koszyk zakupowy

## Wprowadzenie

Sklep internetowy wprowadza możliwość płacenia za zakupy w innej walucie niż PLN. W tym celu będzie korzystać z zewnętrznej usługi https://api.nbp.pl/

## Zadanie

Utwórz implementację i testy jednostkowe.

Szkic kodu:
```
// ShoppingCart.cs
public class ShoppingCart
{
    private readonly List<double> _items = new List<double>();
	private readonly ICurrencyService _currencyService;

    public ShoppingCart(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }
    
	public void AddItem(double price)
    {
        _items.Add(price);
    }

    public double CalculateTotalPriceInCurrency(string targetCurrency)
    {
        
    }
}
```

## Wymagania

1. Utwórz metodę _AddItem(double price)_
2. Wywołanie metody _AddItem(double price)_ z ujemną ceną powinno rzucić wyjątkiem _ArgumentException_ z komunikatem _"Negatives not allowed"_.
3. Wywołanie metody _AddItem(double price)_ z zerową ceną powinno rzucić wyjątkiem _ArgumentException_ z komunikatem _"Zero not allowed"_.
4. Utwórz metodę _CalculateTotalPriceInCurrency(string targetCurrency)_, która będzie przeliczać kwotę wg kursu pobranego z NBP
