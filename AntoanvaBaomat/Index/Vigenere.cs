using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Index
{
    class Vigenere
    {
        public static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Encrypt(string s, string key)
        {
            s = s.ToUpper();
            key = key.ToUpper();
            int j = 0;
            StringBuilder ret = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (alphabet.Contains(s[i]))
                    ret.Append(alphabet[(alphabet.IndexOf(s[i]) + alphabet.IndexOf(key[j])) % alphabet.Length]);
                else
                    ret.Append(s[i]);
                j = (j + 1) % key.Length;
            }
            return ret.ToString();
        }
        public static string Decrypt(string s, string key)
        {
            s = s.ToUpper();
            key = key.ToUpper();
            int j = 0;
            StringBuilder ret = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (alphabet.Contains(s[i]))
                    ret.Append(alphabet[(alphabet.IndexOf(s[i]) - alphabet.IndexOf(key[j]) + alphabet.Length) % alphabet.Length]);
                else
                    ret.Append(s[i]);
                j = (j + 1) % key.Length;
            }
            return ret.ToString();
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------

        //public static string Encrypt(string PlainText, string key) {
        //    string cipher = "";
        //    Regex alpha = new Regex("[A-Z]", RegexOptions.IgnoreCase);
        //    int index=0;
        //    foreach (char c in PlainText)
        //    {
        //        if (alpha.IsMatch(c.ToString()))
        //        {
        //            bool upperCase = Char.IsUpper(c);
        //            char cLower = Char.ToLower(c);
        //            int keyShift = ((int)key[index]) - 97;
        //            int newChar = (int)cLower + keyShift;
        //            if (newChar > 122)
        //                newChar -= 26;
        //            if (upperCase)
        //                newChar -= 32;
        //            cipher += ((char)newChar).ToString();
        //            index = (index + 1) % key.Length;
        //        }
        //        else {
        //            cipher += c.ToString();
        //        }
               
        //    }
        //    return cipher;
        //}
        //public static string Decrypt(string Cipher, string key)
        //{
        //    string plain = "";
        //    Regex alpha = new Regex("[A-Z]", RegexOptions.IgnoreCase);
        //    int index = 0;
        //    foreach (char c in Cipher)
        //    {
        //        if (alpha.IsMatch(c.ToString()))
        //        {
        //            bool upperCase = Char.IsUpper(c);
        //            char cLower = Char.ToLower(c);
        //            int keyShift = ((int)key[index]) - 97;
        //            int newChar = (int)cLower - keyShift;
        //            if (newChar < 97)
        //                newChar += 26;
        //            if (upperCase)
        //                newChar -= 32;
        //            plain += ((char)newChar).ToString();
        //            index = (index + 1) % key.Length;
        //        }
        //        else
        //        {
        //            plain += c.ToString();
        //        }

        //    }
        //    return plain;
        }


    }

