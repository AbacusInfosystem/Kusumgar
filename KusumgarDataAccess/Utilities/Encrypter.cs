using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
namespace KusumgarDataAccess
{
    public class Encrypter
    {
        private static readonly ICryptoTransform _encrypter;

        private static readonly ICryptoTransform _decrypter;

        private static string _prefix;

        /// <summary>
        /// Initializes a new instance of the PKEncrypter class.
        /// </summary>
        /// <remarks></remarks>
        static Encrypter()
        {
            //encryption key for encryption
            var key = ConfigurationManager.AppSettings["EncryptionKey"];

            //UseHashingForEncryption value should be true or false
            var useHashingString = ConfigurationManager.AppSettings["UseHashingForEncryption"];

            bool useHashing = true;

            //check if hashing is true,it is set as true by default
            if (string.Compare(useHashingString, "false", true) == 0)
            {
                useHashing = false;
            }

            byte[] keyArray = null;

            //if hashing is true,then compute hash,otherwise don't compute
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();

                //compute MD5 hash
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            //use Triple DES algorithm for encryption
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = keyArray;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;

            //initialize encrypter
            _encrypter = tripleDES.CreateEncryptor();

            //initialize decrypter
            _decrypter = tripleDES.CreateDecryptor();

            tripleDES.Clear();
        }

        #region IEncryptionSettingsProvider Members

        /// <summary>
        /// Encrypts the specified value.
        /// </summary>
        /// <param name="value">The value to encrypt.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Encrypt(string value)
        {
            
            var bytes = UTF8Encoding.UTF8.GetBytes(value);
            var encryptedBytes = _encrypter.TransformFinalBlock(bytes, 0, bytes.Length);
            var encrypted = Convert.ToBase64String(encryptedBytes);
            return encrypted;

        }

        /// <summary>
        /// Decrypts the specified value.
        /// </summary>
        /// <param name="value">The value to decrypt</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Decrypt(string value)
        {
            var bytes = Convert.FromBase64String(value);
            var decryptedBytes = _decrypter.TransformFinalBlock(bytes, 0, bytes.Length);
            var decrypted = UTF8Encoding.UTF8.GetString(decryptedBytes);
            return decrypted;          
        }
        
        #endregion
    }
}
