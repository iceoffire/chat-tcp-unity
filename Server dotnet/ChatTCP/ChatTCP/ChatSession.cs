using System.Net.Sockets;
using System.Text;
using NetCoreServer;

class ChatSession : TcpSession
{
    public ChatSession(TcpServer server) : base(server) { }

    protected override void OnConnected()
    {
        Logger.Log($"Client Session connection established with Id: {this.Id}", this.Id);

        SendAsync("[SERVER] Connected successfully.");
    }

    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size); // support to UTF8 only
        Logger.Log($"Receiving message, broadcasting it. Info: syze ({size}), message: {message}", this.Id);

        ChatServer.Broadcast(this, message);
    }

    protected override void OnError(SocketError error)
    {
        Logger.Log($"System report connection error. Info: {error.ToString()}", this.Id);
    }
}