using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Javascript权威指南
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime dt = currentTime.AddMinutes(-3);
            //Label1.Text = currentTime.ToString();
            //Label2.Text = dt.ToString();
          //  Label1.Text = TrippleDescEncryption("Y&198501315D",false);
           // Label2.Text = TrippldescDecryption(Label1.Text, false);

            string s =MessageType.Type["B"];
            Label2.Text = s;

            MD5Hash("test1234");

        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                byte t = result[i];
                string s = t.ToString("x2");
                string s1 = t.ToString("X2");
                strBuilder.Append(s);
            }

            return strBuilder.ToString();
        }
        /*
        /// <span class="code-SummaryComment"><summary></span>
        /// Encrypt a string.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="originalString">The original string.</param></span>
        /// <span class="code-SummaryComment"><returns>The encrypted string.</returns></span>
        /// <span class="code-SummaryComment"><exception cref="ArgumentNullException">This exception will be </span>
        /// thrown when the original string is null or empty.<span class="code-SummaryComment"></exception></span>
        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Decrypt a crypted string.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="cryptedString">The crypted string.</param></span>
        /// <span class="code-SummaryComment"><returns>The decrypted string.</returns></span>
        /// <span class="code-SummaryComment"><exception cref="ArgumentNullException">This exception will be thrown </span>
        /// when the crypted string is null or empty.<span class="code-SummaryComment"></exception></span>
        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        public static string TrippleDescEncryption(string toEncrypt, bool useHashing)
        {

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");
            //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray = cTransform.TransformFinalBlock
                    (toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string TrippldescDecryption(string cipherString, bool useHashing)
        {
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock
                    (toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
         * 
        }*/
    }

    public class MessageType
    {
        public static string Type_Broadcast = "Broadcast";
        public static string Type_Specific = "Specific";

        public static string Type_B = "B";
        public static string Type_S = "S";

        public static Dictionary<string, string> Type = new Dictionary<string, string>()
        {
            { Type_B,Type_Broadcast},
            { Type_S, Type_Specific}
        };

    }
}