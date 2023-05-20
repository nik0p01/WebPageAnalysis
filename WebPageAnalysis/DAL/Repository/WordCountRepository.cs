using Microsoft.EntityFrameworkCore;
using WebPageAnalysis.DAL.Entities;

namespace WebPageAnalysis.DAL.Repository
{
    public class WordCountRepository : IWordCountRepository
    {
        private readonly Context _context;
        public WordCountRepository(Context context)
        {
            _context = context;
        }

        public async Task UpdateAsync(string word, int count, CancellationToken cancellationToken = default)
        {
            var wordCount = _context.WordCounts.Where(w => w.Word == word);
            if (await wordCount.AnyAsync(cancellationToken))
            {
                (await wordCount.FirstAsync(cancellationToken)).Count = count;
            }
            else
            {
                await _context.WordCounts.AddAsync(new WordCount() { Count = count, Word = word });
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<WordCount>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.WordCounts.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
