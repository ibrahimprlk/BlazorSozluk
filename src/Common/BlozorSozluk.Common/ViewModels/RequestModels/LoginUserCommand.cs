using BlozorSozluk.Common.ViewModels.Queries;
using MediatR;

namespace BlozorSozluk.Common.ViewModels.RequestModels
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public LoginUserCommand()
        {

        }
        public LoginUserCommand(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }
       
        public string EmailAddress { get; set; } // Sadece iceriden set edilsinler
        public string Password { get; set; }


    }
}
