using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyConsole.Model;

namespace StudyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = (DateTime.Parse("2016-01-21 08:00:00").Date - DateTime.Parse("2016-01-20 19:00:00").Date).Days;
            Console.Write(num);
            Console.Read();
        }
    }
}
