using GPICardCore.ErrorCode;
using System.Runtime.InteropServices;
using System.Xml;

namespace GPICardCore
{
    public static class DLLImport
    {
        private const string  dllPath = @"C:\EEHC\GPI_DataProcessing.dll";

        static DLLImport()
        {
            if (!File.Exists(dllPath))
            {
                throw new FileNotFoundException($"The specified DLL was not found: [{dllPath}]");
            }
        }

        [DllImport(dllPath, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "decryptData")]
        private extern static string DecryptInternal(this string encryptedCardData);

        [DllImport(dllPath, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "encryptData")]
        private extern static string EncryptInternal(this string xmlBusinessMessage);


        public static string Decrypt(this string encryptedCardData) {

            try
            {
                if (string.IsNullOrEmpty(encryptedCardData))
                {
                    throw new ArgumentException("The Decrypted Data cannot be null or empty.", nameof(encryptedCardData));
                }

                return DecryptInternal(encryptedCardData);
            }
            catch (Exception ex)
            {

                throw new Exception("Decrypt Data Error .");
            }
        }

        public static string Encrypt(this string xmlBusinessMessage)
        {
            if (string.IsNullOrEmpty(xmlBusinessMessage))
            {
                throw new ArgumentException("The XML cannot be null or empty.", nameof(xmlBusinessMessage));
            }

            // Check if the string is valid XML
            if (!IsValidXml(xmlBusinessMessage))
            {
                throw new ArgumentException("The XML is not valid .", nameof(xmlBusinessMessage));
            }

            string result =  EncryptInternal(xmlBusinessMessage);
           
           
             if (result.StartsWith("ERROR:"))
             {
                int errorCode = result.Split(':')[1].Trim().ToInt();
                DriverException.ThrowException(errorCode);
                return result;
             }
             else
             {
                return result;
             }
        }
        private static bool IsValidXml(string xmlString)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }

    }
}
