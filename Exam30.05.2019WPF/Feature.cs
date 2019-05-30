using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam30._05._2019WPF
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Property Properties { get; set; }
    }
}