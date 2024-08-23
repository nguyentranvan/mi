using System;
using System.Security.Cryptography;
using System.Text;

namespace MI.Helpers.Lib
{
    public class PasswordHelper
    {
        private static int SaltLengthLimit = 32;
        public static string GetRandomSalt()
        {
            var provider = new PasswordGenerator(8, SaltLengthLimit);

            return provider.Generate();
        }
        public static string EncyptedPassword(string password, string salt)
        {
            return md5(string.Concat(md5(password), md5(salt)));
        }

        private static byte[] EncryptData(string data)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string md5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
        }

        public static string IsValidPassword(string password)
        {
            var messError = "";
            var hasLength = !password.Contains(" ") && password.Length >= 6;
            //Regex rxMath = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%&*]).{8,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //var hasMath = rxMath.IsMatch(password);
            //if (!hasLength || !hasMath)
            //{
            //    messError = "Mật khẩu không hợp lệ, mật khẩu không được có khoảng trắng, độ dài tối thiểu 8 ký tự, bao gồm tối thiểu có hoa, thường, số và ký tự đặc biệt $@!%*#?&";
            //}
            if (!hasLength)
            {
                messError = "Mật khẩu không hợp lệ, mật khẩu không được có khoảng trắng, độ dài tối thiểu 6 ký tự";
            }
            return messError;
        }
    }
}
