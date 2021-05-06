using System;
using System.Net;
using System.Net.Sockets;
using DefaultNamespace;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new BaseServer(80);
        }
    }
}
