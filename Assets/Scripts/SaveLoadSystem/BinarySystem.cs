using System;
using System.Linq;
using System.Text;

public class BinarySystem
{
    public static string BinaryConverter(string str ,Encoding encoding) {
        return ToBinary(ConvertToByteArray(str,Encoding.ASCII));
    }

    private static byte[] ConvertToByteArray(string str, Encoding encoding) {
        return encoding.GetBytes(str);
    }

    private static String ToBinary(Byte[] data) {
        return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }
}
