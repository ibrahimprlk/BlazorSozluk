using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;

namespace BlozorSozluk.Infrastructure.Persistence.Repositories
{
    public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(BlazorSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
