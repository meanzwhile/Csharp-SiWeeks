using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            dict.Add(44, "United Kingdom");
            dict.Add(33, "France");
            dict.Add(31, "Netherlands");
            dict.Add(55, "Brazil");

            Console.WriteLine("The 33 Code is for: {0}", dict[33]);

            foreach (KeyValuePair<int, string> item in dict)
            {
                int key = item.Key;
                string value = item.Value;
                Console.WriteLine("{0} ----> {1}", key, value);
            }

            Console.ReadKey();
        }
    }
}
