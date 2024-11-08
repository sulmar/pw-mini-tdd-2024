using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace TestApp.Mocking
{

    public partial class ApiService
    {
        public string Send(string address, string message)
        {
            Ping ping = new Ping();

            byte[] buffer = Encoding.ASCII.GetBytes(message);

            PingReply reply = ping.Send(address, timeout: 120, buffer);

            if (reply.Status == IPStatus.Success)
            {
                Trace.WriteLine($"Send {message}");

                return "Pong";
            }

            else
            {
                Trace.WriteLine("Network failer");

                throw new NetworkInformationException();
            }
        }
    }
}
