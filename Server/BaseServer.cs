using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DefaultNamespace
{
    public class BaseServer
    {
        TcpListener Listener;

        public BaseServer(int port)
        {
            Listener = new TcpListener(IPAddress.Any, port);
            Listener.Start();

            while (true)
            {
                var client = Listener.AcceptTcpClient();
                var thread = new Thread(new ParameterizedThreadStart(ClientThread));
                
                thread.Start(client);
            }
        }

        public static void ClientThread(object stateInfo)
        {
            new Client((TcpClient) stateInfo);
        }
        
        ~BaseServer()
        {
            if (Listener != null)
            {
                Listener.Stop();
            }
        }
    }
}