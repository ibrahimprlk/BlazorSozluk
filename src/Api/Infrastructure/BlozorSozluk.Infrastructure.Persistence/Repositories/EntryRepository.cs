using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;

namespace BlozorSozluk.Infrastructure.Persistence.Repositories
{
    public class EntryRepository : GenericRepository<Entry>, IEntryRepository
    {
        public EntryRepository(BlazorSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
