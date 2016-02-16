/*================================================================================
 * auto：guoxj
 * date：2016-01-18 17:35:56
 * desc：
===================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsole.Model
{
    public class Person
    {
        private int age;
        private string name;

        /// <summary>
        /// Property Name (string)
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Property Age (int)
        /// </summary>
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return "Person = [Name=" + Name + ", Age=" + Age + "]";
        }
    }
}
