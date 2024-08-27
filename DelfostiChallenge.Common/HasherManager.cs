using System.Security.Cryptography;
using System.Text;

namespace DelfostiChallenge.Common
{
    public static class HasherManager
    {
        public static async Task<string> HashAsync(string text)
        {
            try
            {
                using (var sha512 = SHA512.Create())
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(text);
                    var stream = new MemoryStream(byteArray);
                    byte[] hashValue = await sha512.ComputeHashAsync(stream);
                    return Convert.ToHexString(hashValue);
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
