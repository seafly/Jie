using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace com.uceip.Common
{
    public class Commons
    {
        public Commons() { }


        /// <summary>
        /// 对象比较
        /// </summary>
        public static bool CompareObject(object obj1, object obj2)
        {
            if (null == obj1 || null == obj2)
                return false;
            if (obj1.GetType() != obj2.GetType())
                return false;
            return SerializeObject(obj1).Equals(SerializeObject(obj2));
        }
        private static string SerializeObject(object obj)
        {
            if (null == obj)
                return string.Empty;
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            StringBuilder objString = new StringBuilder();
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(obj);     //取得字段的值
                objString.Append(field.Name + ":" + value + ";");
            }
            return objString.ToString();
        }
    }
}
