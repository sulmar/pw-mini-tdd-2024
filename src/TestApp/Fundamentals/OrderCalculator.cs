using System;

namespace TestApp.Fundamentals
{
    #region Models

    public class Order
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
    }


    public class Customer
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }

    #endregion


    public class OrderCalculator
    {
        public decimal CalculateDiscount(Order order)
        {
            throw new NotImplementedException();
        }
    }

    // TODO: Utwórz promocję "Happy Hours" - 10% upustu w godzinach od 9 do 15

    // TODO: Utwórz promocję "Black Friday" - 30% upustu w określony dzień

    // TODO: Utwórz promocję "Lubię Poniedziałki" - 10 zł mniej w każdy poniedziałek za zamówienia powyżej 50 zł



}
