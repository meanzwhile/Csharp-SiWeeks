using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace LookupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary listDictionary = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));

            listDictionary.Add("Estados Unidos", "United States of America");
            listDictionary.Add("Canadá", "Canada");
            listDictionary.Add("España", "Spain");

            Console.WriteLine(listDictionary["eSPaña"]);
            Console.WriteLine(listDictionary["CANADÁ"]);

            Console.ReadKey();
        }
    }
}
