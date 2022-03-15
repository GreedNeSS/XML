using System;
using System.Linq;
using System.Xml.Linq;

namespace CRUDtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** CRUD to XML *****");

            string path = "People.xml";
            XDocument xDoc = XDocument.Load(path);

            CreateXMLElem(xDoc, path);

            Console.WriteLine(xDoc);

            UpdateXMLElem(xDoc, path);

            Console.WriteLine(xDoc);

            DeleteXMLElem(xDoc, path);

            Console.WriteLine(xDoc);
        }

        static void CreateXMLElem(XDocument xDoc, string path)
        {
            Console.WriteLine("\n=> CreateXMLElem():");

            XElement newElem = new XElement("person",
                new XAttribute("name", "Greed"),
                new XElement("age", 31),
                new XElement("company", "Microsoft"));

            var root = xDoc.Root;
            root?.Add(newElem);
            xDoc.Save(path);
        }

        static void UpdateXMLElem(XDocument xDoc, string path)
        {
            Console.WriteLine("\n=> CreateXMLElem():");

            var marcus = xDoc.Root.Elements()
                .Where(p => p.Attribute("name")?.Value == "Marcus").FirstOrDefault();

            var name = marcus?.Attribute("name");

            if (name != null)
            {
                name.Value = "Marc";
                var age = marcus?.Element("age");

                if (age != null)
                    age.Value = "23";

                xDoc.Save(path);
            }
        }

        static void DeleteXMLElem(XDocument xDoc, string path)
        {
            Console.WriteLine("\n=> DeleteXMLElem():");

            var henry = xDoc.Root.Elements()
                .FirstOrDefault(p => p.Attribute("name")?.Value == "Henry");


            if (henry != null)
            {
                henry.Remove();

                xDoc.Save(path);
            }
        }
    }
}
