using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp;

// Testing Collections

public class ShoppingCart
{
    private readonly List<CartItem> items;

    public ShoppingCart()
    {
        items = new List<CartItem>();
    }

    public void AddItem(CartItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");

        items.Add(item);
    }

    public bool RemoveItem(CartItem item)
    {
        return items.Remove(item);
    }

    public IEnumerable<CartItem> GetItems(bool orderByAscending = true)
    {
        if (orderByAscending)
            return items.OrderBy(i => i.Price * i.Quantity);
        else
            return items.OrderByDescending(i => i.Price * i.Quantity);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.Price * item.Quantity;
        }
        return total;
    }
}


public class CartItem
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public CartItem(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

