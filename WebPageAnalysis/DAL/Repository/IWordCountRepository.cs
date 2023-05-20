using WebPageAnalysis.DAL.Entities;

namespace WebPageAnalysis.DAL.Repository
{
    public interface IWordCountRepository
    {
        Task UpdateAsync(string word, int count, CancellationToken cancellationToken = default);
        Task<IEnumerable<WordCount>> GetAsync(CancellationToken cancellationToken = default);
    }
}