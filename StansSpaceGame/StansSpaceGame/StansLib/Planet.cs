using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StansLib
{
    public class Planet
    {
        public Planet(string name)
        {
            this.name = name;
        }

        private string name;

        public string GetName() => this.name;
        public void SetName(string name) => this.name = name;
    }
}
