using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPReceiver
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
                byte[] data = socket.Receive(ref senderEP);

                string carStr = Encoding.ASCII.GetString(data);

                Console.WriteLine($"receive: {carStr} from: {senderEP}");

            }
        }
    }
}
