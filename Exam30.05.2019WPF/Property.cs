using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam30._05._2019WPF
{
    public class Property
    {
        [JsonProperty("mag")]
        public double Mag { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(MicroSecondEpochConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("DepthMin")]
        public double? DepthMin { get; set; }
    }
}
