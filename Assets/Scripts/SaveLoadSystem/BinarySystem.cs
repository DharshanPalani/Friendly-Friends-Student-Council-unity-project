using System;
using System.Linq;
using System.Text;

namespace SaveLoad {
    public static class BinarySystem
    {
        public static string StringToBinary(string str, Encoding encoding)
        {
            return ToBinary(ConvertToByteArray(str, encoding));
        }

        public static string BinaryToString(string binaryStr, Encoding encoding)
        {
            return ToDecodedString(binaryStr, encoding);
        }

        private static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        private static string ToBinary(byte[] data)
        {
            return string.Join(" ", data.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        }

        private static string ToDecodedString(string binaryStr, Encoding encoding)
        {
            string[] binaryValues = binaryStr.Split(' ');
            byte[] bytes = binaryValues.Select(b => Convert.ToByte(b, 2)).ToArray();
            return encoding.GetString(bytes);
        }
    }
}
