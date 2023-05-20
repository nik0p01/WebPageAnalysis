namespace WebPageAnalysis.Services
{
    public interface IWebPageWorker
    {
        Task<int> CouuntWordAsync(string[] urls, string word, CancellationToken cancellationToken = default);
    }
}