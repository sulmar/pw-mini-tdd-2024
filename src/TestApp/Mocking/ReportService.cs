using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Mocking
{

    #region Models

    public class Order
    {
        public DateTime OrderedDate { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }

        public List<OrderDetail> Details { get; set; }

        public decimal Total => Details.Sum(d => d.Total);
    }

    public enum OrderStatus
    {
        Boxing,
        Sent,
    }

    public class OrderDetail
    {
        public OrderDetail(decimal unitPrice, short quantity = 1)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total => Quantity * UnitPrice;
    }

    public abstract class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }


    public class Employee : User
    {
        public bool IsBoss { get; set; }
    }

    public class Bot : User
    {

    }

    public abstract class Report
    {
        public DateTime CreatedOn { get; set; }

        public string Name { get; }

        public Report()
        {
            CreatedOn = DateTime.Now;
        }
    }

    public class SalesReport : Report
    {
        public TimeSpan TotalTime { get; set; }

        public decimal TotalAmount { get; set; }


        public override string ToString()
        {
            return $"Report created on {CreatedOn} \r\n TotalAmount: {TotalAmount}";
        }

        public string ToHtml()
        {
            return $"<html>Report created on <b>{CreatedOn}</b> <p>TotalAmount: {TotalAmount}<p></html>";
        }
    }

    #endregion

    public class ReportService
    {
        private const string apikey = "your_secret_key";

        public delegate void ReportSentHandler(object sender, ReportSentEventArgs e);
        public event ReportSentHandler ReportSent;

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();



        public async Task SendSalesReportEmailAsync(DateTime date)
        {
            OrderService orderService = new OrderService();

            var orders = orderService.Get(date.AddDays(-7), date);

            if (!orders.Any())
            {
                return;
            }

            SalesReport report = Create(orders);

            // dotnet add package SendGrid
            SendGridClient client = new SendGridClient(apikey);

            SalesContext salesContext = new SalesContext();

            var recipients = salesContext.Users.OfType<Employee>().Where(e => e.IsBoss).ToList();

            var sender = salesContext.Users.OfType<Bot>().Single();

            foreach (var recipient in recipients)
            {
                if (recipient.Email == null)
                    continue;

                var message = MailHelper.CreateSingleEmail(
                    new EmailAddress(sender.Email, $"{sender.FirstName} {sender.LastName}"), 
                    new EmailAddress(recipient.Email, $"{recipient.FirstName} {recipient.LastName}"), 
                    "Raport sprzedaży",
                    report.ToString(),
                    report.ToHtml());


                Logger.Info($"Wysyłanie raportu do {recipient.FirstName} {recipient.LastName} <{recipient.Email}>...");

                var response = await client.SendEmailAsync(message);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    ReportSent?.Invoke(this, new ReportSentEventArgs(DateTime.Now));

                    Logger.Info($"Raport został wysłany.");
                }
                else
                {
                    Logger.Error($"Błąd podczas wysyłania raportu.");

                    throw new ApplicationException("Błąd podczas wysyłania raportu.");
                }
            }
        }

        private static SalesReport Create(IEnumerable<Order> orders)
        {
            SalesReport salesReport = new SalesReport();

            salesReport.TotalAmount = orders.Sum(o => o.Total);

            return salesReport;
        }
    }

    public class ReportSentEventArgs : EventArgs
    {
        public readonly DateTime SentDate;

        public ReportSentEventArgs(DateTime sentDate)
        {
            this.SentDate = sentDate;
        }
    }

    public class OrderService
    {
        private readonly SalesContext context;

        public OrderService()
        {
            context = new SalesContext();
        }

        public IEnumerable<Order> Get(DateTime from, DateTime to)
        {
            return context.Orders.Where(o => o.OrderedDate > from && o.OrderedDate < to).ToList();
        }
    }

    public class SalesContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }


   

}