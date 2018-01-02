using modelLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlUDPReceiver
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

                string carXmlStr = Encoding.ASCII.GetString(data);
                StringReader sr = new StringReader(carXmlStr);
                XmlSerializer serializer = new XmlSerializer(typeof(Car));
                Car incomingCar = (Car)serializer.Deserialize(sr);

                Console.WriteLine($"receive: {incomingCar} from: {senderEP}");
            }
        }
    }
}
