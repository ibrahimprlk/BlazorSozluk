using BlozorSozluk.Common.ViewModels.RequestModels;

namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{

    public interface IIdentityService
    {
        bool IsLoggedIn { get; }

        Guid GetUserId();
        string GetUserName();
        string GetUserToken();
        Task<bool> Login(LoginUserCommand command);
        void Logout();
    }
}