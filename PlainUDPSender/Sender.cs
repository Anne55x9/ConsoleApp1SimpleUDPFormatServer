using modelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPSender
{
    internal class Sender
    {
        private int PORT;

        //public Sender(int port) => this.PORT= port;

        public Sender(int port)
        {
            this.PORT = port;
        }

        public void StartSender()
        {
            Car car = new Car("PlanCar","PlainColor","PlainRegNo");

            using (UdpClient socket = new UdpClient())
            {
                string carStr = car.ToString();

                Byte[] data = Encoding.ASCII.GetBytes(carStr);

                IPEndPoint receiverEP = new IPEndPoint(IPAddress.Loopback, PORT);

                socket.Send(data, data.Length, receiverEP);

                Console.WriteLine($"sent: {carStr} to: {receiverEP}");
            }
        }

    }
}
