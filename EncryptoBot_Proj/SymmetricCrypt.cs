using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Security.Cryptography;

namespace EncryptoBot_Proj
{
    class SymmetricCrypt
    {
        //32 char key
        private static string key = "pqowieurytlkajshdfgmznxbcv123456";
        //16 char four
        private static string IV = "laksjdhfgmznxbcv";

        private static string ReOrderString(string _password, string _key)
        {
            string jumbledWord = "";
            char letter;
            int index;
            int seed = 0;

            //Using the user password info to shuffle my key
            for (int i = 0; i < _password.Length; i++)
            {
                seed += Convert.ToInt32(_password[i]);
            }
            Random seededRand = new Random(seed);
            int rand = seededRand.Next();

            //Handeling the shuffle of the key
            for (int i = 0; i < _key.Length; i++)
            {
                index = rand % _key.Length;
                rand = seededRand.Next();
                letter = _key[index];
                //jumbledWord.Insert(i, letter.ToString());
                jumbledWord += letter;
                _key.Remove(index);
            }
            return jumbledWord;
        }


        public static string Encrypt(string _txt, string _key)
        {
            byte[] originalTxtBytes = ASCIIEncoding.ASCII.GetBytes(_txt);

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

            aes.BlockSize = 128;
            aes.KeySize = 256;
            string newKey = ReOrderString(_key, key);
            aes.Key = ASCIIEncoding.ASCII.GetBytes(newKey);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(originalTxtBytes, 0, originalTxtBytes.Length);

            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string _encryptedTxt,string _key, Context c)
        {
            byte[] result;
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(_encryptedTxt);


                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                ICryptoTransform crypto;

                //if (aes.Key!=null)
                
                    string newKey = ReOrderString(_key, key);
                    byte[] keyByteArr = ASCIIEncoding.ASCII.GetBytes(newKey);
                    crypto = aes.CreateDecryptor(keyByteArr, aes.IV);
                
                /*
                else
                {
                    crypto = aes.CreateDecryptor(aes.Key, aes.IV);
                }
                */

                result = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                crypto.Dispose();
            }

            catch (FormatException)
            {
                result = null;
                Toast.MakeText(c, "Invalid Encrypted Text", ToastLength.Short).Show();
                //throw;
            }
            return ASCIIEncoding.ASCII.GetString(result);
        }
    }
}