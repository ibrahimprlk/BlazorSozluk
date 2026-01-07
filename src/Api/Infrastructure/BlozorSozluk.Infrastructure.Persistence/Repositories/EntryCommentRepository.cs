using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;

namespace BlozorSozluk.Infrastructure.Persistence.Repositories
{
    public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(BlazorSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
