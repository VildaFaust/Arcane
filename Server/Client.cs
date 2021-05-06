using System.Net.Sockets;
using System.Text;

namespace DefaultNamespace
{
    public class Client
    {
        public Client(TcpClient client)
        {
            var request = string.Empty;
            var buffer = new byte[1024];
            int count;

            while ((count = client.GetStream().Read(buffer, 0, buffer.Length)) > 0)
            {
                request += Encoding.ASCII.GetString(buffer, 0, count);

                if (request.IndexOf("\r\n\r\n") >= 0 || request.Length > 4096)
                {
                    break;
                }
            }
        }
    }
}