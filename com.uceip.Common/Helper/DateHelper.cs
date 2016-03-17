/* ------------------------------------------------------------
 *  日期帮助类
 * 
 *  建立人: .Net项目组@联合云端
 *  建立日期: 2011-09-17
 *  
 *  Copyright (c) 深圳联合云端科技. All right reserved.
 *  
 * ------------------------------------------------------------
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace com.uceip.Common
{
    public static class DateHelper
    {

        /// <summary>
        /// 日期参数获取当前周第一天
        /// </summary>
        /// <returns></returns>
        public static string GetStartDayOfWeek(string paramDate)
        {
            DateTime now = Convert.ToDateTime(paramDate);
            int dayOfWeek = Convert.ToInt32(now.DayOfWeek);
            int dayDiff = (-1) * dayOfWeek + 1;

            return now.AddDays(dayDiff).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 根据指定日期参数获得当前周最后一天
        /// </summary>
        /// <returns></returns>
        public static string GetEndDayOfWeek(string paramDate)
        {
            DateTime now = Convert.ToDateTime(paramDate);
            int dayOfWeek = Convert.ToInt32(now.DayOfWeek);
            int dayAdd = 5 - dayOfWeek;

            return now.AddDays(dayAdd).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 日期参数获取当前周第一天
        /// </summary>
        /// <returns></returns>
        public static string GetStartDayOfWeek(string paramDate, int days)
        {
            DateTime now = Convert.ToDateTime(paramDate);
            int dayOfWeek = Convert.ToInt32(now.DayOfWeek);
            if (dayOfWeek == 0) dayOfWeek = 7;
            int dayDiff = (-1) * dayOfWeek + 1;

            return now.AddDays(dayDiff).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 根据指定日期参数获得当前周最后一天
        /// </summary>
        /// <returns></returns>
        public static string GetEndDayOfWeek(string paramDate, int days)
        {
            DateTime now = Convert.ToDateTime(paramDate);
            int dayOfWeek = Convert.ToInt32(now.DayOfWeek);
            if (dayOfWeek == 0) dayOfWeek = 7;
            int dayAdd = days - dayOfWeek;

            return now.AddDays(dayAdd).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 返回当前周最后一天
        /// </summary>
        /// <returns></returns>
        public static string GetEndDayOfWeek()
        {
            return GetEndDayOfWeek(DateTime.Now.ToString());
        }

        /// <summary>
        /// 根据指定日期参数获得日期所在月第一天
        /// </summary>
        /// <param name="paramDate"></param>
        /// <returns></returns>
        public static string GetStartDayOfMonth(string paramDate)
        {
            DateTime now = DateTime.Parse(paramDate);
            return new DateTime(now.Year, now.Month, 1).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 根据指定日期参数获得日期所在月最后一天
        /// </summary>
        /// <param name="paramDate"></param>
        /// <returns></returns>
        public static string GetEndDayOfMonth(string paramDate)
        {
            DateTime now = DateTime.Parse(paramDate);
            return now.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 根据指定日期获得其所在周次
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetWeekNameByDate(DateTime date)
        {
            CultureInfo ci = new CultureInfo("zh-CN");
            System.Globalization.Calendar cal = ci.Calendar;
            CalendarWeekRule cwr = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek dow = DayOfWeek.Monday;
            int week = cal.GetWeekOfYear(date, cwr, dow)-1;

            return week.ToString();
        }

        /// <summary>
        /// 根据指定日期字符串获得周次名称
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetWeekNameByName(string date)
        {
            DateTime d = DateTime.Parse(date);
            return GetWeekNameByDate(d);
        }

        /// <summary>
        /// 根据指定日期字符串获得周次名称
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetYearNameByName(string date)
        {
            return Convert.ToDateTime(date).Year.ToString();
        }

        /// <summary>
        /// 根据指定日期获得其所在周次
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetYearNameByDate(DateTime date)
        {
            return date.Year.ToString();
        }
    }
}
