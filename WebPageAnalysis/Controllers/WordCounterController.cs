using Microsoft.AspNetCore.Mvc;
using WebPageAnalysis.DAL.Repository;
using WebPageAnalysis.Services;

namespace WebPageAnalysis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCounterController : ControllerBase
    {
        private readonly ILogger<WordCounterController> _logger;
        private readonly IWordCountRepository _wordCountRepository;
        private readonly IWebPageWorker _worker;

        public WordCounterController(IWordCountRepository wordCountRepository, ILogger<WordCounterController> logger, IWebPageWorker worker)
        {
            _wordCountRepository = wordCountRepository;
            _logger = logger;
            _worker = worker;
        }

        [HttpGet]
        public async Task<IDictionary<string, int>> GetAsync(CancellationToken cancellationToken)
        {

            var word = ".jpg";
            string[] urls = { @"https://regnum.ru/foreign/balkans/serbia/belgrad", @"https://regnum.ru/foreign/balkans/serbia/belgrad", @"https://regnum.ru/foreign/balkans/serbia/belgrad" };
            var count = await _worker.CouuntWordAsync(urls, word, cancellationToken);
            await _wordCountRepository.UpdateAsync(word, count, cancellationToken);
            return (await _wordCountRepository.GetAsync(cancellationToken)).ToDictionary(keySelector: w => w.Word, elementSelector: w => w.Count);
        }
    }
}