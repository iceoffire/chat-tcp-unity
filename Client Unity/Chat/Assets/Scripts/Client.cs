using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using TcpClient = NetCoreServer.TcpClient;


public class Client : MonoBehaviour
{
    class ChatClient : TcpClient
    {
        bool _stop=false;
        public ChatClient(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while(IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            Debug.Log("Conectado.");
        }

        protected override void OnDisconnected()
        {
            Debug.Log("Desconectado.");
            if (_stop)
                Debug.Log("Tentando Conectar.");
            Thread.Sleep(1000);

            if (!_stop)
                ConnectAsync();
        }

        protected override void OnError(System.Net.Sockets.SocketError error)
        {
            Debug.Log(error.ToString());
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer,(int)offset,(int)size);
            Debug.Log(message);
            MessageController.singleton.SpawnMessage(false,message);
        }
    }
    
    ChatClient chatClient;
    public TMP_InputField inputMessage;
    public TMP_InputField inputNickname;
    string nickname;

    public void SetNickname()
    {
        nickname = inputNickname.text;
    }

    void Start()
    {
        string address = "127.0.0.1";
        int port = 1111;

        Debug.Log($"TCP server address : {address}");
        Debug.Log($"TCP server port : {port}");

        chatClient = new ChatClient(address,port);

        chatClient.ConnectAsync();
    }

    public void SendMessageToServer()
    {
        string message = inputMessage.text;
        if (message != "")
        {
            chatClient.SendAsync(nickname + ": " + message);
            MessageController.singleton.SpawnMessage(true,message);
            // EventSystem.current.SetSelectedGameObject(inputMessage.gameObject);
            inputMessage.ActivateInputField();
            inputMessage.text = "";
        }
    }

    public void EnterSendMessageToServer()
    {
        if(Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
        {
            SendMessageToServer();
        }
    }

    void OnApplicationQuit()
    {
        chatClient.DisconnectAndStop();
    }

}