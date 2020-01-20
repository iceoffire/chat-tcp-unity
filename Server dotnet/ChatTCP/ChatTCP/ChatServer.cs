using System.Collections.Generic;
using System.Net;
using NetCoreServer;

class ChatServer : TcpServer
{
    public ChatServer(IPAddress address, int port) : base(address, port) { }

    static List<ChatSession> sessions = new List<ChatSession>();

    protected override TcpSession CreateSession()
    {
        ChatSession newSession = new ChatSession(this);
        AddSessionToSessionList(newSession);
        return newSession;
    }

    void AddSessionToSessionList(ChatSession session)
    {
        sessions.Add(session);
    }

    void RemoveSessionOfSessionList(ChatSession session)
    {
        sessions.Remove((ChatSession)session);
    }

    protected override void OnDisconnected(TcpSession session)
    {
        RemoveSessionOfSessionList((ChatSession)session);
        base.OnDisconnected(session);
    }

    public static void Broadcast(ChatSession origin, string text)
    {
        foreach(ChatSession session in sessions)
        {
            if (!IsOwnSession(origin,session))
            {
                session.SendAsync(text);
            }
        }
    }

    public static bool IsOwnSession(ChatSession thisSession, ChatSession otherSession)
    {
        return thisSession==otherSession;
    }
}