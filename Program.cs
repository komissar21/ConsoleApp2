using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XMLGeneration XMLTables = new XMLGeneration();
            XMLTables.generate();
            XMLTables.write();
            XMLTables.read();

        }
    }
}
