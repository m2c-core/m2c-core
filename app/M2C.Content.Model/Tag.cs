using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Content.Model
{
    public class Tag
    {

        public string Key { get; set; }
        public object Value { get; set; }
        [JsonIgnore]
        public string DataType
        {
            get { return Value.GetType().Name.ToLower(); }
        }

        public override string ToString()
        {
            return (Value == null) ? Key : $"{Key};{DataType};{Value.ToString()}";
        }
        public string ToDisplay()
        {
            return (Value == null) ? Key : $"{Key}={Value}";
        }

        public static Tag Parse(string input)
        {
            Tag t = new Tag();
            if (input.Contains(";"))
            {
                string[] arr = input.Split(new char[] { ';' });
                if (arr.Length.Equals(3))
                {
                    t.Key = arr[0];
                    if (parsers.ContainsKey(arr[1]))
                    {
                        parsers[arr[1]](arr[2], t);
                    }
                    else
                    {
                        t.Value = arr[2];
                    }

                }
            }
            else
            {
                t.Key = input;
            }

            return t;
        }

        private static IDictionary<string, Action<string, Tag>> parsers = new Dictionary<string, Action<string, Tag>>(StringComparer.OrdinalIgnoreCase)
        {
            { typeof(System.String).Name.ToLower(),SetString },
            { typeof(System.Int16).Name.ToLower(),SetInt16 },
            { typeof(System.Int32).Name.ToLower(),SetInt32 },
            { typeof(System.Int64).Name.ToLower(),SetInt64 },
            { typeof(System.Double).Name.ToLower(),SetDouble },
            { typeof(System.Decimal).Name.ToLower(),SetDecimal },
            { typeof(System.DateTime).Name.ToLower(),SetDateTime },
        };

        private static void SetString(string input, Tag model)
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                model.Value = input;
            }
        }
        private static void SetInt16(string input, Tag model)
        {
            Int16 i;
            if (Int16.TryParse(input, out i))
            {
                model.Value = i;
            }
        }
        private static void SetInt32(string input, Tag model)
        {
            Int32 i;
            if (Int32.TryParse(input, out i))
            {
                model.Value = i;
            }
        }

        private static void SetInt64(string input, Tag model)
        {
            Int64 i;
            if (Int64.TryParse(input, out i))
            {
                model.Value = i;
            }
        }
        private static void SetDouble(string input, Tag model)
        {
            double d;
            if (Double.TryParse(input, out d))
            {
                model.Value = d;
            }
        }
        private static void SetDecimal(string input, Tag model)
        {
            decimal n;
            if (Decimal.TryParse(input, out n))
            {
                model.Value = n;
            }
        }
        private static void SetDateTime(string input, Tag model)
        {
            DateTime d;
            if (DateTime.TryParse(input, out d))
            {
                model.Value = d;
            }
        }



    }
}
