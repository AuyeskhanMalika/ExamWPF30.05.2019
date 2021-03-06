﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Exam30._05._2019WPF
{
    public class MicroSecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }
}
