using System;
using System.Xml;

namespace Queryselector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Queryselector *****\n");

            XmlDocument xml = new XmlDocument();
            xml.Load(@".\..\..\..\People.xml");
            XmlElement? root = xml.DocumentElement;

            Console.WriteLine("=> xml.root.forEach()");

            if (root is not null)
            {
                foreach (XmlElement person in root?.SelectNodes("person"))
                {
                    Console.WriteLine("\t" + person.OuterXml);
                }
            }

            Console.WriteLine("\n=> xml.root.forEach(p => p.name)");

            if (root is not null)
            {
                foreach (XmlElement person in root?.SelectNodes("person"))
                {
                    Console.WriteLine("\t" + person.SelectSingleNode("@name")?.Value);
                }
            }

            Console.WriteLine("\n=> person[@name='Ruslan']:\n\t" + 
                root.SelectSingleNode("person[@name='Ruslan']").OuterXml);

            Console.WriteLine("\n=> person[company='Apple']:\n\t" +
                root?.SelectSingleNode("person[company='Apple']").OuterXml);

            Console.WriteLine("\n=> //person/company:");

            if (root is not null)
            {
                foreach (XmlNode company in root?.SelectNodes("//person/company"))
                {
                    Console.WriteLine("\t" + company.InnerText);
                }
            }
        }
    }
}
