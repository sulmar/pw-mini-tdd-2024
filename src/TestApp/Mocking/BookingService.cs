using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestApp.Mocking
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Status { get; set; }
    }

    public class BookingService
    {
        public bool OverlappingBookingsExists(Booking booking)
        {
            if (booking.Status == "Cancelled")
                return false;

            var db = new ApplicationContext();

            var bookings = db.Bookings.Where(b => b.Id != booking.Id && b.Status != "Cancelled");

            var overlappingBooking = bookings.FirstOrDefault(
                b => booking.ArrivalDate >= b.ArrivalDate
                && booking.ArrivalDate < b.DepartureDate
                || booking.DepartureDate > b.ArrivalDate
                && booking.DepartureDate <= b.DepartureDate);

            return overlappingBooking == null;

        }
    }

    public abstract class DbContext
    {
    }

    public abstract class DbSet<T> : IQueryable<T>
        where T : class
    {
        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
    }


}
