using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeToXML.Models
{
    [Serializable]
    public class Company
    {
        public string Name { get; set; }

        public Company()
        {

        }

        public Company(string name)
        {
            Name = name;
        }
    }
}
