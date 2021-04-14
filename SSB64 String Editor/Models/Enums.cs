using System.Collections.Generic;

namespace SSB64_String_Editor
{
    public enum TextSize
    {
        Small,
        Large
    }

    public class CharSet
    {
        public static List<SSB64Char> SSB64CharSet = new List<SSB64Char>()
        {
            new SSB64Char { Value = 0x00, CharacterLarge = "A", CharacterSmall = "A" },
            new SSB64Char { Value = 0x01, CharacterLarge = "B", CharacterSmall = "B" },
            new SSB64Char { Value = 0x02, CharacterLarge = "C", CharacterSmall = "C" },
            new SSB64Char { Value = 0x03, CharacterLarge = "D", CharacterSmall = "D" },
            new SSB64Char { Value = 0x04, CharacterLarge = "E", CharacterSmall = "E" },
            new SSB64Char { Value = 0x05, CharacterLarge = "F", CharacterSmall = "F" },
            new SSB64Char { Value = 0x06, CharacterLarge = "G", CharacterSmall = "G" },
            new SSB64Char { Value = 0x07, CharacterLarge = "H", CharacterSmall = "H" },
            new SSB64Char { Value = 0x08, CharacterLarge = "I", CharacterSmall = "I" },
            new SSB64Char { Value = 0x09, CharacterLarge = "J", CharacterSmall = "J" },
            new SSB64Char { Value = 0x0A, CharacterLarge = "K", CharacterSmall = "K" },
            new SSB64Char { Value = 0x0B, CharacterLarge = "L", CharacterSmall = "L" },
            new SSB64Char { Value = 0x0C, CharacterLarge = "M", CharacterSmall = "M" },
            new SSB64Char { Value = 0x0D, CharacterLarge = "N", CharacterSmall = "N" },
            new SSB64Char { Value = 0x0E, CharacterLarge = "O", CharacterSmall = "O" },
            new SSB64Char { Value = 0x0F, CharacterLarge = "P", CharacterSmall = "P" },
            new SSB64Char { Value = 0x10, CharacterLarge = "Q", CharacterSmall = "Q" },
            new SSB64Char { Value = 0x11, CharacterLarge = "R", CharacterSmall = "R" },
            new SSB64Char { Value = 0x12, CharacterLarge = "S", CharacterSmall = "S" },
            new SSB64Char { Value = 0x13, CharacterLarge = "T", CharacterSmall = "T" },
            new SSB64Char { Value = 0x14, CharacterLarge = "U", CharacterSmall = "U" },
            new SSB64Char { Value = 0x15, CharacterLarge = "V", CharacterSmall = "V" },
            new SSB64Char { Value = 0x16, CharacterLarge = "W", CharacterSmall = "W" },
            new SSB64Char { Value = 0x17, CharacterLarge = "X", CharacterSmall = "X" },
            new SSB64Char { Value = 0x18, CharacterLarge = "Y", CharacterSmall = "Y" },
            new SSB64Char { Value = 0x19, CharacterLarge = "Z", CharacterSmall = "Z" },

            new SSB64Char { Value = 0x1A, CharacterLarge = "a", CharacterSmall = "a" },
            new SSB64Char { Value = 0x1B, CharacterLarge = "b", CharacterSmall = "b" },
            new SSB64Char { Value = 0x1C, CharacterLarge = "c", CharacterSmall = "c" },
            new SSB64Char { Value = 0x1D, CharacterLarge = "d", CharacterSmall = "d" },
            new SSB64Char { Value = 0x1E, CharacterLarge = "e", CharacterSmall = "e" },
            new SSB64Char { Value = 0x1F, CharacterLarge = "f", CharacterSmall = "f" },
            new SSB64Char { Value = 0x20, CharacterLarge = "g", CharacterSmall = "g" },
            new SSB64Char { Value = 0x21, CharacterLarge = "h", CharacterSmall = "h" },
            new SSB64Char { Value = 0x22, CharacterLarge = "i", CharacterSmall = "i" },
            new SSB64Char { Value = 0x23, CharacterLarge = "j", CharacterSmall = "j" },
            new SSB64Char { Value = 0x24, CharacterLarge = "k", CharacterSmall = "k" },
            new SSB64Char { Value = 0x25, CharacterLarge = "l", CharacterSmall = "l" },
            new SSB64Char { Value = 0x26, CharacterLarge = "m", CharacterSmall = "m" },
            new SSB64Char { Value = 0x27, CharacterLarge = "n", CharacterSmall = "n" },
            new SSB64Char { Value = 0x28, CharacterLarge = "o", CharacterSmall = "o" },
            new SSB64Char { Value = 0x29, CharacterLarge = "p", CharacterSmall = "p" },
            new SSB64Char { Value = 0x2A, CharacterLarge = "q", CharacterSmall = "q" },
            new SSB64Char { Value = 0x2B, CharacterLarge = "r", CharacterSmall = "r" },
            new SSB64Char { Value = 0x2C, CharacterLarge = "s", CharacterSmall = "s" },
            new SSB64Char { Value = 0x2D, CharacterLarge = "t", CharacterSmall = "t" },
            new SSB64Char { Value = 0x2E, CharacterLarge = "u", CharacterSmall = "u" },
            new SSB64Char { Value = 0x2F, CharacterLarge = "v", CharacterSmall = "v" },
            new SSB64Char { Value = 0x30, CharacterLarge = "w", CharacterSmall = "w" },
            new SSB64Char { Value = 0x31, CharacterLarge = "x", CharacterSmall = "x" },
            new SSB64Char { Value = 0x32, CharacterLarge = "y", CharacterSmall = "y" },
            new SSB64Char { Value = 0x33, CharacterLarge = "z", CharacterSmall = "z" },

            new SSB64Char { Value = 0x34, CharacterLarge = ".", CharacterSmall = ":" },
            new SSB64Char { Value = 0x35, CharacterLarge = ",", CharacterSmall = "9" },
            new SSB64Char { Value = 0x36, CharacterLarge = "'", CharacterSmall = "8" },
            new SSB64Char { Value = 0x37, CharacterLarge = "4", CharacterSmall = "7" },
            new SSB64Char { Value = 0x38, CharacterLarge = "", CharacterSmall = "6" },
            new SSB64Char { Value = 0x39, CharacterLarge = "", CharacterSmall = "5" },
            new SSB64Char { Value = 0x3A, CharacterLarge = "", CharacterSmall = "4" },
            new SSB64Char { Value = 0x3B, CharacterLarge = "", CharacterSmall = "3" },
            new SSB64Char { Value = 0x3C, CharacterLarge = "", CharacterSmall = "2" },
            new SSB64Char { Value = 0x3D, CharacterLarge = "", CharacterSmall = "1" },
            new SSB64Char { Value = 0x3E, CharacterLarge = "", CharacterSmall = "0" },
            new SSB64Char { Value = 0x3F, CharacterLarge = "", CharacterSmall = "." },
            new SSB64Char { Value = 0x40, CharacterLarge = "", CharacterSmall = "-" },
            new SSB64Char { Value = 0x41, CharacterLarge = "", CharacterSmall = "," },
            new SSB64Char { Value = 0x42, CharacterLarge = "", CharacterSmall = "&" },
            new SSB64Char { Value = 0x43, CharacterLarge = "", CharacterSmall = "\"" },
            new SSB64Char { Value = 0x44, CharacterLarge = "", CharacterSmall = "/" },
            new SSB64Char { Value = 0x45, CharacterLarge = "", CharacterSmall = "'" },
            new SSB64Char { Value = 0x46, CharacterLarge = "", CharacterSmall = "?" },
            new SSB64Char { Value = 0x47, CharacterLarge = "", CharacterSmall = "(" },
            new SSB64Char { Value = 0x48, CharacterLarge = "", CharacterSmall = ")" },
            new SSB64Char { Value = 0x49, CharacterLarge = "", CharacterSmall = "é" },
            new SSB64Char { Value = 0xFFFFFFC9, CharacterLarge = "", CharacterSmall = "\n" },
            new SSB64Char { Value = 0xFFFFFFDF, CharacterLarge = " ", CharacterSmall = " " }
        };
    }
}
