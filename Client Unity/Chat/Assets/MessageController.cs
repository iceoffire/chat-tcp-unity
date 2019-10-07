using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    public GameObject myMessagePrefab;
    public GameObject otherMessagePrefab;

    public List<KeyValuePair<bool, string>> messagesToSpawn = new List<KeyValuePair<bool, string>>();

    public static MessageController singleton;

    float sizeY = 0;

    void Awake() 
    {
        singleton = this;
    }

    public void SpawnMessage(bool mine, string message)
    {
        messagesToSpawn.Add(new KeyValuePair<bool, string>(mine,message));
    }

    void Update()
    {
        lock(messagesToSpawn)
        {
            if (messagesToSpawn.Count>0)
            {
                foreach(KeyValuePair<bool,string> message in messagesToSpawn)
                {
                    _SpawnMessage(message.Key, message.Value);
                }
            }
            messagesToSpawn = new List<KeyValuePair<bool, string>>();
        }
    }

    public void _SpawnMessage(bool mine, string message)
    {
        
        if (mine)
        {
            GameObject messageGameObject = Instantiate(myMessagePrefab,this.transform);
            messageGameObject.GetComponent<MessageGO>().SetMessageInfo(message, true);
            sizeY +=  messageGameObject.transform.GetComponent<RectTransform>().sizeDelta.y;
        }
        else
        {
            try
            {
                Debug.Log($"Mensagem: {message}");
                GameObject messageGameObject = Instantiate(otherMessagePrefab,transform);
                messageGameObject.GetComponent<MessageGO>().SetMessageInfo(message);
                sizeY +=  messageGameObject.transform.GetComponent<RectTransform>().sizeDelta.y;

            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }
        this.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0,Math.Max(540,sizeY+10));
        if (sizeY>540)
        {
            this.transform.localPosition = new Vector3(0,sizeY+10-540);
        }
    }
}
