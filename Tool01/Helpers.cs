using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tool01
{
    public class Helpers
    {
        public static float processingSingleCondtion(String conditionArray, List<Attribute> empData)
        {
            string[] substrings = Regex.Split(conditionArray.Trim(), @"[^a-zA-Z0-9<>=.]+");
            substrings = substrings.Take(substrings.Count() - 1).ToArray();
            for (int i = 0; i < substrings.Count() - 1; i = i + 3)
            {
                if (descriptCondition(substrings[i + 1], empData))
                {
                    //substrings[i + 2] = substrings[i + 2].Replace('.', ',');
                    return float.Parse(substrings[i + 2]);
                }
                var conditionCount = conditionArray.Count();
                if (i + 6 > substrings.Count())
                {
                    //substrings[i + 3] = substrings[i + 3].Replace('.', ',');
                    return float.Parse(substrings[i + 3]);
                }

            }
            return 0;
        }
        public static Boolean descriptCondition(String conditionArray, List<Attribute> empData)
        {
            var condition = Regex.Split(conditionArray, @"[a-zA-Z0-9]+");
            var keyAndValue = Regex.Split(conditionArray, @"[^a-zA-Z0-9]+");
            var empAttributeSelected = empData.Where(e => e.Code.Equals(keyAndValue[0]));
            float test = 0;

            if (empAttributeSelected != null)
            {
                var attribute = empAttributeSelected.FirstOrDefault();
                if (attribute != null)
                {
                    switch (condition[1])
                    {
                        case ">":
                            if (!float.TryParse(keyAndValue[1], out test))
                            {
                                keyAndValue[1] = empData.Where(e => e.Code.Equals(keyAndValue[1])).FirstOrDefault().Value;
                            }
                            return float.Parse(attribute.Value) > float.Parse(keyAndValue[1]);
                        case ">=":
                            if (!float.TryParse(keyAndValue[1], out test))
                            {
                                keyAndValue[1] = empData.Where(e => e.Code.Equals(keyAndValue[1])).FirstOrDefault().Value;
                            }
                            return float.Parse(attribute.Value) >= float.Parse(keyAndValue[1]);
                        case "<":
                            if (!float.TryParse(keyAndValue[1], out test))
                            {
                                keyAndValue[1] = empData.Where(e => e.Code.Equals(keyAndValue[1])).FirstOrDefault().Value;
                            }
                            return float.Parse(attribute.Value) < float.Parse(keyAndValue[1]);
                        case "<=":
                            if (!float.TryParse(keyAndValue[1], out test))
                            {
                                keyAndValue[1] = empData.Where(e => e.Code.Equals(keyAndValue[1])).FirstOrDefault().Value;
                            }
                            return float.Parse(attribute.Value) <= float.Parse(keyAndValue[1]);
                        case "==":
                            if (!float.TryParse(attribute.Value, out test))
                                return attribute.Value.Equals(keyAndValue[1]);
                            else
                                if (!float.TryParse(keyAndValue[1], out test))
                            {
                                keyAndValue[1] = empData.Where(e => e.Code.Equals(keyAndValue[1])).FirstOrDefault().Value;
                            }
                            return float.Parse(attribute.Value) == float.Parse(keyAndValue[1]);
                    }
                }
                else return false;
            }
            return true;
        }
    }
   

    public class Attribute
    {
        public string Code { get; set; }
        public String Value { get; set; }
    }
    public class ReturnData
    {
        public string Key { get; set; }
        public string KeyCondition { get; set; }
        public float Value { get; set; }
    }
}
