using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace WebPageAnalysis.Services
{
    public class WebPageWorker : IWebPageWorker
    {
        public WebPageWorker()
        {
        }
        public async Task<int> CouuntWordAsync(string[] urls, string word, CancellationToken cancellationToken)
        {
            var counts = new ConcurrentBag<int>();

            await Parallel.ForEachAsync(urls, cancellationToken, async (url, c) =>
             {
                 using HttpClient httpClient = new HttpClient();
                 using var request = new HttpRequestMessage(HttpMethod.Get, url);
                 using var response = await httpClient.SendAsync(request, c);
                 string responseText = await response.Content.ReadAsStringAsync(c);
                 var count = Regex.Matches(responseText.ToLower(), word.ToLower()).Count;
                 counts.Add(count);

             });
            return counts.Sum();
        }
    }
}
