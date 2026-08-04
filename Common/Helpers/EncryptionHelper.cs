using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Roznama.Common.Helpers
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string plainText)
        {
            string passPhrase = "SomepassPhrase_123abc";
            string saltValue = "HelloLegasis123";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 2;
            string initVector = "@1B2c3D4e5F6g7H8";
            int keySize = 256;

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // PasswordDeriveBytes replacement for .NET Core
            var password = new PasswordDeriveBytes(
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );

            byte[] keyBytes = password.GetBytes(keySize / 8);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor(keyBytes, initVectorBytes);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            string passPhrase = "SomepassPhrase_123abc";
            string saltValue = "HelloLegasis123";
            //string hashAlgorithm = "SHA1";
            int passwordIterations = 2;
            string initVector = "@1B2c3D4e5F6g7H8";
            int keySize = 256;

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            var password = new Rfc2898DeriveBytes(
                passPhrase,
                saltValueBytes,
                passwordIterations,
                HashAlgorithmName.SHA1
            );

            byte[] keyBytes = password.GetBytes(keySize / 8);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor(keyBytes, initVectorBytes);
            using var memoryStream = new MemoryStream(cipherTextBytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public static string ConvertToJSon(DataTable dtResult)
        {
            var rows = new List<Dictionary<string, object>>();

            foreach (DataRow dr in dtResult.Rows)
            {
                var row = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    row[col.ColumnName] = dr[col];
                }
                rows.Add(row);
            }

            return System.Text.Json.JsonSerializer.Serialize(rows);
        }
    }
}