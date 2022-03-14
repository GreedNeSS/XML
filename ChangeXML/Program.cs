using System;
using System.Xml;

namespace ChangeXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Change XML *****");

            string path = @"People.xml";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement? root = xDoc.DocumentElement;

            if (root != null)
            {
                XmlElement newPeople = xDoc.CreateElement("people");

                XmlAttribute nameAtr = xDoc.CreateAttribute("name");
                XmlElement ageEl = xDoc.CreateElement("age");
                XmlElement companyEl = xDoc.CreateElement("company");

                XmlText nameText = xDoc.CreateTextNode("GreeD");
                XmlText ageText = xDoc.CreateTextNode("30");
                XmlText companyText = xDoc.CreateTextNode("Microsoft");

                nameAtr.AppendChild(nameText);
                ageEl.AppendChild(ageText);
                companyEl.AppendChild(companyText);

                newPeople.Attributes.Append(nameAtr);
                newPeople.AppendChild(ageEl);
                newPeople.AppendChild(companyEl);

                root.AppendChild(newPeople);

                XmlNode? first = root?.FirstChild;
                if (first is not null)
                {
                    root?.RemoveChild(first);
                }

                xDoc.Save(path);
            }
        }
    }
}
