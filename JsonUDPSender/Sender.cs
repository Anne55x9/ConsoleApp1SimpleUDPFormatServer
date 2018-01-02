using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using modelLibrary;
using Newtonsoft.Json;


namespace JsonUDPSender
{
    internal class Sender
    {
        private int PORT;

        public Sender(int port)
        {
            this.PORT = port;
        }

        public void StartSender()
        {
            Car carSender = new Car("Tesla", "green", "555");


            using (UdpClient socket = new UdpClient())
            {
                //string carStr = carSender.ToString();

                string carJsonStr = JsonConvert.SerializeObject(carSender);

                Byte[] data = Encoding.ASCII.GetBytes(carJsonStr);

                IPEndPoint receiverEP = new IPEndPoint(IPAddress.Loopback, PORT);

                socket.Send(data, data.Length, receiverEP);

                Console.WriteLine($"sent: {carJsonStr} to: {receiverEP}");
            }

        }
    }
}
