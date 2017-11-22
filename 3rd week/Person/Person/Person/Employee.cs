using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Employee : Person
    {
        protected int Salary;
        protected String Profession;
        public Room Room;

        public Employee(String Name) : base(Name) { }
        public Employee(String Name, DateTime BirthDate) : base(Name, BirthDate) { }
        public Employee(String Name, DateTime BirthDate, int Salary, String Profession) : base(Name, BirthDate)
        {
            this.Salary = Salary;
            this.Profession = Profession;
        }

        public override string ToString()
        {
            return "Employee: " + name + " " + age + " " + Profession + " " + Salary;
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.Number);
            return newEmployee;
        }
    }

}
