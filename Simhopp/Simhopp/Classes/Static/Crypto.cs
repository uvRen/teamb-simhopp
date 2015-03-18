using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Simhopp
{
    /// <summary>
    /// Kryptering av nätverkstrafik
    /// Mest för att fungera i skolan så nätverket blockerade vissa json-formaterade paket utan någon tydlig konsistens
    /// </summary>
    public class Crypto
    {
        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static string Encrypt(string text)
        {
            Console.WriteLine("Encrypt: " + text);
            try
            {
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
                byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Convert.ToBase64String(outputBuffer);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return "";
        }

        public static string Decrypt(string text)
        {
            try
            {
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
                byte[] inputbuffer = Convert.FromBase64String(text);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);


                Console.WriteLine("Decrypt: " + Encoding.Unicode.GetString(outputBuffer));

                return Encoding.Unicode.GetString(outputBuffer);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            return "";
        }

    }
}
