using System;
using System.Xml.Linq;

namespace LINQToXML_CreationXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ To XML. Creation XML *****");

            LongCreationXML("LongCreation.xml");
            FastCreationXML("FastCreation.xml");
        }

        public static void LongCreationXML(string path)
        {
            Console.WriteLine("=> LongCreationXML()");

            XDocument xDoc = new XDocument();

            XElement ruslan = new XElement("person");
            XAttribute ruslanNameAttr = new XAttribute("name", "Ruslan");
            XElement ruslanAgeEl = new XElement("age", 30);
            XElement ruslanCompanyEl = new XElement("company", "Microsoft");

            ruslan.Add(ruslanNameAttr);
            ruslan.Add(ruslanAgeEl);
            ruslan.Add(ruslanCompanyEl);

            XElement marcus = new XElement("person");
            XAttribute marcusNameAttr = new XAttribute("name", "Marcus");
            XElement marcusAgeEl = new XElement("age", 45);
            XElement marcusCompanyEl = new XElement("company", "Yandex");

            marcus.Add(marcusNameAttr);
            marcus.Add(marcusAgeEl);
            marcus.Add(marcusCompanyEl);

            XElement henry = new XElement("person");
            XAttribute henryNameAttr = new XAttribute("name", "Henry");
            XElement henryAgeEl = new XElement("age", 25);
            XElement henryCompanyEl = new XElement("company", "Apple");

            henry.Add(henryNameAttr);
            henry.Add(henryAgeEl);
            henry.Add(henryCompanyEl);

            XElement root = new XElement("people");
            root.Add(ruslan, marcus, henry);

            xDoc.Add(root);
            xDoc.Save(path);

            Console.WriteLine($"Файл {path} создан!");
        }

        public static void FastCreationXML(string path)
        {
            Console.WriteLine("=> FastCreationXML()");

            XDocument xDoc = new XDocument(new XElement("people",
                new XElement("person" ,
                    new XAttribute("name", "Ruslan"),
                    new XElement("age", 30),
                    new XElement("company", "Microsoft")),
                new XElement("person",
                    new XAttribute("name", "Marcus"),
                    new XElement("age", 45),
                    new XElement("company", "Yandex")),
                new XElement("person",
                    new XAttribute("name", "Henry"),
                    new XElement("age", 25),
                    new XElement("company", "Apple"))));
            xDoc.Save(path);

            Console.WriteLine($"Файл {path} создан!");
        }
    }
}
