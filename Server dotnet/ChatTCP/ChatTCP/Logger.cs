using System;

public static class Logger
{
    public static void Log(string log, Guid originId, params object[] args)
    {
        string message = $"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] ({originId}) {string.Format(log,args)}";
        System.Console.WriteLine(message);
    }
}