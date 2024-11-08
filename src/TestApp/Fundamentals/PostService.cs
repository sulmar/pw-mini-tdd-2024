using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    // Async Testing
    public class PostService
    {
        public async Task<string> FetchData(string url)
        {
            // Simulate fetching data asynchronously with Task.Delay
            await Task.Delay(100);

            // For simplicity, just return a mock response
            return "{\"userId\":1,\"id\":1,\"title\":\"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\",\"body\":\"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"}";
        }
    }
}
