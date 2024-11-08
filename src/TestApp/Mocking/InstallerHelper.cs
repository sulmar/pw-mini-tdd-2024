using System.Net;

namespace TestApp.Mocking;


public partial class ApiService
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;

        public bool DownloadInstaller(string customerName, string installerName)
        {
            var client = new WebClient();
            try
            {
                client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
