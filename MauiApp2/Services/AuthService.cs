namespace MauiApp2.Services
{
    public class AuthService
    {
        public bool IsLoggedIn { get; private set; }
        public int? UserId { get; private set; }

        public void Login(int userId)
        {
            IsLoggedIn = true;
            UserId = userId;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            UserId = null;
        }
    }
}

