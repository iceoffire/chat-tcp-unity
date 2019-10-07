using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NetCoreServer;


namespace ChatTCP
{
    class ChatSession : TcpSession
    {
        public ChatSession(TcpServer server) : base(server) { }

        protected override void OnConnected()
        {
            Console.WriteLine($"Sessão Cliente TCP com ID({Id}) conectado.");

            SendAsync("[SERVER] CONECTADO.");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine($"Chegando: {message}");

            ChatServer.Multicast(this, message);
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine(error.ToString());
        }
    }

    class ChatServer : TcpServer
    {
        public ChatServer(IPAddress address, int port) : base(address, port) { }

        static List<ChatSession> sessions = new List<ChatSession>();

        protected override TcpSession CreateSession()
        {
            ChatSession newSession = new ChatSession(this);
            sessions.Add(newSession);
            return newSession;
        }

        protected override void OnDisconnected(TcpSession session)
        {
            sessions.Remove((ChatSession)session);
            base.OnDisconnected(session);
        }

        public static void Multicast(ChatSession origin, string text)
        {
            foreach(ChatSession session in sessions)
                if (session!=origin) session.SendAsync(text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int port = 1111;

            Console.WriteLine($"Porta do servidor TCP: {port}");

            Console.WriteLine();

            var server = new ChatServer(IPAddress.Any, port);

            Console.WriteLine("Iniciando servidor...");
            server.Start();
            Console.WriteLine("Iniciado.");

            while(true)
            {
                // string mensagem = Console.ReadLine();
                // if (mensagem == string.Empty)
                //     break;
                // 
                // if (mensagem == "!")
                // {
                //     Console.WriteLine("Reiniciando servidor.");
                //     server.Restart();
                //     Console.WriteLine("Pronto.");
                //     continue;
                // }
                // 
                // mensagem = $"(admin) : {mensagem}";
                // server.Multicast(mensagem);
                Thread.Sleep(100);
            }

            Console.WriteLine("Fechando o servidor.");
            server.Stop();
            Console.WriteLine("Pronto.");
        }
    }
}
