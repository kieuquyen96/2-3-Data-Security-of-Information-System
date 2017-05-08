using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
    class Playfair
    {
        public static string p = "", k = "";
        public static void KhoiTao(string banro, string khoa)
        {
            // Khởi tạo khóa
            k = khoa.ToLower();
            k = k.Replace(" ", ""); // Xóa khoảng trắng
            k = k.Replace("j", "i"); // Thay j = i vì i/j giống nhau.
            String table = "";
            foreach (char value in k) // Hàm loại bỏ các ký tự trùng nhau trong khóa
            {
                if (table.IndexOf(value) == -1)
                {
                    table += value;
                }
            }
            k = table;
            String a = "abcdefghiklmnopqrstuvwxyz";
            foreach (char s in k) // Xóa các ký tự đã tồn tại trong k
            {
                a = a.Replace(s.ToString(), string.Empty);
            }
            k += a; // Ghép k với a để thành khóa.

            // Tách bản rõ
            p = banro.ToLower();
            StringBuilder sb = new StringBuilder();
            foreach (char c in p)
            {
                if (c >= 97 && c <= 122) // Xét từ a-z
                {
                    if (sb.Length % 2 == 1 && sb[sb.Length - 1] == c)
                    {
                        sb.Append('x');
                    }
                    sb.Append(c);
                }
            }
            if (sb.Length % 2 == 1)
            {
                sb.Append('x');
            }
            p = sb.ToString();

        }


        public static String MaHoaPlayfair(String key, String plainText)
        {
            int length = plainText.Length;
            char a, b;
            int a_ind, b_ind, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2) // Mỗi lần xét theo cặp
            {
                a = plainText[i];
                b = plainText[i + 1];
                // Lấy các chỉ số dòng và cột theo khóa K
                a_ind = key.IndexOf(a);
                b_ind = key.IndexOf(b);
                a_row = a_ind / 5;
                b_row = b_ind / 5;
                a_col = a_ind % 5;
                b_col = b_ind % 5;

                if (a_row == b_row)
                {
                    if (a_col == 4)
                    {
                        sb.Append(key[a_ind - 4]);
                        sb.Append(key[b_ind + 1]);
                    }
                    else if (b_col == 4)
                    {
                        sb.Append(key[a_ind + 1]);
                        sb.Append(key[b_ind - 4]);
                    }
                    else
                    {
                        sb.Append(key[a_ind + 1]);
                        sb.Append(key[b_ind + 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 4)
                    {
                        sb.Append(key[a_ind - 20]);
                        sb.Append(key[b_ind + 5]);
                    }
                    else if (b_row == 4)
                    {
                        sb.Append(key[a_ind + 5]);
                        sb.Append(key[b_ind - 20]);
                    }
                    else
                    {
                        sb.Append(key[a_ind + 5]);
                        sb.Append(key[b_ind + 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }
        public static String GiaiMaPlayfair(String key, String cipherText)
        {
            int length = cipherText.Length;
            char a, b;
            int a_ind, b_ind, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = cipherText[i];
                b = cipherText[i + 1];

                a_ind = key.IndexOf(a);
                b_ind = key.IndexOf(b);
                a_row = a_ind / 5;
                b_row = b_ind / 5;
                a_col = a_ind % 5;
                b_col = b_ind % 5;

                if (a_row == b_row)
                {
                    if (a_col == 0)
                    {
                        sb.Append(key[a_ind + 4]);
                        sb.Append(key[b_ind - 1]);
                    }
                    else if (b_col == 0)
                    {
                        sb.Append(key[a_ind - 1]);
                        sb.Append(key[b_ind + 4]);
                    }
                    else
                    {
                        sb.Append(key[a_ind - 1]);
                        sb.Append(key[b_ind - 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 0)
                    {
                        sb.Append(key[a_ind + 20]);
                        sb.Append(key[b_ind - 5]);
                    }
                    else if (b_row == 0)
                    {
                        sb.Append(key[a_ind - 5]);
                        sb.Append(key[b_ind + 20]);
                    }
                    else
                    {
                        sb.Append(key[a_ind - 5]);
                        sb.Append(key[b_ind - 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }
        
    }
}