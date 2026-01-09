using AutoMapper;
using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Common;
using BlozorSozluk.Common.Events.User;
using BlozorSozluk.Common.Infrastructure;
using BlozorSozluk.Common.Infrastructure.Exceptions;
using BlozorSozluk.Common.ViewModels.RequestModels;
using MediatR;

namespace BlozorSozluk.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Update edilecek kullanicinin sistemde var olup olmadigina bakacagiz
            var dbUser = await _userRepository.GetByIdAsync(request.Id);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var dbEmailAddress = dbUser.EmailAddress;
            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0; // Eger user'in veritabanindaki email'i ile gelen request'teki email birbirine esit degilse CompareOrdinal ile 0'dan farkli olacaktir. Bu sebeple emailin degistirildigini anlariz

            _mapper.Map(request, dbUser); // request icindekileri dbUser!a atayarap mapleme islemi gerceklestirilecek

            var rows = await _userRepository.UpdateAsync(dbUser);

            // Check if email changed (Email'i degistirmisse email confirmation islemi bastan yapilacak)

            if (rows > 0 && emailChanged) // rows degiskeni kayit edilip edilmedigi bilgisini int olarak tutar ve eger 0'dan buyuksa kayit edilmistir anlaminda. Ve emailChanged degiskeni true donuyorsa yani email degistirilmisse
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                                    exchangeType: SozlukConstants.DefaultExchangeType,
                                                    queueName: SozlukConstants.UserEmailChangedQueueName,
                                                    obj: @event);

                dbUser.EmailConfirmed = false; // Email degistirildigi icin yeniden onaylamasi gerekeceginden EmailConfirmed bilgisi false olarak degistiriliyor.
                await _userRepository.UpdateAsync(dbUser);

            }

            return dbUser.Id;
        }
    }
}
