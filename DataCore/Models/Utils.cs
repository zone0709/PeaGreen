using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class Utils
    {
        public static JwtSecurityToken DecodeJwtToken(string token)
        {
            //var stream = "[encoded jwt]";
            var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            return tokenS;
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool Verify(string password, string savedPasswordHash)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();

            return true;
        }

        public static DateTime GetCurrentDateTime()
        {

            #region Get DateTime.Now
            //Get time UTC 
            DateTime utcNow = DateTime.UtcNow;
            //Parse UTC to time SE Asia
            DateTime datetimeNow = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            #endregion

            return datetimeNow;
        }
        public static string DisplayName(this Enum value)
        {
            try
            {
                Type enumType = value.GetType();
                var enumValue = Enum.GetName(enumType, value);
                MemberInfo member = enumType.GetMember(enumValue)[0];

                var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
                var outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                {
                    outString = ((DisplayAttribute)attrs[0]).GetName();
                }

                return outString;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static DateTime ToHourTime(this string datetime)
        {
            try
            {
                return DateTime.ParseExact(datetime, "HH:mm", CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception("Chuỗi giờ không đúng định dạng");
            }
        }
        public static DateTime GetEndOfDate(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
        }

        public static DateTime GetStartOfDate(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
        }
        public static DateTime GetStartOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1, 0, 0, 0);
        }
        public static DateTime GetEndOfMonth(this DateTime value)
        {
            DateTime firstDayOfTheMonth = new DateTime(value.Year, value.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public static float processingSingleCondtion(String conditionArray, List<Attribute> empData)
        {
            string[] substrings = Regex.Split(conditionArray.Trim(), @"[^a-zA-Z0-9<>=.]+");
            substrings = substrings.Take(substrings.Count() - 1).ToArray();
            for (int i = 0; i < substrings.Count() - 1; i = i + 3)
            {
                if (descriptCondition(substrings[i + 1], empData))
                {
                    substrings[i + 2] = substrings[i + 2].Replace('.', ',');
                    return float.Parse(substrings[i + 2]);
                }
                var conditionCount = conditionArray.Count();
                if (i + 6 > substrings.Count())
                {
                    substrings[i + 3] = substrings[i + 3].Replace('.', ',');
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
