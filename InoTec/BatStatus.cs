using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InoTec
{
    public class BatInfo
    {
        public int N { get; set; }
        public int BC { get; set; }
        public int BQ { get; set; }
        public int SQ { get; set; }

        public int L { get; set; }
        public string V { get; set; }
        public string S { get; set; }
    }
    public class Bat_U
    {
        [JsonPropertyName("1")]
        public int O { get; set; }

        [JsonPropertyName("2")]
        public int T { get; set; }
    }
    public class Bat_T : Bat_U
    {
        public int C1 { get; set; }
        public int C2 { get; set; }
    }
    public class Bat_F
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int V { get; set; }
        public int N { get; set; }
        public int E { get; set; }
        public int T { get; set; }
        public int S { get; set; }
        public int U { get; set; }
        public int O { get; set; }
        public List<int> D { get; set; }
    }
    public class BatStatus
    {
        public long N { get; set; }
        public Bat_U U { get; set; }
        public int I { get; set; }
        public int C { get; set; }
        public Bat_T T { get; set; }
        public Bat_U S { get; set; }
        public Bat_F F { get; set; }
    }
}
