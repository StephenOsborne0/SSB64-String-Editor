using System;
using System.IO;

namespace SSB64_String_Editor
{
    public static class BinaryReaderExtensions
    {
        public static uint ReadUInt32LittleEndian(this BinaryReader br)
        {
            var value = br.ReadUInt32();
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
