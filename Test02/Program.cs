using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataCore.Models;
using org.mariuszgromada.math.mxparser;

namespace Test02
{
    class Program
    {
        static void Main(string[] args)
        {

            var listday = new List<int>()
            {
                 2,3,4,5,6,7,8
            };
            var listday2 = new List<int>()
            {
                2,5,7,8
            };
            var dayFilter = 0;
            foreach (var item in listday2)
            {
                Console.WriteLine(item);
                dayFilter += (int)Math.Pow(2, item);
                Console.WriteLine(dayFilter);
            }
            Console.WriteLine("------------------------");
            foreach (DaysOfWeekEnum item in (DaysOfWeekEnum[])Enum.GetValues(typeof(DaysOfWeekEnum)))
            {
                var day = (int)item;
                Console.WriteLine(item);
                Console.WriteLine(day);
            }
            Console.WriteLine("-------------------------");
            foreach (DaysOfWeekEnum item in (DaysOfWeekEnum[])Enum.GetValues(typeof(DaysOfWeekEnum)))
            {
                var day = (int)item;
                Console.WriteLine(item);
                var bit = (int)Math.Pow(2, day);
                var result = (dayFilter & bit) == bit;
                Console.WriteLine(result);
            }
            Console.ReadLine();
            //    List<Attribute> empData = new List<Attribute>();
            //    var value = 0.0;
            //    //var formula = "-HSTHUE * LCB";
            //    var formula = "HSCV * HSTN * 300000";
            //    var listEmployeeAttribute = new List<Attribute>()
            //    {
            //        new Attribute()
            //        {
            //            Code = "TN",
            //            Value = "2"
            //        },
            //        new Attribute()
            //        {
            //            Code = "CV",
            //            Value = "EM"
            //        },
            //        new Attribute()
            //        {
            //            Code = "LNV",
            //        },
            //        new Attribute()
            //        {
            //            Code = "NVL",
            //        },
            //        new Attribute()
            //        {
            //            Code = "NPT",
            //            Value = "1"
            //        },
            //         new Attribute()
            //        {
            //            Code = "NS",
            //            Value = "28"
            //        },
            //          new Attribute()
            //        {
            //            Code = "TS",
            //            Value = "6"
            //        },
            //    };
            //    var listPaySlipAttribute = new List<Attribute>()
            //    {
            //        new Attribute()
            //        {
            //            Code = "NBD",
            //            Value = "1"
            //        },
            //        new Attribute()
            //        {
            //            Code = "NKT",
            //            Value = "23"
            //        },
            //        new Attribute()
            //        {
            //            Code = "LCB",
            //            Value = "7480000"
            //        },
            //        new Attribute()
            //        {
            //            Code = "TKL",
            //            Value = "8"
            //        }
            //    };
            //    empData.AddRange(listEmployeeAttribute);
            //    empData.AddRange(listPaySlipAttribute);

            //    //var condition = "HSTHUE = IF(LCB<5000000,0.05,IF(LCB<10000000,0.1,IF(LCB<18000000,0.15,0.2)))";
            //    var condition = "HSCV=IF (CV==BM,2, IF (CV==SM,1.5, IF(CV=EM,1,0)));HSTN=IF (TN<5,0, IF (TN<10,1,2))";
            //    var singleConditionArray = condition.Split(';');
            //    List<ReturnData> listReturnData = new List<ReturnData>();

            //    foreach (var singleCondition in singleConditionArray)
            //    {
            //        //Xét 1 điều kiện lớn
            //        var index = singleCondition.IndexOf('=');
            //        var key = singleCondition.Substring(0, index);
            //        var keyCondition = singleCondition.Substring(index + 1);
            //        var returnData = new ReturnData
            //        {
            //            Key = key,
            //            KeyCondition = keyCondition,
            //            Value = 0
            //        };
            //        listReturnData.Add(returnData);
            //    }

            //    foreach (var returnData in listReturnData)
            //    {
            //        returnData.Value = processingSingleCondtion(returnData.KeyCondition, empData);
            //    }
            //    foreach (var data in listReturnData)
            //    {
            //        formula = formula.Replace(data.Key, data.Value.ToString());
            //    }
            //    foreach (var item in empData)
            //    {
            //        if (item.Code.Equals("LCB"))
            //        {
            //            //formula = formula.Replace(',', '.');
            //            formula = formula.Replace("LCB", item.Value);
            //        }
            //    }
            //    Expression a = new Expression(formula);
            //    if (!double.IsNaN(a.calculate()))
            //    {
            //        value = a.calculate();
            //    }
            //}
            //public static float processingSingleCondtion(String conditionArray, List<Attribute> empData)
            //{
            //    string[] substrings = Regex.Split(conditionArray.Trim(), @"[^a-zA-Z0-9<>=.]+");
            //    substrings = substrings.Take(substrings.Count() - 1).ToArray();
            //    for (int i = 0; i < substrings.Count() - 1; i = i + 3)
            //    {
            //        if (descriptCondition(substrings[i + 1], empData))
            //        {
            //            //substrings[i + 2] = substrings[i + 2].Replace('.', ',');
            //            return float.Parse(substrings[i + 2]);
            //        }
            //        var conditionCount = conditionArray.Count();
            //        if (i + 6 > substrings.Count())
            //        {
            //            substrings[i + 3] = substrings[i + 3].Replace('.', ',');
            //            return float.Parse(substrings[i + 3]);
            //        }

            //    }
            //    return 0;
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
}
