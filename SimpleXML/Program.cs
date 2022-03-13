using System;
using System.Collections.Generic;
using System.Xml;

namespace SimpleXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple XML *****");

            List<Person> people = new List<Person>();

            XmlDocument xml = new XmlDocument();
            xml.Load(@".\..\..\..\People.xml");
            XmlElement? xRoot = xml.DocumentElement;

            if (xRoot != null)
            {
                foreach (XmlElement node in xRoot)
                {
                    //XmlNode atr = node.Attributes.GetNamedItem("name");
                    //string atrVal = atr.Value;
                    string name = node.GetAttribute("name");

                    Person person = new() { Name = name };

                    foreach (XmlNode field in node.ChildNodes)
                    {
                        if (field.Name == "age")
                            person.Age = int.Parse(field.InnerText);
                        
                        if (field.Name == "company")
                            person.Company = field.InnerText;
                    }

                    people.Add(person);
                }
            }

            Console.WriteLine("\n=> people:");

            foreach (Person per in people)
            {
                Console.WriteLine(per);
            }
        }
    }
}
