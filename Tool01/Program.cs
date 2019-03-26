using Microsoft.Extensions.Configuration;
using DataCore;
using DataCore.Models;
using DataCore.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tool01
{
    class Program
    {
        static void Main(string[] args)
        {
            var paySlipService  = new CalculatePaySlipService();
            var count = 0;
            while (true)
            {
                Console.WriteLine("Start in " + DateTime.Now);
                var fromday = new DateTime(2019, 3, 1);
                var today = new DateTime(2019, 3, 30);
                paySlipService.RunAuto(fromday,today);
                Console.WriteLine("End in " + DateTime.Now);
                //5 phut 1 lan 
                Console.WriteLine("Update time PaySlip");
                Thread.Sleep(1000 * 5 * 1);
                count++;
                if (count > 100)
                {
                    count = 0;
                    Console.Clear();
                }
            }

        }



        #region ExamValue

        //public static List<DayType> GetListDayType()
        //{
        //    var result = new List<DayType>();
        //    var dayexam = new DayType()
        //    {
        //        Id = 1,
        //        DayTypeName = "ngay thuong",
        //        DaysOfTheWeek = "2-3-4-5-6",
        //        Priority = 1,
        //        IsActive = true,
        //        DateCreate = new DateTime(2019 - 02 - 26)
        //    };
        //    var dayexam2 = new DayType()
        //    {
        //        Id = 2,
        //        DayTypeName = "ngay  1/6 ",
        //        FromDate = new DateTime(2018, 6, 1),
        //        ToDate = new DateTime(2018, 6, 1),
        //        Priority = 2,
        //        IsActive = true,
        //        DateCreate = new DateTime(2019 - 02 - 26)
        //    };
        //    var dayexam3 = new DayType()
        //    {
        //        Id = 2,
        //        DayTypeName = "ngay nghi",
        //        DaysOfTheWeek = "7-8",
        //        Priority = 1,
        //        IsActive = true,
        //        DateCreate = new DateTime(2019 - 02 - 26)
        //    };

        //    result.Add(dayexam);
        //    result.Add(dayexam2);
        //    result.Add(dayexam3);
        //    result = result.OrderByDescending(p => p.Priority).ToList();
        //    return result;
        //}



        #endregion


    }
}
