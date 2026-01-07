using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;

namespace BlozorSozluk.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository //  IUserRepository icerisinde genericten haric baska bir metod varsa diye miraz aliyoruz.
    {
        public UserRepository(BlazorSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
