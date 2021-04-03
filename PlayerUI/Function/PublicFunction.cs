using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.Function
{
    class PublicFunction
    {
        public static string EncodePassword(string password)
        {
            if (String.IsNullOrEmpty(password))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public static int GetIdFromCombobox(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {

                return int.TryParse(value.Split('-')[0], out int re) ? int.Parse(value.Split('-')[0]) : 0;
            }

            return 0;
        }
        public static string GetNameFromCombobox(string value)
        {
            return value.Split('-')[1];
        }


        public static string TrueFalseToNamNu(bool gioitinh)
        {
            if (gioitinh)
            {
                return "Nam";
            }
            else
            {
                return "Nữ";
            }
        }

        public static bool NamNuToTrueFalse(string gioitinh)
        {
            if (gioitinh == "Nam" || gioitinh == "nam")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetStringFromImage(Image image)
        {
            if (image != null)
            {
                ImageConverter ic = new ImageConverter();
                byte[] buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
                return Convert.ToBase64String(
                    buffer,
                    Base64FormattingOptions.InsertLineBreaks);
            }
            else
                return null;
        }

        public static Image GetImageFromString(string base64String)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(base64String);

                if (buffer != null)
                {
                    ImageConverter ic = new ImageConverter();
                    return ic.ConvertFrom(buffer) as Image;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string ChuyenSo(string number)
        {
            try
            {


                string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
                string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string doc;
                int i, j, k, n, len, found, ddv, rd;

                len = number.Length;
                number += "ss";
                doc = "";
                found = 0;
                ddv = 0;
                rd = 0;

                i = 0;
                while (i < len)
                {
                    //So chu so o hang dang duyet
                    n = (len - i + 2) % 3 + 1;

                    //Kiem tra so 0
                    found = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (number[i + j] != '0')
                        {
                            found = 1;
                            break;
                        }
                    }

                    //Duyet n chu so
                    if (found == 1)
                    {
                        rd = 1;
                        for (j = 0; j < n; j++)
                        {
                            ddv = 1;
                            switch (number[i + j])
                            {
                                case '0':
                                    if (n - j == 3) doc += cs[0] + " ";
                                    if (n - j == 2)
                                    {
                                        if (number[i + j + 1] != '0') doc += "lẻ ";
                                        ddv = 0;
                                    }
                                    break;
                                case '1':
                                    if (n - j == 3) doc += cs[1] + " ";
                                    if (n - j == 2)
                                    {
                                        doc += "mười ";
                                        ddv = 0;
                                    }
                                    if (n - j == 1)
                                    {
                                        if (i + j == 0) k = 0;
                                        else k = i + j - 1;

                                        if (number[k] != '1' && number[k] != '0')
                                            doc += "mốt ";
                                        else
                                            doc += cs[1] + " ";
                                    }
                                    break;
                                case '5':
                                    if (i + j == len - 1)
                                        doc += "lăm ";
                                    else
                                        doc += cs[5] + " ";
                                    break;
                                default:
                                    doc += cs[(int)number[i + j] - 48] + " ";
                                    break;
                            }

                            //Doc don vi nho
                            if (ddv == 1)
                            {
                                doc += dv[n - j - 1] + " ";
                            }
                        }
                    }


                    //Doc don vi lon
                    if (len - i - n > 0)
                    {
                        if ((len - i - n) % 9 == 0)
                        {
                            if (rd == 1)
                                for (k = 0; k < (len - i - n) / 9; k++)
                                    doc += "tỉ ";
                            rd = 0;
                        }
                        else
                            if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                    }

                    i += n;
                }

                if (len == 1)
                    if (number[0] == '0' || number[0] == '5') return doc;

                return doc;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetDate(DateTime date)
        {
            string y, m, d;
            m = date.Month < 10 ? m = "0" + date.Month.ToString() : date.Month.ToString();

            d = date.Day < 10 ? d = "0" + date.Day.ToString() : date.Day.ToString();

            y = date.Year.ToString();
            return (y + m + d).ToString();
        }

        public static string CountDay(DateTime DateTo , DateTime DateFrom)
        {
            string count = ((DateFrom - DateTo).TotalDays).ToString("F0", CultureInfo.InvariantCulture);
            return count;
        }
    }
}
