namespace CivilRegistrationMobile.Services
{
    public static class Decryption
    {
        [Obsolete("Obsolete")]
        public static string Decrypt(string hash, string encryptedString)
        {
            var data = Convert.FromBase64String(encryptedString);
            using MD5CryptoServiceProvider md5 = new();
            var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
            using TripleDESCryptoServiceProvider tripleDes = new() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var transform = tripleDes.CreateDecryptor();
            var results = transform.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF8.GetString(results);
        }
    }
}
