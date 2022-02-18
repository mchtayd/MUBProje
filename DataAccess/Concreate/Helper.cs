using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess.Concreate
{

    public static class Helper
    {

        static double outValue = 0;
        static int outValue2 = 0;
        static DateTime outValue3 = new DateTime(2000, 01, 01);
        public static int ConInt(this object param)
        {
            return Convert.ToInt32(param);
        }
        public static double ConDouble(this object param)
        {
            if (!double.TryParse(param.ToString(), out outValue))
            {
                return 0;
            }
            return Convert.ToDouble(param);
        }

        public static int ConInt(this string param)
        {
            if (!int.TryParse(param.ToString(), out outValue2))
            {
                return 0;
            }
            return int.Parse(param);
        }

        public static bool ConBool(this object param)
        {

            return Convert.ToBoolean(param);
        }

        public static DateTime ConDate(this object param)
        {
            if (DateTime.TryParse(param.ToString(), out _))
            {
                return Convert.ToDateTime(param);
            }
            return DateTime.Now;
        }

        public static DateTime ConOnlyTime(this object param)
        {
            if (DateTime.TryParse(param.ToString(), out _))
            {
                //{00:15:00}
                DateTime now = DateTime.Now;
                string value = param.ToString();
                return new DateTime(now.Year, now.Month, now.Day, value.Substring(0, 2).ConInt(), value.Substring(3, 2).ConInt(), value.Substring(5, 2).ConInt());
            }
            return DateTime.Now;
        }

        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static byte[] ImageToByteArray(this Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(this byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = Image.FromStream(ms);

                return returnImage;
            }
        }

        public static string ToSafeFileName(this string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }
    }
}
