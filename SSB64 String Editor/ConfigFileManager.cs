using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SSB64_String_Editor
{
    public partial class ConfigFileManager
    {
        private string _configFilepath { get; set; }
        private string _binaryFilepath { get; set; }
        private List<SSB64String> _ssb64Strings { get; set; }

        public ConfigFileManager(string configFilepath, string binaryFilepath)
        {
            _configFilepath = configFilepath;
            _binaryFilepath = binaryFilepath;
        }

        public void LoadConfig()
        {
            var json = File.ReadAllText(_configFilepath);
            _ssb64Strings = JsonConvert.DeserializeObject<List<SSB64String>>(json);
        }

        public List<SSB64String> ReadStringsFromBinary()
        {
            using (var br = new BinaryReader(File.OpenRead(_binaryFilepath)))
            {
                foreach (var ssb64String in _ssb64Strings)
                {
                    var offset = uint.Parse(ssb64String.Offset.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                    //Get string bytes
                    br.BaseStream.Position = offset;
                    ssb64String.Bytes = br.ReadBytes(ssb64String.Length * 4);

                    //Get char bytes
                    br.BaseStream.Position = offset;
                    var ssb64Chars = new List<SSB64Char>();

                    for (int i = 0; i < ssb64String.Length; i++)
                    {
                        var value = br.ReadUInt32LittleEndian();
                        var ssb64Char = CharSet.SSB64CharSet.Single(x => x.Value == value);
                        ssb64Chars.Add(ssb64Char);
                    }

                    ssb64String.SmallText = GetString(ssb64Chars, TextSize.Small);
                    ssb64String.LargeText = GetString(ssb64Chars, TextSize.Large);
                }
            }

            return _ssb64Strings;
        }

        public string CreateBackupBinaryFile()
        {
            var outputPath = _binaryFilepath.Replace(".z64", "-modified.z64");

            if (!File.Exists(outputPath))
                File.Copy(_binaryFilepath, outputPath);

            return outputPath;
        }

        public void WriteStringsToBinary(string outputPath)
        {
            using (var bw = new BinaryWriter(File.OpenWrite(outputPath)))
            {
                foreach (var ssb64String in _ssb64Strings)
                {
                    var offset = uint.Parse(ssb64String.Offset.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                    //Get char bytes
                    bw.BaseStream.Position = offset;
                    List<SSB64Char> ssb64Chars = null;

                    switch (ssb64String.Size)
                    {
                        case TextSize.Small:
                            {
                                ssb64Chars = GetChars(ssb64String.SmallText, TextSize.Small, ssb64String.Length);
                                break;
                            }
                        case TextSize.Large:
                            {
                                ssb64Chars = GetChars(ssb64String.LargeText, TextSize.Large, ssb64String.Length);
                                break;
                            }
                    }

                    for (int i = 0; i < ssb64Chars.Count; i++)
                        bw.WriteUInt32LittleEndian(ssb64Chars[i].Value);
                }
            }        
        }

        private List<SSB64Char> GetChars(string str, TextSize size, int maxLength) 
        {
            var ssb64Chars = new List<SSB64Char>();


            while (str.Length < maxLength)
                str += " ";

            foreach (var c in str)
            {
                SSB64Char ssb64char = null;

                switch (size)
                {
                    case TextSize.Small:
                        {
                            ssb64char = CharSet.SSB64CharSet.Single(x => x.CharacterSmall == c.ToString());
                            break;
                        }
                    case TextSize.Large:
                        {
                            ssb64char = CharSet.SSB64CharSet.Single(x => x.CharacterLarge == c.ToString());
                            break;
                        }
                }

                ssb64Chars.Add(ssb64char);
            }

            return ssb64Chars;
        }

        private string GetString(List<SSB64Char> ssb64Chars, TextSize size) =>
            string.Join(string.Empty, ssb64Chars.Select(c => size == TextSize.Small ? c.CharacterSmall : c.CharacterLarge));
    }
}
