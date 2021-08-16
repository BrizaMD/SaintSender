namespace SaintSender.Core.Services
{
    using SaintSender.Core.Interfaces;
    using System.Text.RegularExpressions;

    class Validation : Login
    {
        private const string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private const string PasswordRequirements = @"^[A - Za - z0 - 9_ -] * $";
        private const int MinimumLengthOfPassword = 12;

        public bool ValidateEmail(string email)
        {
            return !Regex.IsMatch(email, EmailPattern) || string.IsNullOrEmpty(email);
        }

        public bool ValidatePassword(string password)
        {
            return password.Length >= MinimumLengthOfPassword || !Regex.IsMatch(password, PasswordRequirements);
        }
    }
}
