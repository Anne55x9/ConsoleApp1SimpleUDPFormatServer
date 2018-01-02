using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using modelLibrary;
using Newtonsoft.Json;

namespace JsonUDPReceiver
{
    internal class Receiver
    {

        private int PORT;

        public Receiver(int port)
        {
            this.PORT = port;

        }


        public void StartReceiver()
        {
            using (UdpClient socket = new UdpClient(PORT))
            {
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
                Byte[] data = socket.Receive(ref senderEP);

                string carJsonStr = Encoding.ASCII.GetString(data);
                Car incomingCar = JsonConvert.DeserializeObject<Car>(carJsonStr);

                Console.WriteLine($"receive: {incomingCar} from: {senderEP}");

            }

        }
    }
}
