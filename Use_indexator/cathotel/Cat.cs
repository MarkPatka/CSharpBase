using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_indexator
{
    internal class Cat
    {
        public string Name { get; private set; }

        public Cat(string name)
        {
            Name = name;
        }

        public override string ToString() => $"Petname: {Name}";
    }
}
