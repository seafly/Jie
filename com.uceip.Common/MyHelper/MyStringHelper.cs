using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace com.uceip.Common.MyHelper
{
    public static class MyStringHelper
    {

        /// <summary>
        /// 根据List<object>返回string字符串, 中间值以逗号分隔
        /// </summary>
        /// <param name="objList"></param>
        /// <returns></returns>
        public static string GetStrArray(IList objList)
        {
            if (objList.Count == 0) return "";
            StringBuilder sb = new StringBuilder();
            foreach (object obj in objList)
            {
                sb.Append(int.Parse(obj.ToString())).Append(",");
            }
            return sb.ToString().Length > 0 ? sb.ToString().Substring(0, sb.ToString().Length - 1) : "";
        }

        /// <summary>
        /// 根据参数返回指定值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetKeyInt(object obj, int returnValue)
        {
            if (obj == null)
            {
                return returnValue;
            }
            else if (obj is IList)
            {
                IList list = (IList)obj;
                return list.Count > 0 ? int.Parse((string)list[0]) : returnValue;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

    }
}
