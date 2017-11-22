using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Person
{
    public class Person
    {
        protected String name;
        protected DateTime birthDate;
        protected Gender gender;
        protected int age;

        public Person(String Name)
        {
            this.name = Name;
        }

        public Person(String Name, DateTime BirthDate)
        {
            this.name = Name;
            this.birthDate = BirthDate;
            DateTime now = DateTime.Now;
            age = now.Year - birthDate.Year;
        }

        public override string ToString()
        {
            return "Person: " + name + " " + age;
        }
    }

    public enum Gender { Male, Female };
}
