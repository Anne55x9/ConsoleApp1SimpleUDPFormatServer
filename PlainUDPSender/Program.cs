﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPSender
{
    class Program
    {

        private const int PORT = 11001;
        static void Main(string[] args)
        {
            Sender sender = new Sender(PORT);

            sender.StartSender();

            Console.ReadLine();

        }
    }
}
