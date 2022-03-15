using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using SerializeToXML.Models;

namespace SerializeToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Serialize To XML *****");

            Person person = new Person("Ruslan", 30, new Company("Microsoft"));
            string personFileName = "Person.xml";
            string peopleFileName = "People.xml";
            Person[] people =
            {
                new Person("Ruslan", 30, new Company("Microsoft")),
                new Person("Marcus", 45, new Company("Yandex")),
                new Person("Henry", 24, new Company("Apple")),
            };

            SerializeObject(person, person.GetType(), personFileName);
            Console.WriteLine(XDocument.Load(personFileName));

            Person? restoredPerson = DeserializeObject(person.GetType(), personFileName) as Person;
            Console.WriteLine($"restoredPerson: {restoredPerson}");

            SerializeObject(people, people.GetType(), peopleFileName);
            Console.WriteLine(XDocument.Load(peopleFileName));

            Person[]? restoredPeople = DeserializeObject(people.GetType(), peopleFileName) as Person[];

            if (restoredPeople is not null)
            {
                foreach (var p in people)
                {
                    Console.WriteLine(p);
                }
            }
        }

        static void SerializeObject(object obj, Type objType, string fileName)
        {
            Console.WriteLine("\n=> SerializeObject():");

            XmlSerializer serializer = new XmlSerializer(objType);

            using FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            serializer.Serialize(fs, obj);

            Console.WriteLine("Object has been serialized!");
        }

        static object DeserializeObject(Type objType, string fileName)
        {
            Console.WriteLine("\n=> DeserializeObject():");

            XmlSerializer serializer = new XmlSerializer(objType);

            using FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var obj = serializer.Deserialize(fs);

            Console.WriteLine("File has been deserialized!");

            return obj;
        }
    }
}
