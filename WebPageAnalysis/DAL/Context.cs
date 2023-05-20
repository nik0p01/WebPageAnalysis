using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebPageAnalysis.DAL.Entities;

namespace WebPageAnalysis.DAL
{
    public class Context : DbContext
    {
        private readonly ILogger<Context> _logger;

        public Context(DbContextOptions<Context> options, ILogger<Context> logger) : base(options)
        {
            _logger = logger;

            try
            {

                Database.EnsureCreatedAsync();
            }
            catch (SqlException e)
            {
                _logger?.LogError(e, e.Message);
                throw;
            }
        }

        public DbSet<WordCount> WordCounts { get; set; }
    }

}
