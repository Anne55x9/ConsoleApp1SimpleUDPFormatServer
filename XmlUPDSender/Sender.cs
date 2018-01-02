using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using modelLibrary;

namespace XmlUPDSender
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
            Car car = new Car("XlmModel","XmlColor","XmlRegNo");

            using (UdpClient socket = new UdpClient())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Car));
                StringWriter sw = new StringWriter();

                serializer.Serialize(sw,car);

                string carXmlStr = sw.ToString();

                Byte[] data = Encoding.ASCII.GetBytes(carXmlStr);


                IPEndPoint receiverEP = new IPEndPoint(IPAddress.Loopback, PORT);
                socket.Send(data, data.Length, receiverEP);

                Console.WriteLine($"sent: {carXmlStr} to: {receiverEP}");
            }


        }
    }
}
