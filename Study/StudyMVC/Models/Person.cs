using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyMVC.Models
{

    public interface IPerson
    {
        string Save();
    }

    public class Person : IPerson
    {
        public string Save()
        {
            return "我是Person";
        }
    }

    public class SubPerson : IPerson
    {
        public string Save()
        {
            return "我是SubPerson";
        }
    }

    public class PersonFactory
    {
        public static IPerson GetPerson(string name)
        {
            switch (name)
            {
                case "Person":
                    return new Person();
                case "SubPerson":
                    return new SubPerson();
                default:
                    return new Person();
            }
        }
    }
}