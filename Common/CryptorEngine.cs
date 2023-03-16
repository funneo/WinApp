using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace Common
{
    public class CryptorEngine
    {
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        /// 
        const string key = "11099@cFcc";
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
           
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return System.Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = System.Convert.FromBase64String(cipherString);
           
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                        
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static bool CheckDecrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = System.Convert.FromBase64String(cipherString);              
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static string PasswordEncrypt(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(inputBytes);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static bool VerifyPassword(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = PasswordEncrypt(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        /// <summary>
        /// Converts an input string to the equivilant string, that need to be produced using the 'Code 128' font.
        /// </summary>
        /// <param name="value">String to be encoded</param>
        /// <returns>Encoded string start/stop and checksum characters included</returns>
        public static string StringToBarcode(string value)
        {
            // Parameters : a string
            // Return     : a string which give the bar code when it is dispayed with CODE128.TTF font
            //           : an empty string if the supplied parameter is no good
            int charPos, minCharPos;
            int currentChar, checksum;
            bool isTableB = true, isValid = true;
            string returnValue = string.Empty;

            if (value.Length > 0)
            {

                // Check for valid characters
                for (int charCount = 0; charCount < value.Length; charCount++)
                {
                    //currentChar = char.GetNumericValue(value, charPos);
                    currentChar = (int)char.Parse(value.Substring(charCount, 1));
                    if (!(currentChar >= 32 && currentChar <= 126))
                    {
                        isValid = false;
                        break;
                    }
                }

                // Barcode is full of ascii characters, we can now process it
                if (isValid)
                {
                    charPos = 0;
                    while (charPos < value.Length)
                    {
                        if (isTableB)
                        {
                            // See if interesting to switch to table C
                            // yes for 4 digits at start or end, else if 6 digits
                            if (charPos == 0 || charPos + 4 == value.Length)
                                minCharPos = 4;
                            else
                                minCharPos = 6;


                            minCharPos = IsNumber(value, charPos, minCharPos);

                            if (minCharPos < 0)
                            {
                                // Choice table C
                                if (charPos == 0)
                                {
                                    // Starting with table C
                                    returnValue = ((char)205).ToString(); // char.ConvertFromUtf32(205);
                                }
                                else
                                {
                                    // Switch to table C
                                    returnValue = returnValue + ((char)199).ToString();
                                }
                                isTableB = false;
                            }
                            else
                            {
                                if (charPos == 0)
                                {
                                    // Starting with table B
                                    returnValue = ((char)204).ToString(); // char.ConvertFromUtf32(204);
                                }

                            }
                        }

                        if (!isTableB)
                        {
                            // We are on table C, try to process 2 digits
                            minCharPos = 2;
                            minCharPos = IsNumber(value, charPos, minCharPos);
                            if (minCharPos < 0) // OK for 2 digits, process it
                            {
                                currentChar = int.Parse(value.Substring(charPos, 2));
                                currentChar = currentChar < 95 ? currentChar + 32 : currentChar + 100;
                                returnValue = returnValue + ((char)currentChar).ToString();
                                charPos += 2;
                            }
                            else
                            {
                                // We haven't 2 digits, switch to table B
                                returnValue = returnValue + ((char)200).ToString();
                                isTableB = true;
                            }
                        }
                        if (isTableB)
                        {
                            // Process 1 digit with table B
                            returnValue = returnValue + value.Substring(charPos, 1);
                            charPos++;
                        }
                    }

                    // Calculation of the checksum
                    checksum = 0;
                    for (int loop = 0; loop < returnValue.Length; loop++)
                    {
                        currentChar = (int)char.Parse(returnValue.Substring(loop, 1));
                        currentChar = currentChar < 127 ? currentChar - 32 : currentChar - 100;
                        if (loop == 0)
                            checksum = currentChar;
                        else
                            checksum = (checksum + (loop * currentChar)) % 103;
                    }

                    // Calculation of the checksum ASCII code
                    checksum = checksum < 95 ? checksum + 32 : checksum + 100;
                    // Add the checksum and the STOP
                    returnValue = returnValue +
                        ((char)checksum).ToString() +
                        ((char)206).ToString();
                }
            }

            return returnValue;
        }


        private static int IsNumber(string InputValue, int CharPos, int MinCharPos)
        {
            // if the MinCharPos characters from CharPos are numeric, then MinCharPos = -1
            MinCharPos--;
            if (CharPos + MinCharPos < InputValue.Length)
            {
                while (MinCharPos >= 0)
                {
                    if ((int)char.Parse(InputValue.Substring(CharPos + MinCharPos, 1)) < 48
                        || (int)char.Parse(InputValue.Substring(CharPos + MinCharPos, 1)) > 57)
                    {
                        break;
                    }
                    MinCharPos--;
                }
            }
            return MinCharPos;
        }
    }
}
