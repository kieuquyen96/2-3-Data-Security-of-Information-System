using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
   public class Ceasar
    {
        
       public const string letters = "abcdefghijklmnopqrstuvwxyz";
       public static string Encrypt(string  PlainText, int k){
           PlainText = PlainText.ToLower();
           string cipher = "";
           for(int i = 0; i < PlainText.Length; i++){
               if (PlainText[i] == ' ')
               {
                   continue;
               }
               else
               {
                   int charpos = letters.IndexOf(PlainText[i]);
                   int keyval = (charpos + k) % 26;
                   char replaceval = letters[keyval];
                   cipher = cipher + replaceval;
               }
           }
           cipher.ToUpper();
           return cipher;

       }
       public static string Decrypt (string Cipher, int k)
       {
           Cipher = Cipher.ToLower();
           string plain = "";
           for (int i = 0; i < Cipher.Length; i++)
           {
               if (Cipher[i] == ' ')
               {
                   continue;
               }
               else
               {
                   int charpos = letters.IndexOf(Cipher[i]);
                   int keyval = (charpos - k) % 26;
                   if (keyval < 0)
                   {
                       keyval = letters.Length + keyval;
                   }
                   char replaceval = letters[keyval];
                   plain = plain + replaceval;
               }
               
           }
           return plain;

       }
    }
}
