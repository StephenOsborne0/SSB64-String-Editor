using System.Linq;
using System.Text;

namespace SSB64_String_Editor
{
    public static class SSB64StringExtensions
    {
        public static string ToSSB64String(this string text, TextSize size)
        {
            var sb = new StringBuilder();

            foreach (var c in text)
            {
                SSB64Char ssb64Char;

                switch (size)
                {
                    case TextSize.Small:
                        {
                            ssb64Char = CharSet.SSB64CharSet.SingleOrDefault(x => c.ToString() == x.CharacterLarge);

                            if (ssb64Char != null)
                                sb.Append(ssb64Char.CharacterSmall);

                            break;
                        }

                    case TextSize.Large:
                        {
                            ssb64Char = CharSet.SSB64CharSet.SingleOrDefault(x => c.ToString() == x.CharacterSmall);

                            if (ssb64Char != null)
                                sb.Append(ssb64Char.CharacterLarge);

                            break;
                        }
                }
            }

            return sb.ToString();
        }
    }
}
