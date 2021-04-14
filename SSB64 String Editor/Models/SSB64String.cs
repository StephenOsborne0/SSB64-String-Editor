using Newtonsoft.Json;
using System.ComponentModel;

namespace SSB64_String_Editor
{
    public class SSB64String
    {
        public string Offset { get; set; }

        [Browsable(false)]
        public int Length { get; set; }

        [Browsable(false)]
        public string Text { get; set; }

        [JsonIgnore]
        public string SmallText { get; set; }

        [JsonIgnore]
        public string LargeText { get; set; }

        public TextSize Size { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public byte[] Bytes { get; set; }
    }
}
