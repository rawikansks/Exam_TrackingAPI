
using Exam.Models.Models.InmemoryDataModel;
using Exam.Models.Models.InMemoryDataModel;
using Microsoft.EntityFrameworkCore;

namespace Exam.DataAccess.UseInMemoryDbContext
{
    public class MyDbContext : DbContext
    {

        public DbSet<InMemoryDataRequest> InMemoryDataRequests { get; set; }
        public DbSet<InMemoryDataTrackRequest> InMemoryDataTrackRequests { get; set; }
        public DbSet<InMemoryDataDTOResponse> InMemoryDataDTOResponses { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InMemoryDataRequest>()
                .HasKey(m => m.CId);
            modelBuilder.Entity<InMemoryDataTrackRequest>()
                .HasKey(m => m.TId);
        }


    }
}
