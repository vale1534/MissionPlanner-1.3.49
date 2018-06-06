using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MissionPlanner
{
    class Coord_CON
    {
        public string IP { get; set; }
        public int PORT { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

        public Coord_CON()
        {
            this.IP = IP;
            this.PORT = PORT;
            this.FileName = FileName;
            this.Path = Path;
        }

        Socket master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Handle_Connection(string IP, int PORT)
        {
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(IP), PORT);
            master.Connect(ipEnd);

        }

        public void Handle_Disconnection()
        {
            master.Close();
        }

        public void Send_File(string FileName, string Path)
        {
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            master.Connect(ipEnd);

            byte[] fileNameByte = Encoding.ASCII.GetBytes(FileName);
            byte[] fileData = File.ReadAllBytes(Path +FileName);
            byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
            byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

            fileNameLen.CopyTo(clientData, 0);
            fileNameByte.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileNameByte.Length);
            master.Send(clientData);

        }
        

       

    }
}
