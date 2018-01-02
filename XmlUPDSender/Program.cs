using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUPDSender
{
    class Program
    {
        private const int PORT = 11002;
        static void Main(string[] args)
        {
            Sender sender = new Sender(PORT);
            sender.StartSender();

            Console.ReadLine();
        }
    }
}
