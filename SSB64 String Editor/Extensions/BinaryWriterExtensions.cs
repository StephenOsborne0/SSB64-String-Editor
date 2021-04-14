using System;
using System.IO;

namespace SSB64_String_Editor
{
    public static class BinaryWriterExtensions
    {
        public static void WriteUInt32LittleEndian(this BinaryWriter bw, uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            bw.Write(BitConverter.ToUInt32(bytes, 0));
        }
    }
}
