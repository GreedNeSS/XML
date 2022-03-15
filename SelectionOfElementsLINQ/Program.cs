using System;
using System.Linq;
using System.Xml.Linq;

namespace SelectionOfElementsLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Selection Of Elements. LINQ *****");
            string path = @"People.xml";

            XDocument xDoc = XDocument.Load(path);

            ShowXML(xDoc);
            ParseToAnonClass(xDoc);
            ParseToPersonClass(xDoc);
        }

        static void ShowXML(XDocument xDoc)
        {
            Console.WriteLine("\n=> ShowXML():");

            var root = xDoc.Element("people");

            if (root is not null)
            {
                foreach (var person in root.Elements())
                {
                    string name = person.Attribute("name")?.Value;
                    string age = person.Element("age")?.Value;
                    string company = person.Element("company")?.Value;

                    Console.WriteLine($"Person: {name}");
                    Console.WriteLine($"Age: {age}");
                    Console.WriteLine($"Company: {company}\n");
                }
            }
        }

        static void ParseToAnonClass(XDocument xDoc)
        {
            Console.WriteLine("\n=> ParseToAnonClass():");

            var root = xDoc.Element("people");

            if (root is not null)
            {
                var people = root.Elements()
                    .Where(p => int.Parse(p.Element("age")?.Value) > 28)
                    .Select(p => new
                    {
                        Name = p.Attribute("name")?.Value,
                        Age = p.Element("age")?.Value,
                        Company = p.Element("company")?.Value
                    });

                foreach (var person in people)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Company: {person.Company}");
                }
            }
        }

        static void ParseToPersonClass(XDocument xDoc)
        {
            Console.WriteLine("\n=> ParseToAnonClass():");

            var root = xDoc.Element("people");

            if (root is not null)
            {
                var people = root.Elements()
                    .Where(p => p.Element("company")?.Value == "Microsoft"
                    || p.Element("company")?.Value == "Yandex")
                    .Select(p => new Person
                    {
                        Name = p.Attribute("name")?.Value,
                        Age = int.Parse(p.Element("age")?.Value),
                        Company = p.Element("company")?.Value
                    });

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
