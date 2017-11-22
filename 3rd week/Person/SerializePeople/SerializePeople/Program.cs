using Serializeable_Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Magdi", new DateTime(1970, 2, 3));
            person.Serialize(@"C:\C#\0000\SerializePerson");
            Person person2 = new Person();
            person2 = Person.Deserialize(@"C:\C#\0000\SerializePerson");
            Console.WriteLine(person2);

            Console.ReadKey();
        }
    }
}
