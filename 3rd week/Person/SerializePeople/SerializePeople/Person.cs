using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializeable_Person
{
    [Serializable]
    public enum Gender { Male, Female };

    [Serializable]
    public class Person : IDeserializationCallback, ISerializable
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public Gender gender { get; set; }
        [NonSerialized]
        private int age;

        public int MyProperty
        {
            get { return age; }
            set { age = value; }
        }


        public Person(){ }
        
        public Person(String Name, DateTime BirthDate)
        {
            this.name = Name;
            this.birthDate = BirthDate;
            DateTime now = DateTime.Now;
            age = now.Year - birthDate.Year;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            this.name = info.GetString("name");
            this.birthDate = info.GetDateTime("birthDate");
            //Gender still misses
        }

        public override string ToString()
        {
            return "Person: " + name + " " + age;
        }

        public void Serialize(string output)
        {
            using (Stream stream = File.Open(output, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

        public static Person Deserialize(string filePath)
        {
            Person person = new Person();
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (Person) binaryFormatter.Deserialize(stream);
            }
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            age = DateTime.Now.Year - birthDate.Year;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name);
            info.AddValue("birthDate", birthDate);
            info.AddValue("gender", gender);
            Console.WriteLine("buzifej");
        }
    }
}

