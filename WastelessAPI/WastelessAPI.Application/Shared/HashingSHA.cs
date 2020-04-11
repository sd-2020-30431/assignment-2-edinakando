using System;
using System.Security.Cryptography;
using System.Text;

namespace WastelessAPI.Application.Shared
{
    public static class HashingSHA
    {
        public static String GenerateSHA256String(String inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            Byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            Byte[] hash = sha256.ComputeHash(bytes);
            sha256.Dispose();
            return GetStringFromHash(hash);
        }
        private static String GetStringFromHash(Byte[] hash)
        {
            var result = new StringBuilder();
            for (Int32 i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}