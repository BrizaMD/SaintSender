namespace SaintSender.Core.Services
{
    using SaintSender.Core.Interfaces;
    using System;
    using System.Text.RegularExpressions;

    class Validation : Login
    {
        private const string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private const string passwordRequirements = @"^[A - Za - z0 - 9_ -] * $";
        private const int minimumLengthOfPassword = 12;

        public bool ValidateEmail(string email)
        {
            return !Regex.IsMatch(email, emailPattern) || string.IsNullOrEmpty(email);
        }

        public bool ValidatePassword(string password)
        {
            return password.Length >= minimumLengthOfPassword || !Regex.IsMatch(password, passwordRequirements);
        }
    }
}
