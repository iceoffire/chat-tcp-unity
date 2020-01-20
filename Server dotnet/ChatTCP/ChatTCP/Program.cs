using System;
using System.Net;
using System.Threading;

class Program
{
    static ChatServer server;

    static void Main(string[] args)
    {
        int port = 1111;

        server = CreateServer(port);

        StartServer();

        while(true) // further: give server control to client.
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
        
        StopServer();
    }

    static ChatServer CreateServer(int port)
    {
        Console.WriteLine($"Creating TCP Server on Port {port}");
        Console.WriteLine();
        return new ChatServer(IPAddress.Any, port);
    }

    static void StopServer()
    {
        Console.WriteLine("Stopping Server.");
        server.Stop();
        Console.WriteLine("Server stopped successfully.");
    }

    static void StartServer()
    {
        Console.WriteLine("Starting server...");
        server.Start();
        Console.WriteLine("Server started successfully.");
    }
}