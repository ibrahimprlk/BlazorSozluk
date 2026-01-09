using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Common.Events.User;
using BlozorSozluk.Common.Infrastructure;
using BlozorSozluk.Common.Infrastructure.Exceptions;
using MediatR;

namespace BlozorSozluk.Api.Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var encPass = PasswordEncryptor.Encrpt(request.OldPassword); // Girilen eski sifreyi hashledikten sonra db'deki sifre ile karsilastiracagiz
            if (dbUser.Password != encPass) // Girdigi eski sifre veritabaninda kayitli olan sifresi ile eslesiyor mu?
                throw new DatabaseValidationException("Old password wrong!");

            dbUser.Password = encPass;

            await userRepository.UpdateAsync(dbUser);

            return true;


        }
    }
}
